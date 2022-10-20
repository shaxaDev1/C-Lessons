using AutoText.WeB.Models;
using AutoText.WeB.Repositories;
using AutoText.WeB.Services;
using Microsoft.AspNetCore.Mvc;

namespace AutoText.WeB.Controllers;

public class ExaminationsController : Controller
{
    private readonly QuestionsRepository _questionsRepository;
    private readonly UsersService _usersService;
    private readonly TicketsRepository _ticketsRepository;

    private const int TicketQuestionCount = 20;
    public ExaminationsController()
    {
        _questionsRepository = new QuestionsRepository();
        _usersService = new UsersService();
         _ticketsRepository = new TicketsRepository();
    }
    public IActionResult Index()
    {
        var user = _usersService.GetUserFromCookie(HttpContext);
        if(user == null)
        {
            return RedirectToAction("SignIn", "Users");
        }

        var ticket = CreateRandomTicket(user);
        return View(ticket);
    }
    private Ticket  CreateRandomTicket(User user)
    {
        var ticketCount = _questionsRepository.GetQuestionsCount()/ TicketQuestionCount;

        var random = new Random();
        var ticketIndex = random.Next(0, ticketCount);  
        var from = ticketIndex * TicketQuestionCount;

        var ticket = new Ticket(user.Index, from, TicketQuestionCount);

        _ticketsRepository.InsertTicket(ticket);

        var id = _ticketsRepository.GetLastRowId();
        ticket.Id = id;

        return ticket;

    }
    public IActionResult Exam(int ticketId, int? questionId = null, int? choiceId = null)
    {
        var user = _usersService.GetUserFromCookie(HttpContext);
        if (user == null) return RedirectToAction("SignIn", "Users");

        var ticket = _ticketsRepository.GetTicketById(ticketId, user.Index);
        questionId = questionId ?? ticket.FromIndex;

        if(ticket.FromIndex <= questionId && ticket.QuestionsCount + ticket.FromIndex > questionId)
        {
            var question = _questionsRepository.GetQuestionById(questionId.Value);

            ViewBag.TicketData = _ticketsRepository.GetTicketDataById(ticket.Id);

            //2, get from ticket_data by questionId and ticketId
            var _ticketData = _ticketsRepository.GetTicketDataByQuestionId(ticketId, questionId.Value);

            var _choiceId = (int?)null;
            var _answer = false;

            if(_ticketData != null)
            {
                _choiceId = _ticketData.ChoiceId;
                _answer = _ticketData.Answer;
            }
            else if(choiceId != null)
            {
                var answer = question.Choices!.First(choice => choice.Id == choiceId).Answer;

                var ticketData = new TicketData()
                {
                    TicketId = ticketId,
                    QuestionId = question.Id,
                    ChoiceId = choiceId.Value,
                    Answer = answer
                };
                _ticketsRepository.InsertTicketData(ticketData);

                _choiceId = choiceId;
                _answer = answer;

                // 4, if answer true updata ticket correct count 
                if (_answer)
                {
                    _ticketsRepository.UpdataTicketCorrectCount(ticket.Id);
                }

                //3, aga hamm savolga javob bergan bolsa natijani korsatish 
                if(ticket.QuestionsCount == _ticketsRepository.GetIicketAnswersCount(ticketId))
                {
                    return RedirectToAction("ExamResult", new { ticketId = ticket.Id });
                }
               
            }

            ViewBag.Ticket = ticket;  
            ViewBag.ChoiceId = _choiceId;
            ViewBag.Answer = _answer;

            return View(question);
        }
        return NotFound();
    }
    public IActionResult GetQuestionById(int questionId)
    {
        var question = _questionsRepository.GetQuestionById(questionId);
        return View(question);
    }

    public IActionResult ExamResult(int ticketId)
    {
        var user = _usersService.GetUserFromCookie(HttpContext);

        if (user == null) return RedirectToAction("SingIn", "Users");

        var ticket = _ticketsRepository.GetTicketById(ticketId, user.Index);

        return View(ticket);
    }
}


