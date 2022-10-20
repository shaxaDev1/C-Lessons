using Microsoft.AspNetCore.Mvc;

namespace lesson35.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Title = "Home";
            return View();
        }
       
    }
}
