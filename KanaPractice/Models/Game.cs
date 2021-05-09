using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class Game
    {
        public int QuestionSet { get; set; }
        public List<Question> Questions { get; set; }
        public List<String> AnswerBank { get; set; }

        private readonly IQuestionRepo _questionRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public Game(IQuestionRepo questionRepo, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
            _questionRepo = questionRepo;
        }

        //Initialise the question set AFTER the user chooses an input
        public Game LoadGame(int questionSet)
        { 
            Questions = _questionRepo.GetAllQuestionsBySetID(questionSet);
            AnswerBank = this.Questions.Select(o => o.Answer).ToList();

            return this;
        }

        public QuestionViewModel GetNextQuestion()
        {

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
            qvm.PossibleAnswers.Clear();
            qvm.PossibleAnswers.Add(q.Answer);
            while (qvm.PossibleAnswers.Count < 4)
            {
                string next = this.AnswerBank[r.Next(0, listSize)];
                if (!qvm.PossibleAnswers.Contains(next))
                {
                    qvm.PossibleAnswers.Add(next);
                }
            }

            //shuffle - order by random GUID (inexpensive for small list)
            qvm.PossibleAnswers = qvm.PossibleAnswers.OrderBy(x => Guid.NewGuid()).ToList();

            return qvm;
        }
    }
}