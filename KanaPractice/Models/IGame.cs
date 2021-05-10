namespace KanaPractice.Models
{
    public interface IGame
    {
        QuestionViewModel GetNextQuestion(int questionSet);

        bool Validate(string correctAnswer, string chosenAnswer);

    }
}
