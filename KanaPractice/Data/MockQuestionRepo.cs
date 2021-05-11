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
                QuestionTextString = "い",
                Answer = "i"
            });
            Questions.Add(new Question()
            {
                Id = 3,
                SetId = 1,
                QuestionTextString = "う",
                Answer = "u"
            });
            Questions.Add(new Question()
            {
                Id = 4,
                SetId = 1,
                QuestionTextString = "え",
                Answer = "e"
            });
            Questions.Add(new Question()
            {
                Id = 5,
                SetId = 1,
                QuestionTextString = "お",
                Answer = "o"
            });
            Questions.Add(new Question()
            {
                Id = 6,
                SetId = 1,
                QuestionTextString = "か",
                Answer = "ka"
            });
            Questions.Add(new Question()
            {
                Id = 7,
                SetId = 1,
                QuestionTextString = "き",
                Answer = "ki"
            });
            Questions.Add(new Question()
            {
                Id = 8,
                SetId = 1,
                QuestionTextString = "く",
                Answer = "ku"
            });
            Questions.Add(new Question()
            {
                Id = 9,
                SetId = 1,
                QuestionTextString = "け",
                Answer = "ke"
            });
            Questions.Add(new Question()
            {
                Id = 10,
                SetId = 1,
                QuestionTextString = "こ",
                Answer = "ko"
            });
            Questions.Add(new Question()
            {
                Id = 11,
                SetId = 1,
                QuestionTextString = "さ",
                Answer = "sa"
            });
            Questions.Add(new Question()
            {
                Id = 12,
                SetId = 1,
                QuestionTextString = "し",
                Answer = "shi"
            });
            Questions.Add(new Question()
            {
                Id = 13,
                SetId = 1,
                QuestionTextString = "す",
                Answer = "su"
            });
            Questions.Add(new Question()
            {
                Id = 14,
                SetId = 1,
                QuestionTextString = "せ",
                Answer = "se"
            });
            Questions.Add(new Question()
            {
                Id = 15,
                SetId = 1,
                QuestionTextString = "な",
                Answer = "na"
            });
            Questions.Add(new Question()
            {
                Id = 16,
                SetId = 1,
                QuestionTextString = "に",
                Answer = "ni"
            });
            Questions.Add(new Question()
            {
                Id = 17,
                SetId = 1,
                QuestionTextString = "ぬ",
                Answer = "nu"
            });
            Questions.Add(new Question()
            {
                Id = 18,
                SetId = 1,
                QuestionTextString = "ね",
                Answer = "ne"
            });
            Questions.Add(new Question()
            {
                Id = 19,
                SetId = 1,
                QuestionTextString = "の",
                Answer = "no"
            });
            Questions.Add(new Question()
            {
                Id = 20,
                SetId = 2,
                QuestionTextString = "ア",
                Answer = "a"
            });
            Questions.Add(new Question()
            {
                Id = 21,
                SetId = 2,
                QuestionTextString = "イ",
                Answer = "i"
            });
            Questions.Add(new Question()
            {
                Id = 22,
                SetId = 2,
                QuestionTextString = "ウ",
                Answer = "u"
            });
            Questions.Add(new Question()
            {
                Id = 23,
                SetId = 2,
                QuestionTextString = "エ",
                Answer = "e"
            });
            Questions.Add(new Question()
            {
                Id = 24,
                SetId = 2,
                QuestionTextString = "オ",
                Answer = "o"
            });
            Questions.Add(new Question()
            {
                Id = 25,
                SetId = 2,
                QuestionTextString = "カ",
                Answer = "ka"
            });
            Questions.Add(new Question()
            {
                Id = 26,
                SetId = 2,
                QuestionTextString = "キ",
                Answer = "ki"
            });
            Questions.Add(new Question()
            {
                Id = 27,
                SetId = 2,
                QuestionTextString = "ク",
                Answer = "ku"
            });
            Questions.Add(new Question()
            {
                Id = 28,
                SetId = 2,
                QuestionTextString = "ケ",
                Answer = "ke"
            });
            Questions.Add(new Question()
            {
                Id = 29,
                SetId = 2,
                QuestionTextString = "コ",
                Answer = "ko"
            });
            Questions.Add(new Question()
            {
                Id = 30,
                SetId = 2,
                QuestionTextString = "サ",
                Answer = "sa"
            });
            Questions.Add(new Question()
            {
                Id = 31,
                SetId = 2,
                QuestionTextString = "シ",
                Answer = "shi"
            });
            Questions.Add(new Question()
            {
                Id = 32,
                SetId = 2,
                QuestionTextString = "ス",
                Answer = "su"
            });
            Questions.Add(new Question()
            {
                Id = 33,
                SetId = 2,
                QuestionTextString = "セ",
                Answer = "se"
            });
            Questions.Add(new Question()
            {
                Id = 34,
                SetId = 2,
                QuestionTextString = "ナ",
                Answer = "na"
            });
            Questions.Add(new Question()
            {
                Id = 35,
                SetId = 2,
                QuestionTextString = "ニ",
                Answer = "ni"
            });
            Questions.Add(new Question()
            {
                Id = 36,
                SetId = 2,
                QuestionTextString = "ヌ",
                Answer = "nu"
            });
            Questions.Add(new Question()
            {
                Id = 37,
                SetId = 2,
                QuestionTextString = "ネ",
                Answer = "ne"
            });
            Questions.Add(new Question()
            {
                Id = 38,
                SetId = 2,
                QuestionTextString = "ノ",
                Answer = "no"
            });
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
