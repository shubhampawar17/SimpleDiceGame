using SimpleDiceGame.Controllers;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleDiceGame.Presentation
{
    internal class DicePresentation
    {
        private DiceManager manager;
        private string playerName;

        public DicePresentation()
        {
            manager = new DiceManager();
            GetPlayerName();
        }

        private void GetPlayerName()
        {
            Console.WriteLine("Enter your name:");
            playerName = Console.ReadLine();
            Console.WriteLine($"Welcome {playerName} to the Dice Game !!");
        }

        public void RunGame()
        {
            while (!manager.IsGameWon())
            {
                PlayTurn();
            }
            DisplayWinMessage(manager.GetTotalScore());
        }

        public void DisplayCurrentScores(int turnScore)
        {
            // Now we only display the current (turn) score
            Console.WriteLine($"Current Score: {turnScore}");
        }

        public string GetUserChoice()
        {
            Console.WriteLine("Enter 'r' to roll or 'h' to hold ");
            return Console.ReadLine().ToLower();
        }

        public void DisplayRollResult(int roll)
        {
            Console.WriteLine($"You rolled: {roll}");
            if (roll == 1)
            {
                Console.WriteLine("You rolled a 1! No points this turn.");
            }
        }

        public void DisplayHoldMessage(int totalScore)
        {
            // After holding, we display the total score and not the turn score
            Console.WriteLine($"You held! Your Total Score is {totalScore}");
        }

        public void DisplayWinMessage(int totalScore)
        {
            Console.WriteLine($"Congrats! You reached {totalScore} and won!");
        }

        public void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input! Please enter 'r' to roll or 'h' to hold.");
        }

        private void PlayTurn()
        {
            bool turnActive = true;

            while (turnActive)
            {
                string choice = GetUserChoice();

                if (choice == "r")
                {
                    int roll = manager.Roll();
                    DisplayRollResult(roll);  // Print the roll result first
                    DisplayCurrentScores(manager.GetTurnScore()); // Then print the current turn score

                    if (roll == 1)
                    {
                        turnActive = false; // End turn if a 1 is rolled
                    }
                }
                else if (choice == "h")
                {
                    manager.Hold();
                    DisplayWinMessage(manager.GetTotalScore()); // Show total score after holding
                    turnActive = false;  // End this turn
                }
                else
                {
                    DisplayInvalidInputMessage();
                }
            }
        }
    }
    
}
