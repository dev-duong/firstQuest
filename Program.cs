using System;
using FirstQuest;

namespace FirstQuest
{
    class Program
    {
        static void Main(string[] args)
        {
            Player myPlayer = new Player();

            Console.WriteLine("Enter your player name:");
            string playerName = Console.ReadLine();

            myPlayer.Name = playerName;
            myPlayer.Health = 100;

            myPlayer.DisplayPlayerInfo();
            rollDice();
        }

        Random rnd = new Random();

    }
}