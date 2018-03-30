using System.Linq;
using ECommerce.Models;
using ECommerce.Models.Database;
using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ShopDbContext _context;

        public ProductsController(ShopDbContext context)
        {
            _context = context;
        }

        public ViewResult Index(
            int? minPrice = null,
            int? maxPrice = null,
            int perPage = 9,
            int page = 0,
            int? category = null,
            string keywords = null,
            OrderBy orderBy = OrderBy.Default)
        {
            var result = _context.Products.AsQueryable();
            if (minPrice != null)
                result = result.Where(o => o.Price >= minPrice);
            if (maxPrice != null)
                result = result.Where(o => o.Price <= maxPrice);
            if (category != null)
                result = result.Where(o => o.Category == category);
            if (!string.IsNullOrWhiteSpace(keywords))
                result = result.Where(o => o.Name.Contains(keywords));
            switch (orderBy)
            {
                case OrderBy.Price:
                    result = result.OrderBy(o => o.Price);
                    break;
                case OrderBy.Popularity:
                    result = result.OrderBy(o => o.SoldCount);
                    break;
                case OrderBy.AverageRating:
                    break;
                default:
                    result = result.OrderBy(o => o.Id);
                    break;
            }

            result = result.Skip(page * perPage).Take(perPage);
            return View(result);
        }

        public IActionResult Single(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null || product.Id < 1)
            {
                return RedirectToAction("Index");
            }

            return View(product);
        }
        
    }
}
