using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace RPG_Game
{
    public class Player
    {
        // properties
        private string usernameProp;
        public string username
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


        private int pointsProp;
        public int Points
        {
            get { return pointsProp; }
            set { pointsProp = value; }
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
            this.pointsProp = 0;
            _character = character;
            _level = 1;
            
        }

        public Player()
        {
            this.usernameProp = "CPU_" + GenerateRandomName();
            this.pointsProp = 0;
            _character = new Aladin(_level);
            _level = 1;
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
        
    }
}
