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
        public override int Attack(int option)
        {
            int attackValue = RandomNumberGenerator.GenerateRandomNumber(MaxAttackValue);
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
            return curAttackValue + RandomNumberGenerator.GenerateRandomNumber(10);
        }



        // ------------- DEFENSE ----------------//
        public override int Defend(int enemyAttackValue)
        {
            int finalDefenseValue = 0;
            int option = RandomNumberGenerator.GenerateRandomNumber(2);
            switch (option)
            {
                case (0):
                    finalDefenseValue = Duck(enemyAttackValue / 2);
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

        public int StealPower( int curAttackValue)
        {
            return -(curAttackValue * 2);          
        }
        
    }
}
