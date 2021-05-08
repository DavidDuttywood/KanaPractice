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
            QuestionSet = 0;
            _httpContextAccessor = httpContextAccessor;
            _questionRepo = questionRepo;

            this.Questions = _questionRepo.GetAllQuestions();

            //is this janky (to reference this.Questions right after initialising?)
            this.AnswerBank = this.Questions.Select(o => o.Answer).ToList();

        }

        public QuestionViewModel GetNextQuestion()
        {

            //This is absolutely TRAGIC and suboptimised. Need to return a smaller filtered question set
            //during object instanciation. That requires mixing dependency injection with
            //passed params? Perhaps some factory implementation?
            Questions = Questions.Where(x => x.SetId == QuestionSet).ToList();

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