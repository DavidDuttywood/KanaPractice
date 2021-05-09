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
        public ViewResult Index() {
            return View();
        }

        [HttpGet]
        public ViewResult Game(int id)
        {
            HttpContext.Session.SetInt32("Lives", 5);
            HttpContext.Session.SetInt32("Score", 0);
            HttpContext.Session.SetInt32("QuestionSet", id);
         
            _game.LoadGame(Convert.ToInt32(HttpContext.Session.GetInt32("QuestionSet")));

            QuestionViewModel qvm = _game.GetNextQuestion();
            return View(qvm);
        }

        [HttpPost]
        public ViewResult Game(QuestionViewModel question, string chosenAnswer)
        {
            ModelState.Clear();

            _game.LoadGame(Convert.ToInt32(HttpContext.Session.GetInt32("QuestionSet")));
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
                GameOverViewModel govm = new GameOverViewModel(score);
                return View("GameOver", govm);
            }

        }

        public ActionResult Reset()
        {
            return RedirectToAction("Game", new {id = Convert.ToInt32(HttpContext.Session.GetInt32("QuestionSet"))});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
