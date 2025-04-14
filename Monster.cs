using System;
using FirstQuest;

namespace FirstQuest
{
    public class Monster
    {
        static Random rnd = new Random();

        public string Name { get; set; }
        public int Health { get; set; }
        public int Damage { get; set; }

        public Monster(string name, int health, int damage)
        {
            Name = name;
            Health = health;
            Damage = damage;
        }

        public void Attack(Player player)
        {
            Console.WriteLine($"{Name} attacks {player.Name} for {Damage} damage!");
            player.TakeDamage(Damage);
        }

        public void DisplayMonsterInfo()
        {
            Console.WriteLine($"Monster Name: {Name}");
            Console.WriteLine($"Monster Health: {Health}\n");
        }
    }
}