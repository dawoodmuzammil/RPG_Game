using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    class CharacterFactory
    {
        public Character GetCharacter( int choice, int level)
        {
            switch (choice)
            {
                case (1):
                    return new Aladin(level);
                case (2):
                    return new Tarzan(level);
                case (3):
                    return new Spiderman(level);
                case (4):
                    return new Batman(level);
                default:
                    return new Aladin(level);
            }
        }
    }
}
