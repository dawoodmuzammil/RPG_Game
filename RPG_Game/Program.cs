using System;

namespace RPG_Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Aladin warrior = new Aladin();
            Console.WriteLine(warrior.HpValue);
            Console.WriteLine(warrior.Level);
            Console.WriteLine(warrior.MaxAttackValue);
            Console.WriteLine(warrior.MaxDefenseValue);
            warrior.Attack();
            warrior.Defend();

            Console.ReadLine();
        }
    }
}
