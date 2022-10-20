using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public string Index()
        {
            return "Hello World";
        }
        public string GetName()
        {
            return "Name: ism";
        }
        public int Add(int a , int b)
        {
            return a + b;
        }
    }
}