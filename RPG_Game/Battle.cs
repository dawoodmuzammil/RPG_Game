using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Battle
    {
        // properties
        FileManager fileManager;

        // constructor
        public Battle( Player p1, Player p2)
        {
            fileManager = new FileManager();
            fileManager.InsertPlayerJSON(p1);
            fileManager.InsertPlayerJSON(p2);
           
            Console.WriteLine("THE BATTLE IS SET!!");
            Console.WriteLine(p1.Username+ " (" + p1.Character.CharName + ")" + " vs. " + p2.Username + " (" + p2.Character.CharName + ")\n");

            Fight( p1, p2);
        }

        
        public void Fight( Player p1, Player p2)
        {
            int turnTemp = RandomNumberGenerator.GenerateRandomNumber(1);
            bool turn = true;
            if (turnTemp == 1)
                turn = false;
            while (p1.Character.HpValue > 0)
            {
                PrintTurnStatus(p1, p2, turn);
                if (turn)
                {
                    turn = !turn;
                    //AttackByUser(p1, p2);
                    Attack(p1, p2);
                    
                }
                else
                {
                    turn = !turn;
                    //AttackByCPU(p1, p2);
                    Attack(p2, p1);
                }
                fileManager.InsertPlayerJSON(p1);
                fileManager.InsertPlayerJSON(p2);

            }
        }

        public void Attack(Player attacker, Player defender)
        {
            int attackChoice = 0;
            int attackMove = 0;
            int damage = 0;

            if (attacker is PlayerCPU)
            {
                attackMove = RandomNumberGenerator.GenerateRandomNumber(2);
                damage = CalculateDamage(attacker, defender, attackMove);
            }
            else if (attacker is PlayerUser)
            {
                // ask if user wishes to attack or forfeit game
                attackChoice = GetAttackChoice();

                // user entered an invalid input
                while (attackChoice != 1 && attackChoice != 9)
                {
                    Console.WriteLine("\nInvalid selection. Please try again.\n");
                    attackChoice = GetAttackChoice();
                }

                // user selects to attack
                if ( attackChoice == 1)
                {
                    // get input
                    DisplayAttackMoves(attacker);
                    attackMove = GetAttackMove();

                    // ask again if input invalid
                    while ( attackMove < 1 || attackMove > 2)
                    {
                        Console.WriteLine("\nInvalid selection. Please try again.\n");
                        DisplayAttackMoves(attacker);
                        attackMove = GetAttackMove();
                    }
                    // attack
                    damage = CalculateDamage(attacker, defender, attackChoice);
                }
            }

            // this will be applied to all players
            Console.Clear();

            //DisplayMoveReport(option, attackValue, defenseValue, effectiveness, p1, p2);

            defender.Character.HpValue -= damage; // decrease CPU's HP            

            PrintHPStatus(attacker, defender); // print hp status

            CheckForDefeat(defender, attacker);
        }

        public void CheckForDefeat( Player defender, Player attacker)
        {            
            if ( defender.Character.IsLost())
            {
                if ( defender is PlayerCPU)
                {
                    PrintRoundWinMessage(attacker);
                    Spawn(attacker, attacker.Level);
                }
                else
                {
                    GameOver();
                }

            }
        }

        public void GameOver()
        {
            Console.WriteLine("\n\nG   A   M   E      O   V   E   R\n\n"); // display message
            fileManager.DeleteAllPlayers(); // clear JSON files
        }

        public int CalculateDamage( Player attacker, Player defender, int attackMove)
        {
            int attackValue = attacker.Character.Attack(attackMove);
            int defenseValue = defender.Character.Defend(attackValue);

            return (attackValue - defenseValue);
        }

        public int GetAttackChoice()
        {
            Console.WriteLine("1. Attack");
            Console.WriteLine("0. Forfeit Match");

            Console.Write("\nYour option: ");
            int input = Convert.ToInt32(Console.ReadLine()); // user enters choice 

            return input;
        }

        public void DisplayAttackMoves(Player attacker)
        {
            Console.WriteLine("\nWhich move would you like to hit your opponent with?");

            Console.WriteLine("1. " + attacker.Character.AttackSkills[0]);
            Console.WriteLine("2. " + attacker.Character.AttackSkills[1]);
            Console.Write("\nYour option: ");
        }

        public int GetAttackMove()
        {
            int input = Convert.ToInt32(Console.ReadLine()); // user enters choice 

            return input;
        }

        //public void AttackByUser( Player p1, Player p2)
        //{
            
        //    int input = 0;
        //    do
        //    {
        //        // Display options 
        //        Console.WriteLine("1. Attack");
        //        Console.WriteLine("0. Forfeit Match");

        //        Console.Write("\nYour option: ");
        //        input = Convert.ToInt32(Console.ReadLine()); // user enters choice 

        //        // user decides to attack
        //        if (input == 1)
        //        {
        //            Console.WriteLine("\nWhich move would you like to hit your opponent with?");

        //            int option = 0;
        //            // ask user for whih move he wishes to play
        //            do
        //            {
        //                // display skills
        //                Console.WriteLine("1. " + p1.Character.AttackSkills[0]);
        //                Console.WriteLine("2. " + p1.Character.AttackSkills[1]);
        //                Console.Write("\nYour option: ");
        //                option = Convert.ToInt32(Console.ReadLine()) - 1; // ask for input

        //                if (option != 1 && option != 2)
        //                    Console.WriteLine("Invalid choice. Please enter again...\n");

        //            } while (option == 1 && option == 2);

        //            // calculate effectiveness of attack
        //            int attackValue = p1.Character.Attack(option);
        //            int defenseValue = p2.Character.Defend(attackValue);
        //            int effectiveness = attackValue - defenseValue;

        //            Console.Clear();

        //            DisplayMoveReport(option, attackValue, defenseValue, effectiveness, p1, p2);

        //            p2.Character.HpValue -= effectiveness; // decrease CPU's HP

        //            PrintHPStatus(p1, p2); // print hp status

        //            if (p2.Character.IsLost(p2.Character.HpValue)) // checking if CPU's HP is less than 0
        //            {

        //                PrintRoundWinMessage(p1);
        //                Spawn(p1, p1.Level);
        //            }
        //        }
        //        else if (input == 0)
        //        {
        //            Console.WriteLine("\n\n************************* G A M E  O V E R *************************\nThank you for playung Borda's RPG Game.\n");
        //            Environment.Exit(0);
        //        }
        //        else
        //        {
        //            Console.WriteLine("\nInvalid choice. Please try again.\n");
        //        }
        //    } while (input != 1 && input != 0);
        //}

        public void PrintRoundWinMessage(Player user)
        {
            Console.WriteLine("\n\nCONGRATULATIONS. You have won this round. You have earned " + user.AwardPoints(user.Character.HpValue) + " points.");
            Console.WriteLine("You will now be put into the battlefield with a tougher opponent. Your HP is now set to " + user.Character.HpValue + "\n\n");
        }

        public void PrintHPStatus(Player user, Player CPU)
        {
            Console.WriteLine();
            Indent("====================");
            Indent("==== HP STATUS =====");
            Indent("====================");

            Indent(user.Username + " ---> " + user.Character.HpValue);
            Indent(CPU.Username + " ---> " + CPU.Character.HpValue);
        }

        // method where CPU attacks the player
        //public void AttackByCPU( Player p1, Player p2)
        //{        
        //    int attackOption = RandomNumberGenerator.GenerateRandomNumber(2);
        //    int attackValue = p2.Character.Attack( attackOption);
        //    int defenseValue = p1.Character.Defend(attackValue);
        //    int effectiveness = attackValue - defenseValue;

        //    DisplayMoveReport(attackOption, attackValue, defenseValue, effectiveness, p2, p1);

        //    p1.Character.HpValue -= effectiveness;

        //    PrintHPStatus( p1, p2);

        //    // check if the user has lost... Game over if true
        //    if (p1.Character.IsLost(p1.Character.HpValue)) // checking if CPU's HP is less than 0
        //    {
        //        Console.WriteLine("\n\nG   A   M   E      O   V   E   R\n\n"); // display message
        //        fileManager.DeleteAllPlayers(); // clear JSON files
        //    }
        //}


        public void Spawn(Player p1, int level)
        {
            Player spawnedPlayer = new PlayerCPU( level); // create CPU player            
            Battle battle = new Battle(p1, spawnedPlayer);  
        }


        // ==================== //
        // MISCELANEOUS METHODS //
        // ==================== //
        public void PrintTurnStatus( Player p1, Player p2, bool turn)
        {
            if (turn)
            {
                Console.WriteLine("\n*************************************************************************************************\n");
                Console.WriteLine("It's your turn. Please select your next move.");
            }
            else
            {
                Console.WriteLine("\n*************************************************************************************************\n");
                Console.WriteLine("Waiting for " + p2.Username + " to make his move...\n");
            }
        }

        static void Indent(string message)
        {
            Console.WriteLine(message.PadLeft(message.Length + 0));
        }

        public void DisplayMoveReport( int attackMove, int attack, int defense, int effectiveness, Player attacker, Player defender)
        {
            Console.WriteLine(attacker.Username + "'s move of " + attacker.Character.AttackSkills[attackMove].ToUpper() + " generated an attack power of " + attack + "HP.");
            Console.WriteLine(defender.Username + " defended " + defense + "HP of it.");           
        }
    }
}
