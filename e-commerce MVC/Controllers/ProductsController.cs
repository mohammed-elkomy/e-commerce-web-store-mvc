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

        public ViewResult Index()
        {
            return View();
        }

        public RedirectResult Search(string keywords)
        {
            return Redirect(Url.Action("Index", "Products") + "#keywords=" + keywords);
        }

        public PartialViewResult GetProducts(int minPrice, int maxPrice, int perPage, int page, int? category, string keywords=null, OrderBy orderBy= OrderBy.Default)
        {
            var result = _context.Products.Where(o => o.Price >= minPrice).Where(o => o.Price <= maxPrice);
            if (category != null)
                result = result.Where(o => o.Category == category);
            if (!string.IsNullOrWhiteSpace(keywords))
                result = result.Where(o => o.Name.Contains(keywords));
            switch (orderBy)
            {
                case OrderBy.Default:
                    result = result.OrderBy(o => o.Id);
                    break;
                case OrderBy.Price:
                    result = result.OrderBy(o => o.Price);
                    break;
                case OrderBy.Popularity:
                    result = result.OrderBy(o => o.SoldCount);
                    break;
                case OrderBy.AverageRating:
                    break;
            }

            result = result.Skip(page * perPage).Take(perPage);
            return PartialView(result);
        }

        public ViewResult Single(int id)
        {
            return View();
        }

        [HttpGet]
        [ResponseCache(Duration = 300)]
        public JsonResult CategoryTree()
        {
            return Json(null);
        }
    }
}
