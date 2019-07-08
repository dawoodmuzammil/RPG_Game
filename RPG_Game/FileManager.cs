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
            string strJSON = JsonConvert.SerializeObject(player, Formatting.Indented, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects,
                TypeNameAssemblyFormat = System.Runtime.Serialization.Formatters.FormatterAssemblyStyle.Simple
            });

            File.WriteAllText(filepath, strJSON);
        }

        public Player[] LoadPlayerJSON()
        {
            Console.WriteLine("Loading game...");

            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentPlayer.json";
            string jsonOutput = File.ReadAllText(filepath);
            Player player = JsonConvert.DeserializeObject<Player>(jsonOutput, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            string filepathCPU = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentCPU.json";
            string jsonOutputCPU = File.ReadAllText(filepathCPU);
            Player CPU = JsonConvert.DeserializeObject<Player>(jsonOutputCPU, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            Console.WriteLine("Game loaded successfully. Here's the summary.\n");
            Console.WriteLine("Player 1: " + player.Username + "\nPoints: " + player.Points+ "\nHealth: " + player.Character.HpValue + "\nLevel: " + CPU.Character.Level);
            Console.WriteLine("\nCPU: " + CPU.Username + "\nPoints: " + CPU.Points+ "\nHealth: " + CPU.Character.HpValue + "\nLevel: " + CPU.Character.Level);
            Player[] playerArr = new Player[2];
            playerArr[0] = player;
            playerArr[1] = CPU;

            Console.WriteLine();            
            Console.WriteLine("\n*************************************************************************************************\n");

            return playerArr;
        }

        public void DeleteAllPlayers()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentPlayer.json";
            File.WriteAllText(filepath, string.Empty);
            filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\currentCPU.json";
            File.WriteAllText(filepath, string.Empty);
        }
    }
}
