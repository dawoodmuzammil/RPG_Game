using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class Character : ICharacter
    {
        // properties        
        private int HpVal = 100;
        public int HpValue
        {
            get { return HpVal = 100; }
            set { HpVal = value; }
        }

        private int LevelVal = 1;
        public int Level
        {
            get { return LevelVal = 1; }
            set { LevelVal = value; }
        }

        private int ExpVal = 0;
        public int ExpPoints
        {
            get { return ExpVal = 0; }
            set { ExpVal = value; }
        }

        public int MaxAttackValue { get; set; }
        public int MaxDefenseValue { get; set; }

        public Character()
        {
            this.HpValue = 100;
            this.Level = 1;
            this.ExpPoints = 0;

        }
        public void UpdateExpPoints( int Val)
        {
            ExpPoints = Val + ExpPoints;
            //save it in the file
        }

        public virtual int CalculateMaxMoveValue(int Level)
        {
            int bestVal = Level * 10;
            return bestVal;
        }

        public void UpdateHp( int Val)
        {
            HpValue = Val + HpValue;
        }

        public int RandomNumber( int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        public virtual void Attack()
        {
            int AttackValue = RandomNumber(MaxAttackValue);
            Console.WriteLine("Attack ---> " + AttackValue);
        }
        public void Defend()
        {
            int DefenseValue = RandomNumber(MaxDefenseValue);
            Console.WriteLine("Defense ---> " + DefenseValue);
        }

        public bool IsLost( int CurrentHP)
        {
            if (CurrentHP <= 0)
                return true;
            return false;
        }
    }
}
