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
        private Player user;
        private Player CPU;
        CharacterFactory characterFactory;
        private FileManager fileManager;
        private const int INITIAL_LEVEL = 1;
        private Stack<string> names;

        // constructor
        public GameFactory()
        {
            characterFactory = new CharacterFactory();
            fileManager = FileManager.getInstance();            
        }

        // METHODS

        // ============================================ //
        //              INITIALIZING GAME               //
        // ============================================ //
        public void ShowMainMenu()
        {
            int input;
            do
            {
                Console.WriteLine("Welcome to Borda RPG Game.\nPlease select one of the options below:\n\n1. New Game\n2. Load Game\n3. Quit Game\n");
                Console.Write("Your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch (input)
                {
                    case (1):
                        InitializeNewGame();
                        break;
                    case (2):
                        LoadGame();
                        break;
                    case (3):
                        Console.WriteLine("\nThank you for playing Borda's RPG game. Hope to see you soon...\n");
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter your desired option again.\n");
                        break;
                }
            } while (input != 3);
        }


        public void InitializeNewGame()
        {

            Console.WriteLine("Initializing new game. Please wait...");

            string username = GetUsername(); // get username from user
            int userCharacterChoice = GetUserCharacterChoice(); // get user choice            
            Character userCharacter = characterFactory.GetCharacter(userCharacterChoice, INITIAL_LEVEL); // create user character
            user = new PlayerUser(username, userCharacter); // create user's player
           
            CPU = new PlayerCPU(user.Level); // create CPU player            

            // save players
            SaveGame(user, CPU);

            // start battle
            Battle battle = new Battle(user, CPU);
        }

        

        public void SaveGame(Player user, Player CPU)
        {
            fileManager.InsertPlayerJSON(user);
            fileManager.InsertPlayerJSON(CPU);

        }

        public void LoadGame()
        {
            Player[] arr = fileManager.LoadPlayerJSON(); // load both player
            
            Battle battle = new Battle(arr[0], arr[1]);
        }

        /*
         * Method to get username from user
         */
        public string GetUsername()
        {
            Console.Write("Please write your username: ");
            string username = Console.ReadLine();
            
            return username;
        }


        public int GetUserCharacterChoice()
        {
            int input = 0;
            do
            {
                Console.WriteLine("\nPlease character would you like to play with (enter the number 1-4): ");
                Console.WriteLine("1. Aladin\n2. Tarzan\n3. Spider-Man\n4. Batman");
                Console.Write("\nYour option: ");
                input = Convert.ToInt32(Console.ReadLine());
                //Console.Clear();

                return input;
            
            } while (input != 1 && input != 2 && input != 3 && input != 4);
            
        }

        
    }
}
