using System;
using System.Runtime.InteropServices;
using FirstQuest;

namespace FirstQuest
{
    class Program
    {
        static Random rnd = new Random();
        static void Main(string[] args)
        {
            Player myPlayer = new Player();

            welcome();
            userName(myPlayer);

            myPlayer.Health = 100;
            myPlayer.Gold = 0; // Initialize gold to 0

            myPlayer.DisplayPlayerInfo();

            continueGamme(myPlayer);
            
        }

        static void welcome()
        {
            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("\nWelcome to First Quest!");
            Console.WriteLine("Roll the dice and try your chances!");
            Console.WriteLine("The goal is to reach 500 gold! Goodluck.");
            Console.WriteLine("\n" + new string('-', 40));
        }

        static void userName(Player myPlayer)
        {
            Console.Write("\nEnter your player name: ");
            string? playerName = Console.ReadLine();
            myPlayer.Name = playerName;
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
            Console.WriteLine("\n" + new string('-', 40));
            Console.WriteLine("\nYou are exploring the forest...");

            // Roll the dice to determine the encounter
            int encounterRoll = rollDice();

            if (encounterRoll <= 2)
            {
                Console.WriteLine("You encountered a monster!");

                Monster monster = Monster.monsterType();
                myPlayer.attackMonster(monster, myPlayer);
            }

            else if (encounterRoll <= 5)
            {
                Console.WriteLine("You found a treasure chest!");
                int treasure = rnd.Next(10, 51); // Random treasure between 10 and 50 gold
                myPlayer.Gold += treasure; // Add treasure to player's gold
                Console.WriteLine($"You found {treasure} gold!");
            }
            else
            {
                Console.WriteLine("You found a healing potion!");
                int healAmount = rnd.Next(19, 101); // Amount to heal

                myPlayer.Health += healAmount; // Heal the player by 20 points
                if (myPlayer.Health >= 100)
                {
                    myPlayer.Health = 100; // Cap health at 100
                    healAmount = 0;
                }
                Console.WriteLine($"You healed for {healAmount} health points!");

            }

            // Display player info after the encounter
            myPlayer.DisplayPlayerInfo();
        }

        static void continueGamme(Player myPlayer)
        {
            // Add a loop so the game keeps going
            bool gameRunning = true;

            while (gameRunning)
            {
                Console.WriteLine(new string('-', 40));

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
                    Console.WriteLine("You chose to quit. Goodbye!");
                }

                if (myPlayer.Health <= 0)
                {
                    Console.WriteLine("You have been defeated! Game Over.");
                    gameRunning = false; // End the game if player is defeated
                }
                else if (myPlayer.Gold >= 500) // Check if player has enough gold to win
                {
                    Console.WriteLine("Congratulations! You have collected enough gold to win the game!");
                    gameRunning = false; // End the game if player wins
                }
            }
        }

    }
}