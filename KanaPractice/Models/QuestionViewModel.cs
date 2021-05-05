using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string QuestionTextString { get; set; }

        public string Answer { get; set; }

        public List<String> PossibleAnswers { get; set; }

        public int Lives { get; set; }

        public int Score { get; set; }

        public QuestionViewModel()
        {

        }

        public QuestionViewModel(int id, string questiontext, string answer, int lives, int score)
        {
            this.Id = id;

            this.QuestionTextString = questiontext;

            this.Answer = answer;

            this.PossibleAnswers = new List<String>();

            this.Lives = lives;

            this.Score = score;
        }
    }
}
