using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Aladin : Character
    {
        public Aladin()
        {
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
        }

        // ATTACK METHODS
        public override int Attack()
        {
            int attackValue = GenerateRandomNumber(MaxAttackValue);
            String SkillOption = AttackSkills[GenerateRandomNumber(2)];
            Console.WriteLine(SkillOption + " implemented . . . ");

            if (SkillOption.ToLower().Equals("geniehelp"))
            {
                attackValue = GenieHelp( attackValue);
                
            }
            else if (SkillOption.ToLower().Equals("powerpunch"))
            {
                attackValue = (int)PowerPunch( attackValue);
            }

            Console.WriteLine("Attack ---> " + attackValue);
            return attackValue;
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
        public override int Defend( int enemyAttackValue)
        {
            int DefendValue = GenerateRandomNumber(MaxAttackValue);
            String SkillOption = AttackSkills[GenerateRandomNumber(1)];
            Console.WriteLine(SkillOption + " implemented . . . ");

            if (SkillOption.ToLower().Equals("duck"))
            {
                DefendValue = Duck(enemyAttackValue);
                Console.WriteLine("Defense ---> " + DefendValue);
                return DefendValue;
            }
            else if (SkillOption.ToLower().Equals("stealpower"))
            {
                StealPower(enemyAttackValue);
            }

            return 0;
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
