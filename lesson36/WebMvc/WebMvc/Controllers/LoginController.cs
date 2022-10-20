using Microsoft.AspNetCore.Mvc;

namespace WebMvc.Controllers
{
    public class LoginController : Controller
    {
        public IActionResult Index()
        {
            ViewBag.Titel = "Login";
            return View();
        }
        public IActionResult LonginNewUser()
        {
            return View();
        }
        public IActionResult RegisterUser()
        {
            return View();
        }
    }
}