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


        public Quiz()
        {
            this.Questions = GetQuestions();

            //is this janky (to reference this.Questions right after initialising?)
            this.AnswerBank = this.Questions.Select(o => o.Romanised).ToList();
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

            return questions;
        }


        public QuestionViewModel GetNextQuestion()
        {
            Random r = new Random();
            int listSize = this.Questions.Count;

            QuestionViewModel qvm = new QuestionViewModel();

            Question q = this.Questions[r.Next(0, listSize)];

            qvm.Id = q.Id;
            qvm.TextString = q.TextString;
            qvm.Romanised = q.Romanised;
            qvm.PossibleAnswers = new List<string>();

            //get the choices for the question
            qvm.PossibleAnswers.Clear();
            qvm.PossibleAnswers.Add(q.Romanised);
            qvm.PossibleAnswers.Add(this.AnswerBank[r.Next(0, listSize)]);
            qvm.PossibleAnswers.Add(this.AnswerBank[r.Next(0, listSize)]);

            //shuffle?

            //return a question object to the view

            return qvm;
        }
    }
}