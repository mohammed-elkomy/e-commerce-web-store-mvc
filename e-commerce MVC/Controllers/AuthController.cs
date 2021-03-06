﻿using ECommerce.Models.NewDb;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ECommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;



        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, DataContext context, RoleManager<UserRole> roleManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _context = context;
         
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
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {

                    var CurrentUser = _context.Users.Where(user => user.UserName == model.UserName).First();
                    
                    var roles = await _userManager.GetRolesAsync(CurrentUser);

                    var retString = (CurrentUser.Firstname + " " + CurrentUser.Lastname);

                    Response.Cookies.Append("user name ui", retString.Substring(0, System.Math.Min(retString.Length, 15)), new CookieOptions { Expires = DateTime.Now.AddYears(1000) });

                    if(roles.Count > 0)
                        Response.Cookies.Append("user role ui", roles[0]);

                    return RedirectToLocal(returnUrl);
                }
                ModelState.AddModelError(string.Empty, "Wrong username/password combination.");
            }

            return View();
        }

        [HttpGet]
        public IActionResult Register(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model, IFormFile image, string returnUrl)
        {
            if (ModelState.IsValid)
            {
                if (!model.ToSAgreed)
                {
                    ModelState.AddModelError(nameof(model.ToSAgreed), "Must Agree To Terms and Conditions");
                    return View();
                }
                var user = new User
                {
                    Email = model.Email,
                    UserName = model.UserName,
                    Firstname = model.FirstName,
                    Lastname = model.LastName,
                    Phone = model.PhoneNumber,
                    NewsSubscription = model.SubscripedToNews
                };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    if (image != null && image.Length > 0)
                        using (var stream = System.IO.File.OpenWrite($"./private_storage/userImages/{user.Id}.jpg"))
                            await image.CopyToAsync(stream);

                    ViewData["Success"] = "Registered Successfully";
                    return RedirectToAction(nameof(Login), new { returnUrl });
                }

                foreach (var error in result.Errors)
                    ModelState.AddModelError(string.Empty, error.Description);
                return View();
            }

            ModelState.AddModelError(string.Empty, "Invalid model.");
            return View();
        }

        [HttpGet]
        public IActionResult ForgotMyPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ForgotMyPassword(LoginViewModel model)
        {

            return View();
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            Response.Cookies.Delete("user name ui");
            Response.Cookies.Delete("user role ui");
           
            return RedirectToAction("Index", "Home");
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> EditProfile(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;

            ProfileViewModel ViewModel = await GetProfileViewModel();

            return View(ViewModel);
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> EditProfile(ProfileViewModel model, IFormFile image, string returnUrl) 
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                // Get the roles for the user
               

                if (image != null && image.Length > 0)
                    using (var stream = System.IO.File.OpenWrite($"./private_storage/userImages/{user.Id}.jpg"))
                        await image.CopyToAsync(stream);

                var CurrentUser = _context.Users.Where(u => u.Id == user.Id).First();
                CurrentUser.Firstname = model.Firstname;
                CurrentUser.Lastname = model.Lastname;
                CurrentUser.Phone = model.Phone;
                CurrentUser.Email = model.Email;

                await _context.SaveChangesAsync();

                var retString = (CurrentUser.Firstname + " " + CurrentUser.Lastname);
                Response.Cookies.Append("user name ui", retString.Substring(0, System.Math.Min(retString.Length, 15)), new CookieOptions { Expires = DateTime.Now.AddYears(1000) });
              

                return RedirectToAction(nameof(Profile), new { returnUrl= returnUrl, success = true });
            }

            return RedirectToAction(nameof(EditProfile), new { returnUrl });
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile(string returnUrl,bool success)
        {
            ViewData["ReturnUrl"] = returnUrl;

            ProfileViewModel ViewModel = await GetProfileViewModel();
            if (success)
                ViewData["success"] = true;
            return View(ViewModel);
        }

        private async Task<ProfileViewModel> GetProfileViewModel()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var hasProfileImage = System.IO.File.Exists($"./private_storage/userImages/{user.Id}.jpg");

            byte[] bytes = null;
            if (hasProfileImage)
                bytes = await System.IO.File.ReadAllBytesAsync($"./private_storage/userImages/{user.Id}.jpg");

            var ViewModel = new ProfileViewModel
            {
                Email = user.Email,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Phone = user.Phone,
                ImageBase64 = hasProfileImage ? "data:image/png;base64," + Convert.ToBase64String(bytes) : "/images/default.png"
            };
            return ViewModel;
        }


   
    }
}
