using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Spiderman : Character
    {
        public Spiderman( int level)
        {
            MaxAttackValue = CalculateMaxMoveValue( level);
            MaxDefenseValue = CalculateMaxMoveValue( level);
            CharName = "Spider-Man";

            AttackSkills = new string[2] {
                "Web Attack",
                "Spin Cycle"
            };

            DefenseSkills = new string[2] {
                "Disarm",
                "Wall Run"
            };
        }

        // ========================================
        //                  METHODS              //
        // ========================================

        // ------------- ATTACK ----------------//
        public int WebAttack( int curAttackValue)
        {
            int newAttackValue = (int)Math.Round(curAttackValue * 1.8, 0);
            return newAttackValue;
        }

        public int SpinCycle( int curAttackValue)
        {
            int newAttackValue = curAttackValue + RandomNumberGenerator.GenerateRandomNumber(MaxAttackValue);
            return newAttackValue;
        }

        public override int Attack( int option)
        {
            int attackValue = RandomNumberGenerator.GenerateRandomNumber(MaxAttackValue);
            int finalAttackValue = 0;
            switch ( option)
            {
                case (0):
                    finalAttackValue = WebAttack(attackValue);
                    break;
                case (1):
                    finalAttackValue = SpinCycle(attackValue);
                    break;
                default:
                    break;
            }
            return finalAttackValue;
        }



        // ------------- DEFENSE----------------//
        /*
         * Disarms the opponent, meaning the opponent can not inflict any damage 
         */
        public int Disarm( int curAttackValue)
        {
            return curAttackValue/2;
            //return 0;
        }

        public int WallRun( int curAttackValue)
        {
            int defenseVal = RandomNumberGenerator.GenerateRandomNumber(curAttackValue/2);
            return defenseVal;
        }

        public override int Defend( int enemyAttackValue)
        {            
            int finalDefenseValue = 0;
            int option = RandomNumberGenerator.GenerateRandomNumber(2);
            switch (option)
            {
                case (0):
                    finalDefenseValue = Disarm(enemyAttackValue);
                    break;
                case (1):
                    finalDefenseValue = WallRun(enemyAttackValue);
                    break;
                default:
                    break;
            }
            return finalDefenseValue;
        }
    }
}
