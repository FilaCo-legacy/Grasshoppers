using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Grasshoppers.Areas.Administration.Models;
using Grasshoppers.Data;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Language;

namespace Grasshoppers.Areas.Administration.Controllers
{
    [Area("Administration")]
    public class RolesController:Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;
        
        public RolesController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;

        }
        
        public async Task<IActionResult> List(int page = 1, int pageSize = 5) => 
            View(await PaginationViewModel<IdentityRole>.CreateAsync(_roleManager.Roles, page, pageSize));
 
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrEmpty(name)) return View(name);
            
            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            
            if (result.Succeeded)
            {
                return RedirectToAction("List");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            
            if (role != null)
            {
                await _roleManager.DeleteAsync(role);
            }
            
            return RedirectToAction("List");
        }
    }
}