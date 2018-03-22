using System;
using System.Threading.Tasks;
using ECommerce.Models.Database;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<Users> _signInManager;
        private readonly UserManager<Users> _userManager;

        public AuthController(SignInManager<Users> signInManager, UserManager<Users> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        [HttpGet]
        public IActionResult Login(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                    return RedirectToLocal(returnUrl);
                ModelState.AddModelError(string.Empty, "Wrong username/password combination.");
            }
            
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile image )
        {
            if (ModelState.IsValid)
            {
                var user = new Users
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Firstname = model.FirstName,
                    Lastname = model.LastName,
                    Phone = model.PhoneNumber
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    ViewData["Success"] = "Registered Successfully";
                    return View("Login");
                }

                ModelState.AddModelError(String.Empty, "Error registering, please validate your data and try again.");
                return View();
            }

            ModelState.AddModelError(String.Empty, "Invalid model.");
            return View();
        }

        [HttpGet]
        public IActionResult ForgotMyPassword()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ForgotMyPassword(LoginViewModel model)
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }
    }
}
