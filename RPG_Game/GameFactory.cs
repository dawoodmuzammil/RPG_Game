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
            fileManager.InsertPlayerJSON( player);

            CPU = new Player(); // create CPU player



            //Console.WriteLine("Game Set up. You are playing against " + CPU.username);
            Console.WriteLine("THE GAME IS SET!!");
            Console.WriteLine(username + " (" + userCharacter.CharName + ")" + " vs. " + CPU.username  + " (Aladin)\n");

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
            //bool isValid = fileManager.InsertPlayer(username);
            
            //while ( !isValid) {
            //    Console.Write("\nPlease enter a different username: ");
            //    username = Console.ReadLine();
            //    isValid = fileManager.InsertPlayer(username);

            //}
            
            return username;
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
