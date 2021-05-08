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

            //all in one monolitic list (like in a "Questions! table in a db)

            questions.Add(new Question(1, 1, "あ", "a"));
            questions.Add(new Question(2, 1, "い", "i"));
            questions.Add(new Question(3, 1, "う", "u"));
            questions.Add(new Question(4, 1, "え", "e"));
            questions.Add(new Question(5, 1, "お", "o"));
            questions.Add(new Question(6, 1, "か", "ka"));
            questions.Add(new Question(7, 1, "き", "ki"));
            questions.Add(new Question(8, 1, "く", "ku"));
            questions.Add(new Question(9, 1, "け", "ke"));
            questions.Add(new Question(10, 1, "こ", "ko"));
            questions.Add(new Question(11, 1, "さ", "sa"));
            questions.Add(new Question(12, 1, "し", "shi"));
            questions.Add(new Question(13, 1, "す", "su"));
            questions.Add(new Question(14, 1, "せ", "se"));
            questions.Add(new Question(15, 1, "そ", "so"));
            questions.Add(new Question(16, 2, "ア", "a"));
            questions.Add(new Question(17, 2, "イ", "i"));
            questions.Add(new Question(18, 2, "ウ", "u"));
            questions.Add(new Question(19, 2, "エ", "e"));
            questions.Add(new Question(20, 2, "オ", "o"));
            questions.Add(new Question(21, 2, "カ", "ka"));
            questions.Add(new Question(22, 2, "キ", "ki"));
            questions.Add(new Question(23, 2, "ク", "ku"));
            questions.Add(new Question(24, 2, "ケ", "ke"));
            questions.Add(new Question(25, 2, "コ", "ko"));
            questions.Add(new Question(26, 2, "サ", "sa"));
            questions.Add(new Question(27, 2, "シ", "shi"));
            questions.Add(new Question(28, 2, "ス", "su"));
            questions.Add(new Question(29, 2, "セ", "se"));
            questions.Add(new Question(30, 2, "ソ", "so"));
            //todo - add all alphabet
            return questions;
         
        }
    }
}
