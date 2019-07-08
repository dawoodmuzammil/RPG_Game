using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public static class RandomNumberGenerator
    {
        public static int GenerateRandomNumber(int max)
        {
            Random random = new Random();
            return random.Next(0, max);
        }
    }
}
