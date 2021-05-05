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
        private readonly Game _game;

        public HomeController(Game game)
        {
            _game = game;
        }

        [HttpGet]
        public ViewResult Index()
        {
            QuestionViewModel qvm = _game.GetNextQuestion();
            return View(qvm);
        }

        [HttpPost]
        public ViewResult Index(QuestionViewModel question, string chosenAnswer)
        {
            ModelState.Clear(); //why do i need this?

            if (question.Answer == chosenAnswer)
                _game.Score++;
            else
                _game.Lives--;

            if(_game.Lives > 0)
            {
                QuestionViewModel qvm = _game.GetNextQuestion();
                return View(qvm);
            }
            else
            {
                GameOverViewModel govm = new GameOverViewModel(_game.Score);
                return View("GameOver", govm);
            }

        }

        public ActionResult Reset()
        {
            _game.Lives = 3;
            _game.Score = 0;

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
