using System;
using System.Collections.Generic;
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
        public void Hold()
        {
            dice.TotalScore = dice.TurnScore; // Only set TotalScore to the current TurnScore
            dice.TurnScore = 0; // Reset TurnScore after holding
        }
        public bool IsGameWon()
        {
            return dice.TotalScore >= 20;
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

