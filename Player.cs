namespace FirstQuest
{
    public class Player
    {
        public string Name;
        public int Health;
        public int Gold;
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nPlayer Name: {Name}");
            Console.WriteLine($"Player Health: {Health}");
            Console.WriteLine($"Player Gold: {Gold}\n");
        }

        public void TakeDamage(int damage)
        {
            Health -= damage;
            if (Health < 0)
            {
                Health = 0;
            }
        }
    }
}