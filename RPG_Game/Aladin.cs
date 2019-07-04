using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Aladin : Character
    {
        public Aladin(int level)
        {
            MaxAttackValue = CalculateMaxMoveValue(level);
            MaxDefenseValue = CalculateMaxMoveValue(level);
            CharName = "Aladin";

            AttackSkills = new string[2] {
                "Genie Help",
                "Power Punch"
            };

            DefenseSkills = new string[2] {
                "Duck",
                "Steal Power"
            };
        }
        // ========================================
        //                  METHODS              //
        // ========================================

        // ------------- ATTACK ----------------//
        //public override int Attack()
        //{
        //    int attackValue = GenerateRandomNumber(MaxAttackValue);
        //    String SkillOption = AttackSkills[GenerateRandomNumber(2)];
        //    Console.WriteLine(SkillOption + " implemented . . . ");

        //    if (SkillOption.ToLower().Equals("geniehelp"))
        //    {
        //        attackValue = GenieHelp( attackValue);
                
        //    }
        //    else if (SkillOption.ToLower().Equals("powerpunch"))
        //    {
        //        attackValue = (int)PowerPunch( attackValue);
        //    }

        //    Console.WriteLine("Attack ---> " + attackValue);
        //    return attackValue;
        //}

        public override int Attack(int option)
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            int finalAttackValue = 0;
            switch (option)
            {
                case (1):
                    finalAttackValue = GenieHelp(attackValue);
                    break;
                case (2):
                    finalAttackValue = (int) Math.Round(PowerPunch(attackValue), 0);
                    break;
                default:
                    break;
            }
            return finalAttackValue;
        }

        public double PowerPunch(int curAttackValue)
        {
            return curAttackValue * 1.5;
        }

        public int GenieHelp( int curAttackValue)
        {
            return curAttackValue + GenerateRandomNumber(10);
        }



        // ------------- DEFENSE ----------------//
        public override int Defend(int enemyAttackValue)
        {
            int finalDefenseValue = 0;
            int option = GenerateRandomNumber(2);
            switch (option)
            {
                case (0):
                    finalDefenseValue = Duck(enemyAttackValue);
                    break;
                case (1):
                    StealPower(enemyAttackValue);
                    break;
                default:
                    break;
            }
            return finalDefenseValue;
        }

        public int Duck( int curAttackValue)
        {
            return curAttackValue;
        }

        public void StealPower( int curAttackValue)
        {
            this.HpValue += curAttackValue;           
        }

        //public void attack()
        //{
        //    int attackValue = GenerateRandomNumber(MaxAttackValue);
        //    int rand = GenerateRandomNumber(1);
        //    if ( rand == 0)            
        //        PowerPunch( attackValue);            
        //    else


        //    Console.WriteLine("attack ---> " + attackValue);
        //}
        

        // DISPLAY METHODS
        public void DisplayAttackMoves()
        {
            for (int i = 0; i < AttackSkills.Length; i++)
            {
                Console.WriteLine( i);
            }
        }
    }
}
