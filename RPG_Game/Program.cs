using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {           
            GameFactory game = new GameFactory();
            game.ShowMainMenu();
            Console.ReadLine();
        }
    }
}
