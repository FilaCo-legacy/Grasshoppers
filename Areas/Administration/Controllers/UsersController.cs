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

        public async Task<IActionResult> Edit(IEnumerable<string> elems)
        {
            var model = new EditUserModel();
            var elemsCount = elems.Count();

            foreach (var curRole in _roleManager.Roles.ToList())
            {
                var count = 0;
                await _userManager.Users.ForEachAsync(async
                    user =>
                {
                    if (await _userManager.IsInRoleAsync(user, curRole.Name))
                        ++count;
                });
                if (count == 0)
                    model.UsersRoles.Add(curRole.Name, CheckboxState.NotChecked);
                else if (count == elemsCount)
                    model.UsersRoles.Add(curRole.Name, CheckboxState.Checked);
                else 
                    model.UsersRoles.Add(curRole.Name, CheckboxState.Indeterminate);
            }

            foreach (var curId in elems)
            {
                var user = await _userManager.FindByIdAsync(curId);

                if (user == null) continue;
                
                model.UserIds.Add(user.Id);
                
                if (elemsCount != 1) continue;
                
                model.Email = user.Email;
                model.UserName = user.UserName;
            }

            return View(model);
        }
        
        [HttpPost]
        public async Task<IActionResult> Edit(EditUserModel model)
        {
            if (!ModelState.IsValid) return View(model);

            foreach (var curId in model.UserIds)
            {
                var user = await _userManager.FindByIdAsync(curId);

                if (user == null) continue;
                
                user.Email = model.Email ?? user.Email;
                user.UserName = model.UserName ?? user.UserName;

                var addedRoles = (from curPair in model.UsersRoles where curPair.Value == CheckboxState.Checked select curPair.Key).ToList();
                var removedRoles = (from curPair in model.UsersRoles where curPair.Value == CheckboxState.NotChecked select curPair.Key).ToList();

                await _userManager.AddToRolesAsync(user, addedRoles);
                await _userManager.RemoveFromRolesAsync(user, removedRoles);
                
                var result = await _userManager.UpdateAsync(user);
                
                if (result.Succeeded) continue;

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                } 
                
                return View(model);
            }
            return RedirectToAction("List");
        }

        [HttpPost]
        public async Task<ActionResult> Delete(IEnumerable <string> elems)
        {
            foreach (var curId in elems)
            {
                var user = await _userManager.FindByIdAsync(curId);
            
                if (user != null)
                {
                    await _userManager.DeleteAsync(user);
                }
            }
            
            return RedirectToAction("List");
        }
    }
}