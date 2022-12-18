using BuyFS.Entity.POCO;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Patrician.WebApp.Models;

namespace Patrician.WebApp.Controllers
{
    //Account Management Controller
    public class AccountController : Controller
    {
        private readonly UserManager<AppClient> userManager;
        private readonly SignInManager<AppClient> signInManager;

        //UserManager (Identity lib) is needed for UserManager and the SignInManager - - AccountController class
        public AccountController(UserManager<AppClient> _userManager, SignInManager<AppClient> _signInManager)
        {
            this.userManager = _userManager;
            this.signInManager = _signInManager;
        }

        [HttpGet] //For login procedures, in order to redirect the user
        public async Task <IActionResult> Login(string _ReturnURL)
        {
            TempData["returnURL"] = _ReturnURL;
            return View();
        }

        //Note method, Passwordsigninasync
        [HttpPost] //For login procedures, for account validation
        public async Task<IActionResult> Login(string _userName, string _password)
        {
            var sign = await signInManager.PasswordSignInAsync(_userName, _password, false, false);

            if (sign.Succeeded)
            {
                if (TempData["returnURL"] != null)
                {
                    return Redirect(TempData["returnURL"].ToString());
                }
                return RedirectToAction("Index", "Home");
            }
            return View();
        }

        //for registration procedures
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost] //registration process with account validation
        public async Task <IActionResult> Register(RegisterViewModel _model)
        {
            if (ModelState.IsValid)
            {
                //create a new user
                AppClient _appClient = new AppClient
                {
                    Email = _model.EmailAddress,
                    UserName = _model.UserName
                };

                //put the user into user manager
                var identityResult = await userManager.CreateAsync(_appClient, _model.Password);

                //if identity result is not successfull
                if (!identityResult.Succeeded)
                {
                    foreach (var item in identityResult.Errors)
                    {
                        ModelState.AddModelError("Registration Unsuccessful, please try again later.", item.Description);
                    }

                    return View(_model);
                }
                //if successful, add the user with new role
                else
                {
                    await userManager.AddToRoleAsync(_appClient, "UserApp");
                }

            }
            return RedirectToAction("Login");
        }

        public async Task <IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index","Home");
        }
    }
}
