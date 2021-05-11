using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;

namespace KanaPractice.Models
{
    public class Game : IGame
    {
        public int QuestionSet { get; set; }
        public List<Question> Questions { get; set; }
        public List<string> AnswerBank { get; set; }

        private readonly IQuestionRepo _questionRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Game(IQuestionRepo questionRepo, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _questionRepo = questionRepo;
        }

        public QuestionViewModel GetNextQuestion(int questionSet)
        {
            Questions = _questionRepo.GetAllQuestionsBySetID(questionSet);
            AnswerBank = Questions.Select(o => o.Answer).ToList();

            Random r = new Random();
            int listSize = Questions.Count;

            Question q = Questions[r.Next(0, listSize)];
            QuestionViewModel qvm = new QuestionViewModel(
                q.Id, 
                q.QuestionTextString, 
                q.Answer,
                Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetInt32("Lives")),
                Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetInt32("Score"))
             );

            //get the choices for the question
            qvm.PossibleAnswers.Add(q.Answer);
            while (qvm.PossibleAnswers.Count < 4)
            {
                string next = AnswerBank[r.Next(0, listSize)];
                if (!qvm.PossibleAnswers.Contains(next))
                {
                    qvm.PossibleAnswers.Add(next);
                }
            }

            //shuffle - order by random GUID (inexpensive for small list)
            qvm.PossibleAnswers = qvm.PossibleAnswers.OrderBy(x => Guid.NewGuid()).ToList();

            return qvm;
        }

        public bool Validate(string correctAnswer, string chosenAnswer)
        {
            int score = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetInt32("Score"));
            int lives = Convert.ToInt32(_httpContextAccessor.HttpContext.Session.GetInt32("Lives"));

            if (correctAnswer == chosenAnswer)
            {
                _httpContextAccessor.HttpContext.Session.SetInt32("Score", score + 1);
                return true;
            }
            else
            {
                --lives;
                _httpContextAccessor.HttpContext.Session.SetInt32("Lives", lives);
            }

            return lives > 0;
        }
    }
}