using Microsoft.AspNetCore.Mvc;

namespace Antra.CRMApp.WebMVC.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            ViewData["Title"] = "Product/Index";
            return View();
        }
        public IActionResult Detail()
        {
            ViewData["Title"] = "Product/Details";
            return View("explain");
        }
    }
}
