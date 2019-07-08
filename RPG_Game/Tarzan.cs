using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Tarzan : Character
    {
        public Tarzan(int level)
        {
            MaxAttackValue = CalculateMaxMoveValue(level);
            MaxDefenseValue = CalculateMaxMoveValue(level);
            CharName = "Tarzan";

            AttackSkills = new string[2] {
                "Flying Kick",
                "Great Ape"
            };

            DefenseSkills = new string[2] {
                "Eavesdrop",
                "Cover"
            };
        }

        // ========================================
        //                  METHODS              //
        // ========================================

        // ------------- ATTACK ----------------//
        public int FlyingKick(int curAttackValue)
        {
            int newAttackValue = (int)Math.Round(curAttackValue * 1.8, 0);
            return newAttackValue;
        }

        public int GreatApe(int curAttackValue)
        {
            int newAttackValue = curAttackValue + GenerateRandomNumber(MaxAttackValue);
            return newAttackValue;
        }

        public override int Attack(int option)
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            int finalAttackValue = 0;
            switch (option)
            {
                case (0):
                    finalAttackValue = FlyingKick(attackValue);
                    break;
                case (1):
                    finalAttackValue = GreatApe(attackValue);
                    break;
                default:
                    break;
            }
            return finalAttackValue;
        }



        // ------------- DEFENSE----------------//
        /*
         * Eavesdrops the opponent, meaning the opponent can not inflict any damage and reverses the attack
         */
        public int Eavesdrop(int curAttackValue)
        {
            int random = GenerateRandomNumber(curAttackValue);
            int heal = (random / 2) * -1;
            Console.WriteLine("Attack was reversed by the HEAL defense move. Defender's HP is now increased by " + heal + "HP.");
            return heal;
            //return 0;
        }

        public int Cover(int curAttackValue)
        {
            int defenseVal = GenerateRandomNumber(curAttackValue / 2);
            return defenseVal;
        }

        public override int Defend(int enemyAttackValue)
        {

            int finalDefenseValue = 0;
            int option = GenerateRandomNumber(2);
            switch (option)
            {
                case (0):
                    finalDefenseValue = Eavesdrop(enemyAttackValue);
                    break;
                case (1):
                    finalDefenseValue = Cover(enemyAttackValue);
                    break;
                default:
                    break;
            }
            return finalDefenseValue;
        }
    }
}
