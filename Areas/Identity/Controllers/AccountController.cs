using System.Threading.Tasks;
using Grasshoppers.Areas.Identity.Models;
using Grasshoppers.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Grasshoppers.Areas.Identity.Controllers
{
    [Area("Identity")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
 
        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var user = new User { UserName = model.UserName, Email =  model.Email};

            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                // Setup cookies
                await _signInManager.SignInAsync(user, false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
            
            return View(model);
        }
    }
}