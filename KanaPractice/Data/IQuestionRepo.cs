using System.Collections.Generic;

namespace KanaPractice.Models
{
    public interface IQuestionRepo
    {
        List<Question> GetAllQuestions();
        List<Question> GetAllQuestionsBySetID(int setId);

    }
}
