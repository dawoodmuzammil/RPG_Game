﻿using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    interface ICharacter
    {    
        // methods
        void Attack();
        void Defend();        
        int CalculateMaxMoveValue( int Level);  
    }
}
