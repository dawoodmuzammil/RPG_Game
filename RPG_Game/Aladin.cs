using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Aladin : Character
    {
        //public int HpValue { get; set; }
        //public int MaxAttackValue { get; set; }
        //public int MaxDefenseValue { get; set; }
        //public int ExpPoints { get; set; }
        //public int Level { get; set; }
        private string[] AttackSkills;
        private string[] DefenseSkills;


        public Aladin()
        {
            //Character aladin = new Character();
            //CharaMaxAttackValue = CalculateMaxMoveValue(Level);
            //MaxDefenseValue = CalculateMaxMoveValue(Level);
            MaxAttackValue = CalculateMaxMoveValue( Level);
            MaxDefenseValue = CalculateMaxMoveValue( Level);
            CharName = "Aladin";

            AttackSkills = new string[2] {            
                "genieHelp",
                "powerPunch"
            };

            DefenseSkills = new string[2] {
                "stealPower",
                "duck"
            };

            Console.WriteLine("--- Creation of ALADIN successful. ---");
        }

        //public int CalculateMaxMoveValue( int Level)
        //{
        //    int bestVal = Level * 10;
        //    return bestVal;
        //}


        // ATTACK METHODS
        public override void Attack()
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            String SkillOption = AttackSkills[GenerateRandomNumber(1)];
            Console.WriteLine(SkillOption + " implemented . . . ");

            if (SkillOption.ToLower().Equals("geniehelp"))
            {
                attackValue = GenieHelp( attackValue);
                this.HpValue -= attackValue;
            }
            else if (SkillOption.ToLower().Equals("powerpunch"))
            {
                attackValue = (int)PowerPunch( attackValue);
                this.HpValue -= attackValue;
            }

            Console.WriteLine("Attack ---> " + attackValue);
        }

        public double PowerPunch(int curAttackValue)
        {
            return curAttackValue * 1.5;
        }

        public int GenieHelp( int curAttackValue)
        {
            return curAttackValue + GenerateRandomNumber(10);
        }



        // DEFENSE METHODS
        public override void Defend( int enemyAttackValue)
        {
            int DefendValue = GenerateRandomNumber(MaxAttackValue);
            String SkillOption = AttackSkills[GenerateRandomNumber(1)];
            Console.WriteLine(SkillOption + " implemented . . . ");

            if (SkillOption.ToLower().Equals("duck"))
            {
                DefendValue = Duck(enemyAttackValue);
            }
            else if (SkillOption.ToLower().Equals("stealpower"))
            {
                StealPower(enemyAttackValue);
            }

            Console.WriteLine("Defense ---> " + DefendValue);
        }

        public int Duck( int curAttackValue)
        {
            return curAttackValue;
        }

        public void StealPower( int curAttackValue)
        {
            this.HpValue += curAttackValue;           
        }

        public void attack()
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            int rand = GenerateRandomNumber(1);
            if ( rand == 0)            
                PowerPunch( attackValue);            
            else


            Console.WriteLine("attack ---> " + attackValue);
        }
        

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
