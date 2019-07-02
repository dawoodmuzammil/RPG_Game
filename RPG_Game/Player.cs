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
        
        private int pointsProp;
        public int Points
        {
            get { return pointsProp; }
            set { pointsProp = value; }
        }

        //private string filepathProp = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
        //public string filepath { get; private set; }



        // constructor
        public Player( string username)
        {
            this.usernameProp = username;
            this.pointsProp = 0;            
        }

        // methods        
        public void InsertPlayer()
        {
            string username = this.username;
            int points = this.Points;
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            string str = username + "," + points;

            if (IsUsernameTaken(username, lines))
            {
                lines.Add(str);

                if (File.Exists(filepath))
                {
                    Console.WriteLine("FILE FOUND");
                }
                File.WriteAllLines(filepath, lines);
                Console.WriteLine(filepath);
            }
            else
                Console.WriteLine("Username already exists...");
        }

        public bool IsUsernameTaken( string username, List<string> allPlayers)
        {
            foreach (string player in allPlayers)
            {
                string name = ""; // empty string to be filled till the first comma
                int i = 0;

                // extract each username
                while ( i < username.Length)
                {
                    // check till comma
                    if ( username[i] == ',')                    
                        break;                    
                    else                    
                        name += username[i];                    
                    i++; // increment counter
                }
                
                // check the name from file with the entered username
                if ( name.Equals(username)) {                    
                    return false;
                }
            }
            return true;
        }

        public void DeleteAllPlayers()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
            System.IO.File.WriteAllText(filepath, string.Empty);
        }
    }
}
