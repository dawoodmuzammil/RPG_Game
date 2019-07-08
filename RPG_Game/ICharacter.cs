﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    interface ICharacter
    {
        // methods
        int Defend(int enemyattackvalue);
        int Attack(int option);
        int CalculateMaxMoveValue( int Level);  
    }
}
