using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Aladin : Character, ICharacter
    {
        //public int HpValue { get; set; }
        //public int MaxAttackValue { get; set; }
        //public int MaxDefenseValue { get; set; }
        //public int ExpPoints { get; set; }
        //public int Level { get; set; }


        public Aladin()
        {
            Character aladin = new Character();
            //CharaMaxAttackValue = CalculateMaxMoveValue(Level);
            //MaxDefenseValue = CalculateMaxMoveValue(Level);
            MaxAttackValue = CalculateMaxMoveValue( aladin.Level);
            MaxDefenseValue = CalculateMaxMoveValue(aladin.Level);
            
            Console.WriteLine("--- Creation of ALADIN successful.");
        }

        public int CalculateMaxMoveValue( int Level)
        {
            int bestVal = Level * 10;
            return bestVal;
        }

        public void Attack() {
            int AttackValue = RandomNumber( MaxAttackValue);
            Console.WriteLine("Attack ---> " + AttackValue);
        }
        public void Defend() {
            int DefenseValue = RandomNumber(MaxDefenseValue);
            Console.WriteLine("Defense ---> " + DefenseValue);
        }
        //public void Attack() { };
    }
}
