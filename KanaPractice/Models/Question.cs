using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int SetId { get; set; }
        public string QuestionTextString { get; set; }
        public string Answer { get; set; }

        public Question(int id, int setId, string text, string answer)
        {
            Id = id;

            SetId = setId;

            QuestionTextString = text;

            Answer = answer;
        }

    }
}
