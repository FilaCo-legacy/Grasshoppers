using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grasshoppers.Areas.Administration.Models;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore;

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

        public async Task<IActionResult> List(int page = 1, int pageSize = 5)
        {
            return View(await PaginationViewModel<User>.CreateAsync(_userManager.Users, page, pageSize));
        }

        [HttpPost]
        public async Task<ActionResult> Delete(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            if (user != null)
            {
                await _userManager.DeleteAsync(user);
            }

            return RedirectToAction("List");
        }
        
        public async Task<IActionResult> ChangeRoles(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user == null) return NotFound();
            
            var userRoles = await _userManager.GetRolesAsync(user);
            var allRoles = _roleManager.Roles.ToList();
            var model = new ChangeRoleViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                UserRoles = userRoles,
                AllRoles = allRoles
            };
            
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> ChangeRoles(string userId, List<string> roles)
        {
            var user = await _userManager.FindByIdAsync(userId);
            
            if (user == null) return NotFound();
            
            var userRoles = await _userManager.GetRolesAsync(user);
                
            var addedRoles = roles.Except(userRoles);
                
            var removedRoles = userRoles.Except(roles);
 
            await _userManager.AddToRolesAsync(user, addedRoles);
 
            await _userManager.RemoveFromRolesAsync(user, removedRoles);
 
            return RedirectToAction("List");
        }
    }
}