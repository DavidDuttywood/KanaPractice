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

    }
}
