using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ECommerce.Models.NewDb;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{

    public class AdminController : Controller
    {
        private readonly DataContext _context;
        private readonly UserManager<User> _userManager;

        public AdminController(DataContext context, UserManager<User> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize]//(Roles = "Admin")
        public async Task<IActionResult> Control_Panel()
        {

            var user = await _userManager.GetUserAsync(HttpContext.User);
            var roles = await _userManager.GetRolesAsync(user);

            if (roles.Count == 0)
                return RedirectToAction("Index", "Home");
            else
                return View();
        }

        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> Add_product(Product model, List<IFormFile> images)
        {
            var cate = Request.Form["category"];
            var sub =Request.Form["sub-category"];

            var user = await _userManager.GetUserAsync(HttpContext.User);

            var db_images = new List<Image>();
            string image_url;
            foreach (var image in images)
            {
                if (image.Length > 0)
                {

                    image_url = $"/images/{ Guid.NewGuid()}.jpg";
                    using (var stream = System.IO.File.OpenWrite($"./wwwroot/{image_url}"))
                    {
                        await image.CopyToAsync(stream);
                        db_images.Add(new Image { Url = image_url });
                    }
                }
            }

            await _context.Products.AddAsync(new Product
            {
                CategoryId = _context.Categories.Where(obj => obj.Parent.Name == cate[0] && obj.Name == sub[0]).First().Id,
                Description = model.Description,
                ShortDescription = model.ShortDescription,
                Name = model.Name,
                Price = model.Price,
                UserId = user.Id,
                SoldCount = 0,
                Images = db_images
            });

            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home");

        }
    }


}