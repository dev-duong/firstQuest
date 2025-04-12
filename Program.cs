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

        static void welcome()
        {
            Console.WriteLine("Welcome to First Quest!");
            Console.WriteLine("Roll the dice and try your chances!");
            Console.WriteLine("The goal is to reach 500 gold! Goodluck.\n");
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

            if (encounterRoll <= 2)
            {
                bool inCombat = true; // Set combat flag to true
                Console.WriteLine("\nYou encountered a monster!");

                attackMonster(monsterType(), myPlayer, inCombat, gameRunning); // Attack the monster
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
                int healAmount = rnd.Next(19, 101); // Amount to heal

                myPlayer.Health += healAmount; // Heal the player by 20 points
                if (myPlayer.Health > 100)
                {
                    myPlayer.Health = 100; // Cap health at 100
                    healAmount = 0;
                }
                Console.WriteLine($"You healed for {healAmount} health points!");

            }

            // Display player info after the encounter
            myPlayer.DisplayPlayerInfo();   
                            // add divider line for better readability
                Console.WriteLine(new string('-', 40));
        }

        static Monster monsterType()
        {
            int monsterRoll = rollDice();

            string monsterName;
            int monsterHealth;
            int monsterDamage;

            if (monsterRoll <= 3)
            {
                monsterName = "Goblin";
                monsterHealth = 30;
                monsterDamage = rnd.Next(4, 16);
            }
            else if (monsterRoll <= 5)
            {
                monsterName = "Troll";
                monsterHealth = 50;
                monsterDamage = rnd.Next(9, 21);
            }
            else
            {
                monsterName = "Dragon";
                monsterHealth = 100;
                monsterDamage = rnd.Next(14, 26);
            }

            Monster monster = new Monster(monsterName, monsterHealth, monsterDamage);

            return monster;
        }

        static void attackMonster(Monster monster, Player myPlayer, bool inCombat, bool gameRunning)
        {
            while (inCombat == true)
            {
                int attackRoll = rollDice(); // Roll the dice to determine the attack outcome
                if (attackRoll <= 2)
                {
                    Console.WriteLine("\nYou missed your attack!");
                }
                else if (attackRoll <= 5)
                {
                    Console.WriteLine("\nYou hit the monster for 10 damage!");
                    monster.Health -= 10; // Player attacks monster for 10 damage
                }
                else
                {
                    Console.WriteLine("\nCritical hit! You hit the monster for 20 damage!");
                    monster.Health -= 20; // Player attacks monster for 20 damage
                }

                if (monster.Health <= 0)
                {
                    monster.Health = 0; // Cap monster health at 0
                    Console.WriteLine($"\nYou defeated the {monster.Name}!");
                    myPlayer.Gold += 20; // Reward player with gold for defeating the monster
                    Console.WriteLine($"You received 20 gold!");
                    inCombat = false; // End combat if monster is defeated
                }
                else
                {
                    monster.Attack(myPlayer); // Monster attacks back
                }



                // Display player and monster info after the attack 
                myPlayer.DisplayPlayerInfo();
                monster.DisplayMonsterInfo();

                // add divider line for better readability
                Console.WriteLine(new string('-', 40));

                Console.WriteLine("\nPress Space to continue fighting or 'Q' to flee.");
                var key = Console.ReadKey(true); // 'true' hides the keypress from the console output

                if (key.Key == ConsoleKey.Q)
                {
                    Console.WriteLine("\nYou chose to flee from the battle!");
                    inCombat = false; // End combat if player flees
                }
                else if (key.Key == ConsoleKey.Spacebar && inCombat == true)
                {
                    Console.WriteLine("\nYou chose to continue fighting!");
                    // Continue the loop for the next round of combat
                }
            }
        }
    }
}