using AvtoTest.Mvc.Models;
using AvtoTest.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace AvtoTest.Mvc.Controllers
{
    public class QuestionsController : Controller
    {
        //public void GetTicketIndex(int index)
        //{
        //    var question = new QuestionsRepository();
        //    var TicketQuestionsCount = question.TicketQuestionsCount;
        //    var from = index * TicketQuestionsCount;
        //}

        public IActionResult Index(int? tIndex = null, int? index = null, int? choiceIndex = null)
        {
            if (tIndex == null)
            {
                tIndex = new Random().Next(0, QuestionsRepository.Instance.GetTicketsCount());
            }

            ViewBag.tIndex = tIndex;
            ViewBag.tQuestionsCount = QuestionsRepository.Instance.TicketQuestionsCount;
            var tQuestions = QuestionsRepository.Instance.GetTicketQuestions(tIndex.Value);
            
            if (index == null) index = 0;
            ViewBag.qIndex = index;

            var question = tQuestions[index.Value];

            if(choiceIndex != null)
            {
                ViewBag.ChoiceIndex = choiceIndex.Value;
                ViewBag.ChoiceResult = Answer(question, choiceIndex.Value);
            }
                 
            
            return View(question);

        }
        public IActionResult Tickets()
        {
            var questions = new QuestionsRepository();
            ViewBag.count = questions.GetTicketsCount();
            return View();
        }
        private  bool Answer(QuestionBase question, int choiceIndex)
        {
            var choice = question.Choices[choiceIndex];
            return choice.Answer;
        }
    }
}
