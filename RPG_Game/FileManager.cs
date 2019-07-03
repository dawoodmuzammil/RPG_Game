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

        public void InsertPlayerJSON( Player player)
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentPlayer.json";
            string strJSON = JsonConvert.SerializeObject(player);
            File.WriteAllText(filepath, strJSON);
        }
    }
}
