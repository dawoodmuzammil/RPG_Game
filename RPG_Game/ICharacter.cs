using System;
using System.Collections.Generic;
using System.Text;

namespace RPG_Game
{
    interface ICharacter
    {    
        // methods
        int Defend( int enemyAttackValue);        
        int Attack();
        int CalculateMaxMoveValue( int Level);  
    }
}
