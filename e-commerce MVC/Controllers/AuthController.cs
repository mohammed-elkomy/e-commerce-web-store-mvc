using System.Threading.Tasks;
using ECommerce.Models.NewDb;
using ECommerce.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class AuthController : Controller
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager)
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
                    ModelState.AddModelError(nameof(model.ToSAgreed),"Must agree to ToS");
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
                        using (var stream = System.IO.File.OpenWrite($"./wwwroot/usersImages/{user.Id}.jpg"))
                            await image.CopyToAsync(stream);

                    ViewData["Success"] = "Registered Successfully";
                    return RedirectToAction(nameof(Login), new {returnUrl});
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
        public async Task<IActionResult> ForgotMyPassword(LoginViewModel model)
        {
            return View();
        }


        [HttpPost]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}
