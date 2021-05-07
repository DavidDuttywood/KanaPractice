using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Session;
using KanaPractice.Models;
using Microsoft.AspNetCore.Http;

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
            HttpContext.Session.SetInt32("Lives", 3);
            HttpContext.Session.SetInt32("Score", 0);

            QuestionViewModel qvm = _game.GetNextQuestion();
            return View(qvm);
        }

        [HttpPost]
        public ViewResult Index(QuestionViewModel question, string chosenAnswer)
        {
            ModelState.Clear();

            int score = Convert.ToInt32(HttpContext.Session.GetInt32("Score"));
            int lives = Convert.ToInt32(HttpContext.Session.GetInt32("Lives"));

            if (question.Answer == chosenAnswer)
                HttpContext.Session.SetInt32("Score", score+1);
            else
                HttpContext.Session.SetInt32("Lives", lives-1);

            if (HttpContext.Session.GetInt32("Lives") > 0)
            {
                QuestionViewModel qvm = _game.GetNextQuestion();
                return View(qvm);
            }
            else
            {
                GameOverViewModel govm = new GameOverViewModel(0);
                return View("GameOver", govm);
            }

        }

        public ActionResult Reset()
        {
            //_game.Lives = 3;
            //_game.Score = 0;

            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
