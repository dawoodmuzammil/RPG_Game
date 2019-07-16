using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace RPG_Game
{
    public class PlayerCPU : Player
    {
        private FileManager fileManager;
        //private Stack<string> names;
        private CharacterFactory characterFactory;
        
        public PlayerCPU(int UserLevel)
        {
            fileManager = FileManager.getInstance();
            characterFactory = new CharacterFactory();

            //names = fileManager.ReadRandomNames();
            
            Username = "CPU_" + fileManager.GetCPUName(); // pop a name from the stack
            Points = 0; // initial points are set to 0 for every new player
            Level = UserLevel; // Level of CPU player will be the same as that of the user

            // select User's character
            int characterChoice = RandomNumberGenerator.GenerateRandomNumber(4) + 1;
            Character = characterFactory.GetCharacter(characterChoice, Level);
        }
    }
}
