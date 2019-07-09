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
        private const string FILEPATH_PLAYER = @"../../../currentPlayer.json";
        private const string FILEPATH_CPU = @"../../../currentCPU.json";
        

        // methods

        /*
         * This method saves the created players in the JSON files. The boolean parameter differentiates 
         * the CPU from the user to save different type of players in their respective paths.
         */ 
        public void InsertPlayerJSON( Player player)
        {
            
            string filepath = "";            
            if (player is PlayerCPU)
                filepath = FILEPATH_CPU;
            else if ( player is PlayerUser)
                filepath = FILEPATH_PLAYER;
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

            // deserialize player info
            string jsonOutput = File.ReadAllText(FILEPATH_PLAYER);
            Player user = JsonConvert.DeserializeObject<Player>(jsonOutput, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            // deserialize CPU info
            string jsonOutputCPU = File.ReadAllText(FILEPATH_CPU);
            Player CPU = JsonConvert.DeserializeObject<Player>(jsonOutputCPU, new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.Objects
            });

            // print info
            GameLoadSuccessMessage(user, CPU);

            // populate array and return the players to start battle
            Player[] playerArr = new Player[2];
            playerArr[0] = user;
            playerArr[1] = CPU;            

            return playerArr;
        }

        public void GameLoadSuccessMessage( Player user, Player CPU)
        {
            Console.WriteLine("Game loaded successfully. Here's the summary.\n");
            Console.WriteLine("Player 1: " + user.Username + "\nPoints: " + user.Points + "\nHealth: " + user.Character.HpValue + "\nLevel: " + user.Character.Level);
            Console.WriteLine("\nCPU: " + CPU.Username + "\nPoints: " + CPU.Points + "\nHealth: " + CPU.Character.HpValue + "\nLevel: " + CPU.Character.Level);

            Console.WriteLine();
            Console.WriteLine("\n*************************************************************************************************\n");
        }

        public void DeleteAllPlayers()
        {
            File.WriteAllText(FILEPATH_PLAYER, string.Empty);            
            File.WriteAllText(FILEPATH_CPU, string.Empty);
        }
    }
}
