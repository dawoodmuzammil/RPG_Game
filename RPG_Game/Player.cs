using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RPG_Game
{
    public class Player
    {
        // properties
        private string usernameProp;
        public string Username
        {
            get { return usernameProp; }
            set { usernameProp = value; }
        }

        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }


        private int _points;
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private Character _character;

        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }


        //private string filepathProp = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
        //public string filepath { get; private set; }



        // constructor
        public Player( string username, Character character)
        {          
            this.usernameProp = username;
            _points = 0;
            _character = character;
            _level = 1;
            
        }

        [JsonConstructor]
        public Player(int UserLevel)
        {
            this.usernameProp = "CPU_" + GenerateRandomName();
            _points = 0;
            _level = UserLevel;

            // select User's character
            int characterChoice = GenerateRandomNumber(4);
            Console.WriteLine(characterChoice);
            
            switch( characterChoice)
            {
                case (1):
                    _character = new Aladin(_level);
                    break;
                case (2):
                    _character = new Tarzan(_level);
                    break;
                case (3):
                    _character = new Spiderman(_level);
                    break;
                case (4):
                    _character = new Batman(_level);
                    break;
            }
        }

        

        // methods
        public int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        public string GenerateRandomName()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\randomNames.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            int rand = GenerateRandomNumber(lines.Count);

            return lines[rand];
        }

        public int AwardPoints( int remainingHP)
        {
            int pointsAwarded = 0;
            switch (_level)
            {
                case (1):
                    pointsAwarded = 100 + remainingHP;
                    _points += pointsAwarded;
                    break;
                case (2):
                    pointsAwarded = 200 + remainingHP;
                    _points += pointsAwarded;
                    break;
                case (3):
                    pointsAwarded = 300 + remainingHP;
                    _points += pointsAwarded;
                    break;
                case (4):
                    pointsAwarded = 400 + remainingHP;
                    _points += pointsAwarded;
                    break;
                case (5):
                    Console.WriteLine("WOW!!! It seems you are undefeatable. You have successfully finished this game.");
                    Console.WriteLine("\n\nG   A   M   E      O   V   E   R\n\n");
                    Console.WriteLine("Thank you for playing Borda's RPG Game.");
                    Console.WriteLine("\n**********************************************\n");
                    return 0;
                default:
                    break;
            }
            IncrementLevel();
            return pointsAwarded;
        }

        public void IncrementLevel()
        {
            if ( _points > 0 && _points < 100)
            {
                return;
            }
            else if (_points > 100 && _points < 250)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("LEVEL UP!\nYou have been promoted to Level 2.");
                Console.WriteLine("**********************************************");
                _level = 2;                                
            }
            else if (_points > 250 && _points < 400)
            {
                _level = 3;
            }
            else if (_points > 400 && _points < 550)
            {
                _level = 4;
            }
            else if (_points > 550 && _points < 750)
            {
                _level = 5;
            }

            _character.SetHP(_level);

            Console.WriteLine("**********************************************");
            Console.WriteLine("LEVEL UP!\nYou have been promoted to Level 2.");
            Console.WriteLine("**********************************************");
        }
        
    }
}
