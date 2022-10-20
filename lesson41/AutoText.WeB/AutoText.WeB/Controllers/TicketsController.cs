using AutoText.WeB.Repositories;
using AutoText.WeB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoText.WeB.Controllers;

public class TicketsController : Controller
{
    private UsersService _usersService;
    private TicketsRepository _ticketsRepository;
    public TicketsController()
    {
        _usersService = new UsersService();
        _ticketsRepository = new TicketsRepository();
    }

    public IActionResult Index()
    {
        var user = _usersService.GetUserFromCookie(HttpContext);
        if (user == null) return RedirectToAction("SignIn", "Users");

        var tickets = _ticketsRepository.GetTicketsByUserId(user.Index);

        return View(tickets);
    }
}
