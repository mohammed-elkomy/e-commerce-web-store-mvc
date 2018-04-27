using System;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.NewDb;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{
    public class HomeController : Controller
    {

        private readonly UserManager<User> _userManager;
        private readonly DataContext _context;

        public HomeController(UserManager<User> userManager, DataContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public IActionResult Index()
        {
            var result = _context.Products
                .OrderByDescending(o => o.SoldCount)
                .Take(11)
                .Include(o => o.Images)
                .ToList();
            ViewData["LeastSold"] = _context.Products.OrderBy(o => o.SoldCount).Include(o => o.Images).FirstOrDefault();

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Contact()
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var CurrentUser = _context.Users.Where(u => u.Id == user.Id).First();

            return View(new Message { Email = CurrentUser.Email, Name = CurrentUser.Firstname+" "+ CurrentUser.Lastname });
        }

        [HttpPost]
        public async Task<IActionResult> Contact(Message model, [FromServices] DataContext dbContext)
        {
            if (ModelState.IsValid)
            {
                var res = await dbContext.Messages.AddAsync(model);
                if (res.State == EntityState.Added && dbContext.SaveChanges() > 0)
                {
                   
                    ViewData["success"] = "success";
                    model.Subject = "";
                    
                    return View(model);
                }

                ModelState.AddModelError(String.Empty, "Couldn't save to DB");
            }

            return View(model);
        }
    }
}
