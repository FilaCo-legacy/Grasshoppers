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
        
        [HttpGet]
        public IActionResult SignIn(string returnUrl = null)
        {
            return View(new SignInModel { ReturnUrl = returnUrl });
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SignIn(SignInModel model)
        {
            if (!ModelState.IsValid) return View(model);
            
            var result = 
                await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
            
            if (result.Succeeded)
            {
                
                if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                {
                    return Redirect(model.ReturnUrl);
                }

                return RedirectToAction("Index", "Home");
            }

            ModelState.AddModelError("", "Incorrect username/email or(and) password");
            
            return View(model);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LogOut()
        {
            // Remove cookies
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}