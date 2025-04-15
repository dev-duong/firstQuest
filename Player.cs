using System;
using FirstQuest;

namespace FirstQuest
{
    public class Player
    {
        public string Name;
        public int Health;
        public int Gold;

        static Random rnd = new Random();


        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nPlayer Name: {Name}");
            Console.WriteLine($"Player Health: {Health}");
            Console.WriteLine($"Player Gold: {Gold}\n");
        }

        static int rollDice()
        {
            int diceRoll = rnd.Next(0, 7); // Generates a random number between 1 and 6
            Console.WriteLine($"\nYou rolled a {diceRoll}!");

            return diceRoll;
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void attackMonster(Monster monster, Player myPlayer)

        {
            bool inCombat = true; // Set combat flag to true

            while (inCombat == true)
            {
                int attackRoll = rollDice(); // Roll the dice to determine the attack outcome

                if (attackRoll <= 2) Console.WriteLine("You missed your attack!");
                else if (attackRoll <= 5)
                {
                    Console.WriteLine("You hit the monster for 10 damage!");
                    monster.Health -= 10; 
                }
                else
                {
                    Console.WriteLine("CRITICAL HIT! You hit the monster for 20 damage!");
                    monster.Health -= 20; // Player attacks monster for 20 damage
                }

                if (monster.Health <= 0)
                {
                    monster.Health = 0; // Cap monster health at 0
                    Console.WriteLine($"You defeated the {monster.Name}!");

                    if (monster.Name == "Goblin")
                    {
                        myPlayer.Gold += 10;
                        Console.WriteLine($"You received 10 gold!");
                    }
                    else if (monster.Name == "Troll")
                    {
                        myPlayer.Gold += 20;
                        Console.WriteLine($"You received 20 gold!");
                    }
                    else
                    {
                        myPlayer.Gold += 50;
                        Console.WriteLine($"You received 50 gold!");
                    }

                    inCombat = false; // End combat if monster is defeated
                }
                else
                {
                    monster.Attack(myPlayer); // Monster attacks back
                    if (myPlayer.Health <= 0) inCombat = false;
                }

                // Display player and monster info after the attack 
                myPlayer.DisplayPlayerInfo();
                monster.DisplayMonsterInfo();

                // add divider line for better readability
                Console.WriteLine(new string('-', 40) + "\n");

                Console.WriteLine("Press Space to continue fighting or 'Q' to flee.");
                var key = Console.ReadKey(true); // 'true' hides the keypress from the console output
                Console.WriteLine("\n" + new string('-', 40));

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