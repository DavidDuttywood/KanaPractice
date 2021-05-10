using KanaPractice.Enums;
using KanaPractice.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KanaPractice.Controllers
{
    public class HomeController : Controller
    {
        private readonly IGame _game;

        public HomeController(IGame game)
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
         
            QuestionViewModel qvm = _game.GetNextQuestion(id);
            return View(qvm);
        }

        [HttpPost]
        public ViewResult Game(QuestionViewModel question, string chosenAnswer)
        {

            int id = HttpContext.Session.GetInt32("QuestionSet") ?? (int)Gametype.Hiragana;
            int score = HttpContext.Session.GetInt32("Score") ?? default;

            if (_game.Validate(question.Answer, chosenAnswer))
            {
                QuestionViewModel qvm = _game.GetNextQuestion(id);
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
            return RedirectToAction("Game", new {id = HttpContext.Session.GetInt32("QuestionSet") ?? (int)Gametype.Hiragana });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
