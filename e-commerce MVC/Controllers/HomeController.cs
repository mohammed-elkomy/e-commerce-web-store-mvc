using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using e_commerce_MVC.Models;

namespace e_commerce_MVC.Controllers
{
    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return View();
        }


        // todo: replace below methods with supported ones.

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page."; 
               
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
