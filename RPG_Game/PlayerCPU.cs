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
        private Stack<string> names;
        
        public PlayerCPU(int UserLevel)
        {
            fileManager = new FileManager();

            names = fileManager.ReadRandomNames();
            
            Username = "CPU_" + names.Pop(); // pop a name from the stack
            Points = 0;
            Level = UserLevel;

            // select User's character
            int characterChoice = RandomNumberGenerator.GenerateRandomNumber(4) + 1;

            switch (characterChoice)
            {
                case (1):
                    Character = new Aladin(Level);
                    break;
                case (2):
                    Character = new Tarzan(Level);
                    break;
                case (3):
                    Character = new Spiderman(Level);
                    break;
                case (4):
                    Character = new Batman(Level);
                    break;
            }
        }

        public string GenerateRandomName()
        {
            string filepath = @"E:\Dawood\Borda Internship\Tasks\Task 1\RPG_Game\RPG_Game\randomNames.txt";

            List<string> lines = File.ReadAllLines(filepath).ToList();
            int rand = RandomNumberGenerator.GenerateRandomNumber(lines.Count);

            return lines[rand];
        }
    }
}
