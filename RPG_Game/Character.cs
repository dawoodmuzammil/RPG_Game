using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public abstract class Character : ICharacter
    {
        // properties        
        private int _HpValue = 100;
        public int HpValue
        {
            get {
                if (_HpValue < 0)
                    return 0;
                return _HpValue;
            }
            set { _HpValue = value; }
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

        private string _charName;
        public string CharName
        {
            get { return _charName; }
            set { _charName = value; }
        }

        public int MaxAttackValue { get; set; }
        public int MaxDefenseValue { get; set; }

        public string[] AttackSkills { get; set; }
        public string[] DefenseSkills { get; set; }

        public void UpdateExpPoints( int Val)
        {
            ExpPoints = Val + ExpPoints;
            //save it in the file
        }

        public int CalculateMaxMoveValue(int level)
        {
            int bestVal = level * 10;
            return bestVal;
        }

        public void UpdateHp( int Val)
        {
            HpValue = Val + HpValue;
        }

        public int GenerateRandomNumber( int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        //public virtual int Attack()
        //{
        //    int attackValue = GenerateRandomNumber(MaxAttackValue);
        //    Console.WriteLine("Attack ---> " + attackValue);
        //    return attackValue;
        //}

        public virtual int Attack(int option)
        {
            int attackvalue = GenerateRandomNumber(MaxAttackValue);
            Console.WriteLine("attack ---> " + attackvalue);
            return attackvalue;
        }
        public virtual int Defend(int enemyAttackValue)
        {
            int defenseValue = GenerateRandomNumber(MaxDefenseValue);
            Console.WriteLine("Defense ---> " + defenseValue);

            return defenseValue;
        }

        public bool IsLost( int CurrentHP)
        {
            if (CurrentHP <= 0)
                return true;
            return false;
        }

        public void SetHP( int level)
        {
            switch(level)
            {
                case (1):
                    _HpValue = 100;
                    break;
                case (2):
                    _HpValue = 90;
                    break;
                case (3):
                    _HpValue = 85;
                    break;
                case (4):
                    _HpValue = 75;
                    break;
                default:
                    break;
            }
        }
    }
}
