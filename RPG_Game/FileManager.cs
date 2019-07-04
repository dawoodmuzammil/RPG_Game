using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using Newtonsoft.Json;

namespace RPG_Game
{
    class FileManager
    {
        // properties

        // constructor

        // methods
        /*
         * Method to insert a player in the text file
         */
        //public bool InsertPlayer(string username)
        //{
        //    Console.WriteLine("\nAdding player to database...");
        //    string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";

        //    List<string> lines = File.ReadAllLines(filepath).ToList();
        //    string str = username + "," + "0";

        //    if (!IsUsernameTaken(username, lines) || lines.Count == 0) // if username is unique
        //    {
        //        lines.Add(str);

        //        File.WriteAllLines(filepath, lines);

        //        Console.WriteLine("Player successfully added to database...\n");
        //        return true; // player inserted to file
        //    }
        //    else
        //    {
        //        Console.WriteLine("Username already exists...");
        //        return false; // player not inserted
        //    }
        //}

        ///*
        // * Method to check if the username entered is unique
        // */
        //private bool IsUsernameTaken(string username, List<string> allPlayers)
        //{
        //    Console.WriteLine("Checking username's validity...");
        //    foreach (string player in allPlayers)
        //    {
        //        string name = ""; // empty string to be filled till the first comma
        //        int i = 0;

        //        // extract each username
        //        while (i < player.Length)
        //        {
        //            // check till comma
        //            if (player[i] == ',')
        //                break;
        //            else
        //                name += player[i] + "";
        //            i++; // increment counter
        //        }

        //        // check the name from file with the entered username
        //        if (name.ToLower().Equals(username.ToLower()))
        //        {
        //            return true;
        //        }
        //    }
        //    Console.WriteLine("Username is valid...");
        //    return false;
        //}

        //public void DeleteAllPlayers()
        //{
        //    string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\players.txt";
        //    System.IO.File.WriteAllText(filepath, string.Empty);
        //}
        /*
         * This method saves the created players in the JSON files. The boolean parameter differentiates 
         * the CPU from the user to save different type of players in their respective paths.
         */ 
        public void InsertPlayerJSON( Player player, bool CPU)
        {
            string filepath = "";
            if (CPU)
                filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentCPU.json";
            else
                filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentPlayer.json";
            string strJSON = JsonConvert.SerializeObject(player);
            File.WriteAllText(filepath, strJSON);
        }

        public Player[] LoadPlayerJSON()
        {
            Console.WriteLine("Loading game...");

            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentPlayer.json";
            string jsonOutput = File.ReadAllText(filepath);
            Player player = JsonConvert.DeserializeObject<Player>(jsonOutput);

            string filepathCPU = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentCPU.json";
            string jsonOutputCPU = File.ReadAllText(filepathCPU);
            Player CPU = JsonConvert.DeserializeObject<Player>(jsonOutputCPU);

            Console.WriteLine("Game loaded successfully. Here's the summary.\n");
            Console.WriteLine("Player 1: " + player.username + "\nPoints: " + player.Points+ "\nHealth: " + player.Character.HpValue);
            Console.WriteLine("\nCPU: " + CPU.username + "\nPoints: " + CPU.Points+ "\nHealth: " + CPU.Character.HpValue);
            Player[] playerArr = new Player[2];
            playerArr[0] = player;
            playerArr[1] = CPU;

            return playerArr;


        }
    }
}
