using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Battle
    {
        // properties
        FileManager fileManager;
        
        public Battle( Player p1, Player p2)
        {
            fileManager = new FileManager();
            Fight( p1, p2);
        }

        // constructor
        public void Fight( Player p1, Player p2)
        {
            int turnTemp = GenerateRandomNumber(1);
            bool turn = true;
            if (turnTemp == 1)
                turn = false;
            while (p1.Character.HpValue > 0)
            {
                PrintTurnStatus(p1, p2, turn);
                if (turn)
                {
                    turn = !turn;
                    AttackByUser(p1, p2);
                    
                }
                else
                {
                    turn = !turn;
                    AttackByCPU(p1, p2);
                }
                fileManager.InsertPlayerJSON(p1, false);
                fileManager.InsertPlayerJSON(p2, true);

            }

            //Console.WriteLine("HEALTH VALUE ---> " + p1.Character.HpValue);
        }

        public void AttackByUser( Player p1, Player p2)
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("0. Forfeit Match");

            Console.Write("\nYour option: ");
            int input = Convert.ToInt32(Console.ReadLine()); ;

            if ( input == 1)
            {
                Console.WriteLine(p1.Character.AttackSkills[0]);
                Console.WriteLine(p1.Character.AttackSkills[1]);
                int attackValue = p1.Character.Attack();
                int defenseValue = p2.Character.Defend(attackValue);
                int effectiveness = attackValue - defenseValue;

                p2.Character.HpValue -= effectiveness;
                Console.WriteLine("=====================");
                Console.WriteLine("===== HP STATUS =====");
                Console.WriteLine("=====================");
                
                Console.WriteLine(p1.username + " ---> " + p1.Character.HpValue);
                Console.WriteLine(p2.username + " ---> " + p2.Character.HpValue);

                if (p2.Character.IsLost(p2.Character.HpValue)) // checking if CPU's HP is less than 0
                {
                    Spawn(p1);
                }

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

        // method where CPU attacks the player
        public void AttackByCPU( Player p1, Player p2)
        {
            int attackValue = p2.Character.Attack();
            int defenseValue = p1.Character.Defend(attackValue);
            int effectiveness = attackValue - defenseValue;

            p1.Character.HpValue -= effectiveness;
            Console.WriteLine("====================");
            Console.WriteLine("==== HP STATUS =====");
            Console.WriteLine("====================");

            Console.WriteLine(p1.username + " ---> " + p1.Character.HpValue);
            Console.WriteLine(p2.username + " ---> " + p2.Character.HpValue);

            if (p1.Character.IsLost(p1.Character.HpValue)) // checking if CPU's HP is less than 0
            {
                Console.WriteLine("G A M E  O V E R");
            }
        }

        

        public void Spawn(Player p1)
        {
            Player spawnedPlayer = new Player(); // create CPU player
            Fight( p1, spawnedPlayer);
        }


        // ==================== //
        // MISCELANEOUS METHODS //
        // ==================== //
        public void PrintTurnStatus( Player p1, Player p2, bool turn)
        {
            if ( turn)
                Console.WriteLine( "\nIt's your turn. Please select your next move.");
            else
                Console.WriteLine("\nWaiting for " + p2.username + " to make his move...");
        }

        public int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        //
    }
}
