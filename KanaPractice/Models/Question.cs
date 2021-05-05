using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class Question
    {
        public int Id { get; set; }
        [Required]
        public string QuestionTextString { get; set; }
        [Required]

        public string Answer { get; set; }

        public Question(int id, string text, string answer)
        {
            this.Id = id;

            this.QuestionTextString = text;

            this.Answer = answer;
        }

    }
}
