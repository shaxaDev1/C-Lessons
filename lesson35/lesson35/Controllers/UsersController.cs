using lesson35.Models;
using lesson35.Services;
using Microsoft.AspNetCore.Mvc;

namespace lesson35.Controllers
{
    public class UsersController : Controller
    {
        private UsersService usersService;

        public UsersController ()
        {
            usersService = new UsersService();
        }
        public IActionResult Index()
        {
            var users = usersService.GetUsers();
            ViewBag.Title = "Users";
            return View(users);
        }
        public IActionResult Add()
        {
            ViewBag.Title = "AddUser";
            return View();
        }
        public IActionResult AddUser(User user)
        {
            usersService.InsertUser(user);
            ViewBag.Title = "User Add";
            return View(user);
        }
        public IActionResult Delete(int index)
        {
            usersService.DeleteUser(index);
            return RedirectToAction("Index");
        }
        public IActionResult Edit(int index)
        {
            var user = usersService.GetUserByIndex(index);
            ViewBag.Title = "Edit user";
            ViewBag.UserIndex = index;
            return View(user);
        }
        public IActionResult EditUser(User user)
        {
            usersService.UpdateUser(user);
            return RedirectToAction("Index");
        }
    }
}
