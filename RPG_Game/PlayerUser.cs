using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    public class PlayerUser : Player
    {
        public PlayerUser(string username, Character character)
        {
            Username = username;
            Points = 0;
            Character = character;
            Level = 1;
        }        
    }
}
