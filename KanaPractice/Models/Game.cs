using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class Game
    {
        public List<Question> Questions { get; set; }
        public List<String> AnswerBank { get; set; }
        public int Lives { get; set; }
        public int Score { get; set; }


        public Game(IQuestionRepo question)
        {
            this.Questions = question.GetAllQuestions();

            //is this janky (to reference this.Questions right after initialising?)
            this.AnswerBank = this.Questions.Select(o => o.Answer).ToList();

            this.Lives = 3;

            this.Score = 0;
        }

        public QuestionViewModel GetNextQuestion()
        {
            Random r = new Random();
            int listSize = this.Questions.Count;

            Question q = this.Questions[r.Next(0, listSize)];
            QuestionViewModel qvm = new QuestionViewModel(q.Id, q.QuestionTextString, q.Answer, this.Lives, this.Score);

            //get the choices for the question
            qvm.PossibleAnswers.Clear();
            qvm.PossibleAnswers.Add(q.Answer);
            while(qvm.PossibleAnswers.Count < 4)
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