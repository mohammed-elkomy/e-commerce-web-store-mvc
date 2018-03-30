using System;
using System.Threading.Tasks;
using ECommerce.Models.NewDb;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ECommerce.Controllers
{ 
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Contact()
        {
            return View();
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
                    return View();
                }

                ModelState.AddModelError(String.Empty, "Couldn't save to DB");
            }

            ModelState.AddModelError(String.Empty, "Invalid Model");
            return View(model);
        }
    }
}
