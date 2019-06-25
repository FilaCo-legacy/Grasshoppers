using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grasshoppers.Areas.Administration.Models;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Grasshoppers.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class UsersController : Controller
    {
        private readonly UserManager<User> _userManager;

        private readonly RoleManager<IdentityRole> _roleManager;

        public UsersController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IActionResult> Index(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<User>.CreateAsync(_userManager.Users, page, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<string> elems)
        {
            var invokerUser = await _userManager.FindByNameAsync(User.Identity.Name);
            
            foreach (var curId in elems)
            {
                if (curId == invokerUser.Id) continue;
                
                var user = await _userManager.FindByIdAsync(curId);

                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }   
            }

            return RedirectToAction("Index");
        }
        
        public async Task<IActionResult> ChangeRoles(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                Id = user.Id,
                UserName = user.UserName,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            
            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> ChangeRoles(string id, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(id);
            
            if (user == null) return NotFound();
            
            var userRoles = await _userManager.GetRolesAsync(user);
                
            var addedRoles = roles.Except(userRoles);
                
            var removedRoles = userRoles.Except(roles);
 
            await _userManager.AddToRolesAsync(user, addedRoles);
 
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
 
            return RedirectToAction("Index");
        }
    }
}