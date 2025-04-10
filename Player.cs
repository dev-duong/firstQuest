namespace FirstQuest
{
    class Player
    {
        public string Name;
        public int Health;
        public void DisplayPlayerInfo()
        {
            Console.WriteLine($"\nPlayer Name: {Name}");
            Console.WriteLine($"Player Health: {Health}");
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