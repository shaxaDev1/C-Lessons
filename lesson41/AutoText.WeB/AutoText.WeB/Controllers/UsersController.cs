using AutoText.WeB.Models;
using AutoText.WeB.Repositories;
using AutoText.WeB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoText.WeB.Controllers;

public class UsersController : Controller
{
    private readonly UsersRepository _usersRepository;
    private readonly CookiesService _cookiesService;
    private readonly UsersService _usersService;
    private readonly TicketsRepository _ticketsRepository;
    private readonly QuestionsRepository _questionsRepository;

    public UsersController()
    {
        _usersRepository = new UsersRepository();
        _cookiesService = new CookiesService();
        _usersService = new UsersService();
        _ticketsRepository = new TicketsRepository();
        _questionsRepository = new QuestionsRepository();
    }
    public IActionResult Index()
    {
        var user = _usersService.GetUserFromCookie(HttpContext);
        if (user!= null)
        {
            return View(user);
        }
        return RedirectToAction("SignIn");
    }
    public IActionResult SignUp()
    {
        return View();
    }
    public IActionResult SignIn()
    {
        return View();
    }

    [HttpPost]
    public IActionResult SignIn(UserDto user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }
        

        var userP = _usersRepository.GetUserByPhoneNumber(user.Phone);
        if (userP.Password == user.Password)
        {
            _cookiesService.SendUserPhoneToCookie(user.Phone!, HttpContext);
            return RedirectToAction("Index");
        }

        return RedirectToAction("SignIn");
    }

    [HttpPost]
    public IActionResult SignUp(User user)
    {
        if (!ModelState.IsValid)
        {
            return View(user);
        }

        user.Image ??= "user.png";
        _usersRepository.InsertUser(user);
        var _user = _usersRepository.GetUserByPhoneNumber(user.Phone);
        _ticketsRepository.InsertUserTrainingTickets(_user.Index, _questionsRepository.GetQuestionsCount() / 20, 20);
        _cookiesService.SendUserPhoneToCookie(user.Phone!, HttpContext);
        return RedirectToAction("Index");
    }

    public IActionResult Edit()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Edit([FromForm] User user)
    {
        var _user = _usersService.GetUserFromCookie(HttpContext);
        if (_user == null)
            return RedirectToAction("SingIn");

        user.Index = _user.Index;
        user.Image = SaveUserImage(user.ImageFile);
        _usersRepository.UpdateUser(user);
        return RedirectToAction("Index");
    }

    public string? SaveUserImage(IFormFile? userImageFile)
    {
        if(userImageFile == null)
        {
            return "user.png";
        }
        var imagePost = Guid.NewGuid().ToString("N") + Path.GetExtension(userImageFile.FileName);

        var ms = new MemoryStream();
        userImageFile.CopyTo(ms);
        System.IO.File.WriteAllBytes(Path.Combine("wwwroot","Profile",imagePost), ms.ToArray());

        return imagePost;
    }
}
