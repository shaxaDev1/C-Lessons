using AvtoTest.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvtoTest.Mvc.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}