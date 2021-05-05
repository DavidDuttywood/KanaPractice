using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class Quiz
    {
        public List<Question> Questions { get; set; }
        public List<String> AnswerBank { get; set; }
        public int Lives { get; set; }
        public int Score { get; set; }

        public Quiz()
        {
            this.Questions = GetQuestions();

            //is this janky (to reference this.Questions right after initialising?)
            this.AnswerBank = this.Questions.Select(o => o.Answer).ToList();

            this.Lives = 3;

            this.Score = 0;
        }

        private List<Question> GetQuestions()
        {
            List<Question> questions = new List<Question>();

            questions.Add(new Question(1, "あ", "a"));
            questions.Add(new Question(2, "い", "i"));
            questions.Add(new Question(3, "う", "u"));
            questions.Add(new Question(4, "え", "e"));
            questions.Add(new Question(5, "お", "o"));
            questions.Add(new Question(6, "か", "ka"));
            questions.Add(new Question(7, "き", "ki"));
            questions.Add(new Question(8, "く", "ku"));
            questions.Add(new Question(9, "け", "ke"));
            questions.Add(new Question(10, "こ", "ko"));
            //todo - add all alphabet
            return questions;
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
            while(qvm.PossibleAnswers.Count < 3)
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