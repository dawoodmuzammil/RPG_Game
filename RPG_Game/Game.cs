using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace RPG_Game
{
    public class Game
    {        
        // properties
        Player player;
        Player CPU;

        // constructor
        public Game()
        {
            Console.WriteLine("Initializing game. Please wait...");
            Console.Write("Please write your username: ");
            string username = Console.ReadLine();
            bool isValid = InsertPlayer(username);
            do
            {
                Console.Write("\nPlease enter a different username: ");
                username = Console.ReadLine();
                isValid = InsertPlayer(username);

            } while (!isValid);

            player = new Player(username);

            CPU = new Player(RandomNameGenerator());

            Console.WriteLine("Game Set up. You are playing against " + CPU.username);
        }

        public int RandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        public string RandomNameGenerator()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\randomNames.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            int rand = RandomNumber( lines.Count);            

            return lines[rand];
        }

        /*
         * Method to insert a player in the text file
         */
        public bool InsertPlayer( string username)
        {            
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            string str = username + "," + "0";

            if (!IsUsernameTaken(username, lines) || lines.Count == 0) // if username is unique
            {
                lines.Add(str);

                File.WriteAllLines(filepath, lines);
                Console.WriteLine(filepath);
                return true; // player inserted to file
            }
            else
            {
                Console.WriteLine("Username already exists...");
                return false; // player not inserted
            }
        }

        private bool IsUsernameTaken(string username, List<string> allPlayers)
        {
            foreach (string player in allPlayers)
            {
                string name = ""; // empty string to be filled till the first comma
                int i = 0;

                // extract each username
                while (i < player.Length)
                {
                    // check till comma
                    if (player[i] == ',')
                        break;
                    else
                        name += player[i] + "";
                    i++; // increment counter
                }

                // check the name from file with the entered username
                if (name.ToLower().Equals(username.ToLower()))
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteAllPlayers()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
            System.IO.File.WriteAllText(filepath, string.Empty);
        }
    }
}
