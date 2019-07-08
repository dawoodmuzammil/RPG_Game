using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Batman : Character
    {
        public Batman(int level)
        {
            MaxAttackValue = CalculateMaxMoveValue(level);
            MaxDefenseValue = CalculateMaxMoveValue(level);
            CharName = "Batman";

            AttackSkills = new string[2] {
                "Summon Bats",
                "Batarang"
            };

            DefenseSkills = new string[2] {
                "Heal",
                "Roll Escape"
            };
        }

        // ========================================
        //                  METHODS              //
        // ========================================

        // ------------- ATTACK ----------------//
        public int SummonBats(int curAttackValue)
        {
            int newAttackValue = (int)Math.Round(curAttackValue * 1.8, 0);
            return newAttackValue;
        }

        public int Batarang(int curAttackValue)
        {
            int newAttackValue = curAttackValue + RandomNumberGenerator.GenerateRandomNumber(MaxAttackValue);
            return newAttackValue;
        }

        public override int Attack(int option)
        {
            int attackValue = RandomNumberGenerator.GenerateRandomNumber(MaxAttackValue);
            int finalAttackValue = 0;
            switch (option)
            {
                case (0):
                    finalAttackValue = SummonBats(attackValue);
                    break;
                case (1):
                    finalAttackValue = Batarang(attackValue);
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
        public int Heal(int curAttackValue)
        {
            int random = RandomNumberGenerator.GenerateRandomNumber(curAttackValue);
            int heal = (random / 2);
            return heal;
            //return 0;
        }

        public int RollEscape(int curAttackValue)
        {
            int defenseVal = RandomNumberGenerator.GenerateRandomNumber(curAttackValue / 2);
            return defenseVal;
        }

        public override int Defend(int enemyAttackValue)
        {

            int finalDefenseValue = 0;
            int option = RandomNumberGenerator.GenerateRandomNumber(2);
            switch (option)
            {
                case (0):
                    finalDefenseValue = Heal(enemyAttackValue);
                    break;
                case (1):
                    finalDefenseValue = RollEscape(enemyAttackValue);
                    break;
                default:
                    break;
            }
            return finalDefenseValue;
        }
    }
}
