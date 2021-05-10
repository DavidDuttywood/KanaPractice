using System.ComponentModel.DataAnnotations;

namespace KanaPractice.Models
{
    public class Question
    {
        [Key]
        public int Id { get; set; }
        public int SetId { get; set; }
        public string QuestionTextString { get; set; }
        public string Answer { get; set; }

        //public Question(int id, int setId, string text, string answer)
        //{
        //    Id = id;

        //    SetId = setId;

        //    QuestionTextString = text;

        //    Answer = answer;
        //}

    }
}
