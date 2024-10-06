using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SimpleDiceGame.model;

namespace SimpleDiceGame.Controllers
{
    internal class DiceManager
    {

        private Dice dice;

        public DiceManager()
        {
            dice = new Dice();
        }

        public int Roll()
        {
            int roll = dice.RollDie(); // Roll the die
            if (roll == 1)
            {
                dice.TurnScore = 0; // Reset turn score if rolled 1
            }
            else
            {
                dice.TurnScore += roll; // Accumulate turn score with the rolled value
            }
            return roll; // Return the rolled number
        }

        public bool Hold()
        {
            // Add TurnScore to TotalScore, maintaining the previous score
            dice.TotalScore += dice.TurnScore;
            dice.TurnScore = 0; // Reset TurnScore after holding

            return dice.TotalScore >= 20; // Return if the player won the game
        }

        public int GetTotalScore()
        {
            return dice.TotalScore;
        }

        public int GetTurnScore()
        {
            return dice.TurnScore;
        }
    }
}
