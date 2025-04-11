using System;
using FirstQuest;

namespace FirstQuest
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Player myPlayer = new Player();

            Console.WriteLine("Enter your player name:");
            string playerName = Console.ReadLine();

            myPlayer.Name = playerName;
            myPlayer.Health = 100;
            myPlayer.Gold = 0; // Initialize gold to 0

            myPlayer.DisplayPlayerInfo();

            // Add a loop so the game keeps going
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine("\nPress Space to continue or 'Q' to quit.");

                // Wait for the player to press space or 'Q'
                var key = Console.ReadKey(true); // 'true' hides the keypress from the console output

                if (key.Key == ConsoleKey.Spacebar)
                {
                    encounter(myPlayer);  // Continue the encounter if space is pressed
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    gameRunning = false;  // Quit the game if 'Q' is pressed
                    Console.WriteLine("\nYou chose to quit. Goodbye!");
                }
            }
        }

        // Roll dice to determine the outcome of an action
        static int rollDice()
        {
            int diceRoll = rnd.Next(1, 7); // Generates a random number between 1 and 6
            Console.WriteLine($"\nYou rolled a {diceRoll}!");

            return diceRoll;
        }

        static void encounter(Player myPlayer)
        {
            Console.WriteLine("\nYou are exploring the forest...");

            // Roll the dice to determine the encounter
            int encounterRoll = rollDice();

            if (encounterRoll <= 2)
            {
                Console.WriteLine("\nYou encountered a monster!");
            }

            else if (encounterRoll <= 4)
            {
                Console.WriteLine("\nYou found a treasure chest!");
                int treasure = rnd.Next(10, 51); // Random treasure between 10 and 50 gold
                myPlayer.Gold += treasure; // Add treasure to player's gold
            }
            else
            {
                Console.WriteLine("\nYou found a healing potion!");
                myPlayer.Health += 20; // Heal the player by 20 points
                if (myPlayer.Health > 100) myPlayer.Health = 100; // Cap health at 100
            }
        }
    }
}