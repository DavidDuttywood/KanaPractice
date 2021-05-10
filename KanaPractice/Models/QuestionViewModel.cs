using System.Collections.Generic;

namespace KanaPractice.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionTextString { get; set; }

        public string Answer { get; set; }

        public List<string> PossibleAnswers { get; set; } = new List<string>();

        public int Lives { get; set; }

        public int Score { get; set; }

        public QuestionViewModel()
        {

        }

        public QuestionViewModel(int id, string questiontext, string answer, int lives, int score)
        {
            Id = id;

            QuestionTextString = questiontext;

            Answer = answer;

            PossibleAnswers = new List<string>();

            Lives = lives;

            Score = score;
        }
    }
}
