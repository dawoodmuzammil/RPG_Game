using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Battle
    {
        // properties
        public Battle( Player p1, Player p2)
        {
            StartFight( p1, p2);
        }

        // constructor
        public void StartFight( Player p1, Player p2)
        {
            int turnTemp = GenerateRandomNumber(1);
            bool turn = true;
            if (turnTemp == 1)
                turn = false;
            PrintTurnStatus(p1, p2, turn);

            //Console.WriteLine("HEALTH VALUE ---> " + p1.Character.HpValue);
            GetMoveOption(p1, p2);
        }

        public void GetMoveOption( Player p1, Player p2)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("0. Forfeit Match");

            Console.Write("\nYour option: ");
            int input = Convert.ToInt32(Console.ReadLine()); ;

            if ( input == 1)
            {
                int attackValue = p1.Character.Attack();
                int defenseValue = p2.Character.Defend(attackValue);
                int effectiveness = attackValue - defenseValue;

                p2.Character.HpValue -= effectiveness;
                Console.WriteLine("====================");
                Console.WriteLine("==== HP STATUS =====");
                Console.WriteLine("====================");
                
                Console.WriteLine(p1.username + " ---> " + p1.Character.HpValue);
                Console.WriteLine(p2.username + " ---> " + p2.Character.HpValue);

            }
            else if ( input == 0)
            {
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }


        // ==================== //
        // MISCELANEOUS METHODS //
        // ==================== //
        public void PrintTurnStatus( Player p1, Player p2, bool turn)
        {
            if ( turn)
                Console.WriteLine( p1.username + "'s turn...");
            else
                Console.WriteLine("CPU_" + p2.username + "'s turn...\n");
        }

        public int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        //
    }
}
