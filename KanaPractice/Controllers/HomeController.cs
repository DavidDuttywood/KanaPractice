using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using KanaPractice.Models;

namespace KanaPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly Quiz _quiz;

        public HomeController(Quiz quiz)
        {
            _quiz = quiz;
        }

        [HttpGet]
        public ViewResult Index()
        {
            Random r = new Random();
            int listSize = _quiz.Questions.Count;


            //MAKE ANOTHER CONTROLLER AND INSTANCIATE THE SAME _QUIZ, TRY AND REMOVE FROM EACH CONTROLLER TO SEE IF IT SHARES.

            //APPRAOCH WILL BE SELECT RANDOM INT FROM LIST OF IDS IN SESSION SO DONT NEED TO CHANGE THE LIST IN QUIZ QUESTIONS PROP


            //get a random question (move all this into Quiz class?)
            Question q = _quiz.Questions[r.Next(0, listSize)];

            //get the choices for the question
            q.PossibleAnswers.Clear();
            q.PossibleAnswers.Add(q.Romanised);
            q.PossibleAnswers.Add(_quiz.AnswerBank[r.Next(0, listSize)]);
            q.PossibleAnswers.Add(_quiz.AnswerBank[r.Next(0, listSize)]);

            //shuffle?

            //return a question object to the view
            return View(q);
        }

        [HttpPost]
        public ViewResult Index(int var)
        {
            throw new NotImplementedException();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
