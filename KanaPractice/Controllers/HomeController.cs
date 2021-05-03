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
            QuestionViewModel qvm = _quiz.GetNextQuestion();
            return View(qvm);
        }

        [HttpPost]
        public ViewResult Index(QuestionViewModel question, string chosenAnswer)
        {
            ModelState.Clear(); //why do i need this?

            if (question.Romanised == chosenAnswer)
            {
                Console.WriteLine("Correct");
            }
            else
            {
                Console.WriteLine("Incorrect");
                _quiz.Lives--;
            }

            if(_quiz.Lives > 0)
            {
                QuestionViewModel qvm = _quiz.GetNextQuestion();
                return View(qvm);
            }
            else
            {
                return View("GameOver");
            }

        }

        public ViewResult Reset()
        {
            _quiz.Lives = 3;
            QuestionViewModel qvm = _quiz.GetNextQuestion();
            return View("Index", qvm);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
