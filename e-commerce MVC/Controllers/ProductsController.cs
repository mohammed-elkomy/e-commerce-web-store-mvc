using Microsoft.AspNetCore.Mvc;

namespace ECommerce.Controllers
{
    public class ProductsController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }

        public RedirectResult Search(string keywords)
        {
            return Redirect(Url.Action("Index", "Products") + "#keywords=" + keywords);
        }
        public ViewResult Single()
        {
            return View();
        }
    }
}
