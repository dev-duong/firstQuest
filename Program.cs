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

            GameManager.welcome();
            GameManager.userName(myPlayer);

            myPlayer.Health = 100;
            myPlayer.Gold = 0;

            myPlayer.DisplayPlayerInfo();
            GameManager.continueGamme(myPlayer);
        }
    }
}