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
                    encounter(myPlayer, gameRunning);  // Continue the encounter if space is pressed
                }
                else if (key.Key == ConsoleKey.Q)
                {
                    gameRunning = false;  // Quit the game if 'Q' is pressed
                    Console.WriteLine("\nYou chose to quit. Goodbye!");
                }
                
                if (myPlayer.Health <= 0)
                {
                    Console.WriteLine("\nYou have been defeated! Game Over.");
                    gameRunning = false; // End the game if player is defeated
                }
                else if (myPlayer.Gold >= 500) // Check if player has enough gold to win
                {
                    Console.WriteLine("\nCongratulations! You have collected enough gold to win the game!");
                    gameRunning = false; // End the game if player wins
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

        static void encounter(Player myPlayer, bool gameRunning)
        {
            Console.WriteLine("\nYou are exploring the forest...");

            // Roll the dice to determine the encounter
            int encounterRoll = rollDice();

            if (encounterRoll <= 3)
            {
                bool inCombat = true; // Set combat flag to true
                Console.WriteLine("\nYou encountered a monster!");
                Monster monster = new Monster("Goblin", 50, 10); // Create a new monster

                attackMonster(monster, myPlayer, inCombat, gameRunning); // Attack the monster
            }

            else if (encounterRoll <= 5)
            {
                Console.WriteLine("\nYou found a treasure chest!");
                int treasure = rnd.Next(10, 51); // Random treasure between 10 and 50 gold
                myPlayer.Gold += treasure; // Add treasure to player's gold
                Console.WriteLine($"You found {treasure} gold!");
            }
            else
            {
                Console.WriteLine("\nYou found a healing potion!");
                myPlayer.Health += 20; // Heal the player by 20 points
                if (myPlayer.Health > 100) myPlayer.Health = 100; // Cap health at 100
            }

            // Display player info after the encounter
            myPlayer.DisplayPlayerInfo();   
        }

        static void attackMonster(Monster monster, Player myPlayer, bool inCombat, bool gameRunning)
        {
            while (inCombat == true)
            {
                Console.WriteLine($"\nYou attack the {monster.Name}!");
                monster.Health -= rnd.Next(5, 21); // Player attacks monster for 20 damage

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"\nYou defeated the {monster.Name}!");
                    myPlayer.Gold += 20; // Reward player with gold for defeating the monster
                }
                else
                {
                    monster.Attack(myPlayer); // Monster attacks back
                }
                // Display player and monster info after the attack 
                myPlayer.DisplayPlayerInfo();
                monster.DisplayMonsterInfo();

                if (myPlayer.Health <= 0)
                {
                    Console.WriteLine("\nYou have been defeated! Game Over.");
                    inCombat = false; // End combat if player is defeated
                    gameRunning = false; // End the game
                }
                else if (monster.Health <= 0)
                {
                    Console.WriteLine($"\nYou have defeated the {monster.Name}! You can continue exploring.");
                    inCombat = false; // End combat if monster is defeated
                }
                else
                {
                    Console.WriteLine("\nPress Space to continue fighting or 'Q' to flee.");
                    var key = Console.ReadKey(true); // 'true' hides the keypress from the console output

                    if (key.Key == ConsoleKey.Q)
                    {
                        Console.WriteLine("\nYou chose to flee from the battle!");
                        inCombat = false; // End combat if player flees
                    }
                    else if (key.Key == ConsoleKey.Spacebar)
                    {
                        Console.WriteLine("\nYou chose to continue fighting!");
                        // Continue the loop for the next round of combat
                    }
                }

            }
        }
    }
}