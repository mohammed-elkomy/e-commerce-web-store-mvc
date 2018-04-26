using System.Linq;
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
        private readonly DataContext _context;

        public AuthController(SignInManager<User> signInManager, UserManager<User> userManager, DataContext context)
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
        public async Task<IActionResult> Login(LoginViewModel model,string returnUrl)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded) {

                    var CurrentUser = _context.Users.Where(user => user.UserName == model.UserName).First();
                    var retString = (CurrentUser.Firstname + " " + CurrentUser.Lastname);
                    Response.Cookies.Append("user name ui", retString.Substring(0, System.Math.Min(retString.Length,10)));

                    return RedirectToLocal(returnUrl); }
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
                    ModelState.AddModelError(nameof(model.ToSAgreed),"Must agree to Terms and conditions");
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


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }


    
        [HttpGet]
        [Authorize]
        public IActionResult EditProfile(string returnUrl)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }


        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            return View();
        }
    }
}
