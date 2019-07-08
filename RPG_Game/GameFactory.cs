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
        FileManager fileManager;

        // constructor
        public GameFactory()
        {
            fileManager = new FileManager();
            ShowMainMenu();
        }

        // METHODS

        // ============================================ //
        //              INITIALIZING GAME               //
        // ============================================ //
        public void InitializeNewGame()
        {

            Console.WriteLine("Initializing new game. Please wait...");

            string username = GetUsername(); // get username from user
            Character userCharacter = GetUserCharacter();
            player = new Player(username, userCharacter); // create user's player
            fileManager.InsertPlayerJSON(player, false);

            CPU = new Player( player.Level); // create CPU player
            fileManager.InsertPlayerJSON(CPU, true);

            //Console.WriteLine("Game Set up. You are playing against " + CPU.username);
            Console.WriteLine("THE GAME IS SET!!");
            Console.WriteLine(username + " (" + userCharacter.CharName + ")" + " vs. " + CPU.Username + " (Aladin)\n");

            // start battle
            Battle battle = new Battle( player, CPU);
        }

        public void ShowMainMenu()
        {

            int input;
            do
            {
                Console.WriteLine("Welcome to Borda RPG Game.\nPlease select one of the options below:\n\n1. New Game\n2. Load Game\n3. Quit Game\n");
                Console.Write("Your choice: ");
                input = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine();

                switch(input)
                {
                    case (1):
                        InitializeNewGame();
                        break;
                    case (2):
                        LoadGame();
                        break;
                    case (3):
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please enter your desired option again.\n");
                        break;
                }
            } while (input != 3);


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


        public Character GetUserCharacter()
        {
            int input = 0;
            do
            {
                Console.WriteLine("Please character would you like to play with (enter the number 1-4): ");
                Console.WriteLine("1. Aladin\n2. Tarzan\n3. Spider-Man\n4. Batman");
                Console.Write("Your option: ");
                input = Convert.ToInt32(Console.ReadLine());

                switch (input)
                {
                    case (1):
                        return new Aladin(1);
                    case (2):
                        return new Aladin(1);
                    case (3):
                        return new Spiderman(1);
                    case (4):
                        return new Aladin(1);
                    default:
                        Console.WriteLine("\nInvalid selection...\n");
                        continue;
                }
            
            } while (input != 1 && input != 2 && input != 3 && input != 4);
            return new Aladin(1);
        }

        
    }
}
