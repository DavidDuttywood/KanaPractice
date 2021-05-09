using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class SQLQuestionRepo : IQuestionRepo
    {
        private readonly AppDbContext context;

        public SQLQuestionRepo(AppDbContext context)
        {
            this.context = context;
        }
        public List<Question> GetAllQuestions()
        {
            var check = context.Questions;
            return new List<Question>();
        }

        public List<Question> GetAllQuestionsBySetID(int setId)
        {
            throw new NotImplementedException();
        }
    }
}
