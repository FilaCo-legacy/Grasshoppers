using System.Collections.Generic;
using System.Threading.Tasks;
using Grasshoppers.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

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
        
        public async Task<IActionResult> Index(int page = 1, int pageSize = 5) => 
            View(await PaginationViewModel<IdentityRole>.CreateAsync(_roleManager.Roles, page, pageSize));
 
        public IActionResult Create() => View();
        
        [HttpPost]
        public async Task<IActionResult> Create(string name)
        {
            if (string.IsNullOrEmpty(name)) return View(name);
            
            var result = await _roleManager.CreateAsync(new IdentityRole(name));
            
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View();
        }
         
        [HttpPost]
        public async Task<IActionResult> Delete(IEnumerable<string> elems)
        {
            foreach (var curId in elems)
            {
                var role = await _roleManager.FindByIdAsync(curId);
            
                if (role != null)
                {
                    await _roleManager.DeleteAsync(role);
                }   
            }
            
            return RedirectToAction("Index");
        }
    }
}