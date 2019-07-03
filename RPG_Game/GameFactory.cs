using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace RPG_Game
{
    public class GameFactory
    {        
        // properties
        Player player;
        Player CPU;

        // constructor
        public GameFactory()
        {
            InitializeGame();
        }

        // METHODS

        // ============================================ //
        //              INITIALIZING GAME               //
        // ============================================ //
        public void InitializeGame()
        {
            Console.WriteLine("Initializing game. Please wait...");

            string username = GetUsername(); // get username from user
            Character userCharacter = GetUserCharacter();
            player = new Player(username, userCharacter); // create user's player

            CPU = new Player(GenerateRandomName(), new Aladin()); // create CPU player



            //Console.WriteLine("Game Set up. You are playing against " + CPU.username);
            Console.WriteLine("THE GAME IS SET!!");
            Console.WriteLine(username + " (" + userCharacter.CharName + ")" + " vs. CPU_" + CPU.username  + " (Aladin)\n");

            // start battle
            Battle battle = new Battle( player, CPU);
        }

        /*
         * Method to get username from user
         */
        public string GetUsername()
        {
            Console.Write("Please write your username: ");
            string username = Console.ReadLine();
            bool isValid = InsertPlayer(username);
            
            while ( !isValid) {
                Console.Write("\nPlease enter a different username: ");
                username = Console.ReadLine();
                isValid = InsertPlayer(username);

            } 
            return username;
        }

        /*
         * Method to generate a random number -- to be used in generating a random name for CPU
         */     
        public int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }

        /*
         * Method to generate a random name for CPU
         */
        public string GenerateRandomName()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\randomNames.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            int rand = GenerateRandomNumber( lines.Count);            

            return lines[rand];
        }

        /*
         * Method to insert a player in the text file
         */
        public bool InsertPlayer( string username)
        {
            Console.WriteLine("\nAdding player to database...");
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            string str = username + "," + "0";

            if (!IsUsernameTaken(username, lines) || lines.Count == 0) // if username is unique
            {
                lines.Add(str);

                File.WriteAllLines(filepath, lines);
                
                Console.WriteLine("Player successfully added to database...\n");
                return true; // player inserted to file
            }
            else
            {
                Console.WriteLine("Username already exists...");
                return false; // player not inserted
            }
        }

        /*
         * Method to check if the username entered is unique
         */
        private bool IsUsernameTaken(string username, List<string> allPlayers)
        {
            Console.WriteLine("Checking username's validity...");
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
            Console.WriteLine("Username is valid...");
            return false;
        }

        public void DeleteAllPlayers()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
            System.IO.File.WriteAllText(filepath, string.Empty);
        }

        public Character GetUserCharacter()
        {
            Console.WriteLine("Please character would you like to play with (enter the number 1-4): ");
            Console.WriteLine("1. Aladin\n2. Tarzan\n3. Spider-Man\n4. Batman");
            Console.Write("Your option: ");
            int input = Convert.ToInt32(Console.ReadLine());

            if (input == 1)
            {
                return new Aladin();
            }
            else return null;
            
        }
    }
}
