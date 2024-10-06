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
            Console.WriteLine($"Welcome {playerName} to the Dice Game !!\n");
        }

        public void RunGame()
        {
            bool isGameWon = false;

            while (!isGameWon)  // Keep running until game is won
            {
                isGameWon = PlayTurn();
            }

            DisplayWinMessage(manager.GetTotalScore()); // Display win message only when the game is won
        }

        public void DisplayCurrentScores(int turnScore)
        {
            // Now we only display the current (turn) score
            Console.WriteLine($"Current Score: {turnScore}\n");
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
            if (totalScore >= 20)
            {
                Console.WriteLine($"Congrats! You reached {totalScore} and won!");
            }
        }

        public void DisplayInvalidInputMessage()
        {
            Console.WriteLine("Invalid input! Please enter 'r' to roll or 'h' to hold.");
        }

        private bool PlayTurn()
        {
            bool turnActive = true;

            while (turnActive)
            {
                string choice = GetUserChoice();

                if (choice == "r")
                {
                    int roll = manager.Roll();
                    DisplayRollResult(roll);
                    DisplayCurrentScores(manager.GetTurnScore());

                    if (roll == 1)
                    {
                        turnActive = false;  // End turn if 1 is rolled
                    }
                }
                else if (choice == "h")
                {
                    bool isGameWon = manager.Hold();  // Check if the game is won after holding
                    DisplayHoldMessage(manager.GetTotalScore());

                    if (isGameWon)
                    {
                        return true;  // If the game is won, stop further turns
                    }

                    turnActive = false;  // End turn after holding
                }
                else
                {
                    DisplayInvalidInputMessage();
                }
            }

            return false;  // Return false if game is not won yet
        }

    }
}
