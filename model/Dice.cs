using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiceGame.model
{
    public class Dice
    {
        private Random random;

        public int TotalScore { get; set; }
        public int TurnScore { get; set; }

        public Dice()
        {
            random = new Random();
            TotalScore = 0;
            TurnScore = 0;
        }

        public int RollDie()
        {
            return random.Next(1, 7);
        }
    }
}

