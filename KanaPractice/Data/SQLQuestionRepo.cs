using System.Collections.Generic;
using System.Linq;

namespace KanaPractice.Models
{
    public class SQLQuestionRepo : IQuestionRepo
    {
        private readonly AppDbContext _context;

        public SQLQuestionRepo(AppDbContext context)
        {
            _context = context;
        }
        public List<Question> GetAllQuestions()
        {
            return _context.Questions.ToList();
        }

        public List<Question> GetAllQuestionsBySetID(int setId)
        {
            return _context.Questions.Where(q => q.SetId == setId).ToList();
        }
    }
}
