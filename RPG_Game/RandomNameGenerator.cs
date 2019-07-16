using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public static class RandomNameGenerator
    {
        private static Stack<string> names;

        private static void GetAllNames()
        {
            FileManager fileManager = new FileManager();
            names = fileManager.ReadRandomNames();
        }

        public static string GetOneName()
        {
            return names.Pop();
        }
    }
}
