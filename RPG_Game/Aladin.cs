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
        string[] AttackSkills;
        string[] DefenseSkills;

        public Aladin()
        {
            Character aladin = new Character();
            //CharaMaxAttackValue = CalculateMaxMoveValue(Level);
            //MaxDefenseValue = CalculateMaxMoveValue(Level);
            MaxAttackValue = CalculateMaxMoveValue( aladin.Level);
            MaxDefenseValue = CalculateMaxMoveValue(aladin.Level);

            AttackSkills = new string[2] {            
                "genieHelp",
                "powerPunch"
            };

            DefenseSkills = new string[2] {
                "stealPower",
                "duck"
            };

            Console.WriteLine("--- Creation of ALADIN successful.");
        }

        public int CalculateMaxMoveValue( int Level)
        {
            int bestVal = Level * 10;
            return bestVal;
        }


        // ATTACK METHODS
        public double PowerPunch(int CurAttackValue)
        {
            return CurAttackValue * 1.5;
        }

        public int GenieHelp( int CurAttackValue)
        {
            return CurAttackValue + RandomNumber(10);
        }

        public override void Attack()
        {
            int AttackValue = RandomNumber(MaxAttackValue);
            String SkillOption = AttackSkills[RandomNumber(1)];
            Console.WriteLine(SkillOption + " implemented . . . ");
            
            if ( SkillOption.ToLower().Equals("geniehelp"))
            {
                AttackValue = GenieHelp(AttackValue);
            }
            else if (SkillOption.ToLower().Equals("powerpunch")) {
                AttackValue = (int) PowerPunch(AttackValue);
            }

            Console.WriteLine("Attack ---> " + AttackValue);
        }

        // DEFENSE METHODS
        public int Duck( int CurAttackValue)
        {
            return 0;
        }

        public void StealPower( int CurAttackValue)
        {
            this.HpValue += CurAttackValue;           
        }

        //public void Attack() {
        //    int AttackValue = RandomNumber( MaxAttackValue);
        //    Console.WriteLine("Attack ---> " + AttackValue);
        //}
        //public void Defend() {
        //    int DefenseValue = RandomNumber(MaxDefenseValue);
        //    Console.WriteLine("Defense ---> " + DefenseValue);
        //}
        //public void Attack() { };
    }
}
