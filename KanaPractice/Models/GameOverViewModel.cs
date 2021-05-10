namespace KanaPractice.Models
{
    public class GameOverViewModel
    {
        public int Score { get; set; }

        public GameOverViewModel(int score)
        {
            Score = score;
        }
    }
}
