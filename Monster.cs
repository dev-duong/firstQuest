using System;
using System.Security.Cryptography.X509Certificates;
using FirstQuest;

namespace FirstQuest
{
    public class Monster
    {
        static Random rnd = new Random();

        public string Name;
        public int Health;
        public int Damage;

        public static Monster monsterType()
        {
            int monsterRoll = rnd.Next(0, 7);

            string monsterName;
            int monsterHealth;

            if (monsterRoll <= 3)
            {
                Console.WriteLine("It's a Goblin!");
                monsterName = "Goblin";
                monsterHealth = 30;
            }
            else if (monsterRoll <= 5)
            {
                Console.WriteLine("It's a Troll!");
                monsterName = "Troll";
                monsterHealth = 50;
            }
            else
            {
                Console.WriteLine("It's a Dragon!");
                monsterName = "Dragon";
                monsterHealth = 100;
              }

            return new Monster
            {
                Name = monsterName,
                Health = monsterHealth
            };
        }

        public void Attack(Player player)
        {
            int damageRolll = rnd.Next(1, 7); // Generates a random number between 1 and 6
            // Console.WriteLine(damageRolll); // Debug

            if (damageRolll <= 2) Damage = 0;
            else if (Name == "Goblin" && damageRolll <= 5) Damage = rnd.Next(4, 11); // 5 - 10 dmg
            else if (Name == "Goblin" && damageRolll <= 6) Damage = rnd.Next(10, 16); // 10 - 15 dmg (crit)

            else if (Name == "Troll" && damageRolll <= 5) Damage = rnd.Next(14, 21); // 15 - 20 dmg
            else if (Name == "Troll" && damageRolll <= 6) Damage = rnd.Next(20, 26); // 20 - 25 dmg (crit)

            else if (Name == "Dragon" && damageRolll <= 5) Damage = rnd.Next(19, 26); // 20 - 25 dmg
            else if (Name == "Dragon" && damageRolll <= 6) Damage = rnd.Next(25, 31); // 25 - 30 dmg (crit)

            if (damageRolll <= 2) Console.WriteLine($"{Name} missed!");
            else if (damageRolll <= 5) Console.WriteLine($"{Name} attacks {player.Name} for {Damage} damage!");
            else Console.WriteLine($"CRITICAL HIT! {Name} attacks {player.Name} for {Damage} damage!");

            player.TakeDamage(Damage);
        }

         public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }

        public void DisplayMonsterInfo()
        {
            Console.WriteLine($"Monster Name: {Name}");
            Console.WriteLine($"Monster Health: {Health}\n");
        }
    }
}