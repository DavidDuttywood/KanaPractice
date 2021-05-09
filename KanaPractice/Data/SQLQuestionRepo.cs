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
            return context.Questions.ToList();
        }

        public List<Question> GetAllQuestionsBySetID(int setId)
        {
            return context.Questions.Where(q => q.SetId == setId).ToList();
        }
    }
}
