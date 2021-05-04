using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KanaPractice.Models
{
    public class GameOverViewModel
    {
        public int Score { get; set; }

        public GameOverViewModel(int score)
        {
            this.Score = score;
        }
    }
}
