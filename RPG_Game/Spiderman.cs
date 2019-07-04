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
                "webAttack",
                "spinCycle"
            };

            DefenseSkills = new string[2] {
                "disarm",
                "wellRun"
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
            int newAttackValue = curAttackValue + GenerateRandomNumber(MaxAttackValue);
            return newAttackValue;
        }

        public override int Attack( int option)
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            int finalAttackValue = 0;
            switch ( option)
            {
                case (1):
                    finalAttackValue = WebAttack(attackValue);
                    break;
                case (2):
                    finalAttackValue = SpinCycle(attackValue);
                    break;
                default:
                    break;
            }
            return finalAttackValue;
        }



        // ------------- DEFENSE----------------//

    }
}
