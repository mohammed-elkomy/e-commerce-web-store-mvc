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

        public PartialViewResult GetProducts(int minPrice, int maxPrice, OrderBy orderBy, int perPage, int page, int category, string keywords)
        {
            return PartialView();
        }

        public ViewResult Single()
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
