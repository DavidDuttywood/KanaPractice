using System.Collections.Generic;
using System.Linq;

namespace KanaPractice.Models
{
    public class MockQuestionRepo : IQuestionRepo
    {
        public List<Question> Questions { get; set; }

        public MockQuestionRepo()
        {
            Questions = new List<Question>();
            Questions.Add(new Question()
            {
                Id = 1,
                SetId = 1,
                QuestionTextString = "あ",
                Answer = "a"
            });
            Questions.Add(new Question()
            {
                Id = 2,
                SetId = 1,
                QuestionTextString = "あ",
                Answer = "a"
            });
            Questions.Add(new Question()
            {
                Id = 3,
                SetId = 1,
                QuestionTextString = "あ",
                Answer = "a"
            });
            Questions.Add(new Question()
            {
                Id = 4,
                SetId = 1,
                QuestionTextString = "あ",
                Answer = "a"
            });
            //Questions.Add(new Question(1, 1, "あ", "a"));
            //Questions.Add(new Question(2, 1, "い", "i"));
            //Questions.Add(new Question(3, 1, "う", "u"));
            //Questions.Add(new Question(4, 1, "え", "e"));
            //Questions.Add(new Question(5, 1, "お", "o"));
            //Questions.Add(new Question(6, 1, "か", "ka"));
            //Questions.Add(new Question(7, 1, "き", "ki"));
            //Questions.Add(new Question(8, 1, "く", "ku"));
            //Questions.Add(new Question(9, 1, "け", "ke"));
            //Questions.Add(new Question(10, 1, "こ", "ko"));
            //Questions.Add(new Question(11, 1, "さ", "sa"));
            //Questions.Add(new Question(12, 1, "し", "shi"));
            //Questions.Add(new Question(13, 1, "す", "su"));
            //Questions.Add(new Question(14, 1, "せ", "se"));
            //Questions.Add(new Question(15, 1, "そ", "so"));
            //Questions.Add(new Question(16, 2, "ア", "a"));
            //Questions.Add(new Question(17, 2, "イ", "i"));
            //Questions.Add(new Question(18, 2, "ウ", "u"));
            //Questions.Add(new Question(19, 2, "エ", "e"));
            //Questions.Add(new Question(20, 2, "オ", "o"));
            //Questions.Add(new Question(21, 2, "カ", "ka"));
            //Questions.Add(new Question(22, 2, "キ", "ki"));
            //Questions.Add(new Question(23, 2, "ク", "ku"));
            //Questions.Add(new Question(24, 2, "ケ", "ke"));
            //Questions.Add(new Question(25, 2, "コ", "ko"));
            //Questions.Add(new Question(26, 2, "サ", "sa"));
            //Questions.Add(new Question(27, 2, "シ", "shi"));
            //Questions.Add(new Question(28, 2, "ス", "su"));
            //Questions.Add(new Question(29, 2, "セ", "se"));
            //Questions.Add(new Question(30, 2, "ソ", "so"));
        }


        public List<Question> GetAllQuestions()
        {
            return Questions;
        }

        public List<Question> GetAllQuestionsBySetID(int setId)
        { 
            return Questions.Where(x => x.SetId == setId).ToList();
        }
    }
}
