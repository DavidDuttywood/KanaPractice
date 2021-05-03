using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class QuestionViewModel
    {
        public int Id { get; set; }

        public string TextString { get; set; }

        public string Romanised { get; set; }

        public List<String> PossibleAnswers { get; set; }

        public int Lives { get; set; }

        public QuestionViewModel()
        {

        }

        public QuestionViewModel(int id, string text, string romanised, int lives)
        {
            this.Id = id;

            this.TextString = text;

            this.Romanised = romanised;

            this.PossibleAnswers = new List<String>();

            this.Lives = lives;
        }
    }
}
