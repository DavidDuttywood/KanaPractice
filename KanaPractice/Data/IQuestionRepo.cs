using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public interface IQuestionRepo
    {
        List<Question> GetAllQuestions();
    }
}
