using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class MockQuestionRepo : IQuestionRepo
    {
        public List<Question> GetAllQuestions()
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
            questions.Add(new Question(11, "さ", "sa"));
            questions.Add(new Question(12, "し", "shi"));
            questions.Add(new Question(13, "す", "su"));
            questions.Add(new Question(14, "せ", "se"));
            questions.Add(new Question(15, "そ", "so"));
            //todo - add all alphabet
            return questions;
        }
    }
}
