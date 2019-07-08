using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace RPG_Game
{
    public class Player
    {
        // properties
        private string usernameProp;
        public string Username
        {
            get { return usernameProp; }
            set { usernameProp = value; }
        }

        private int _level;

        public int Level
        {
            get { return _level; }
            set { _level = value; }
        }


        private int _points;
        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        private Character _character;

        public Character Character
        {
            get { return _character; }
            set { _character = value; }
        }

        public int AwardPoints(int remainingHP)
        {
            int pointsAwarded = 0;
            switch (Level)
            {
                case (1):
                    pointsAwarded = 100 + remainingHP;
                    Points += pointsAwarded;
                    break;
                case (2):
                    pointsAwarded = 200 + remainingHP;
                    Points += pointsAwarded;
                    break;
                case (3):
                    pointsAwarded = 300 + remainingHP;
                    Points += pointsAwarded;
                    break;
                case (4):
                    pointsAwarded = 400 + remainingHP;
                    Points += pointsAwarded;
                    break;
                case (5):
                    Console.WriteLine("WOW!!! It seems you are undefeatable. You have successfully finished this game.");
                    Console.WriteLine("\n\nG   A   M   E      O   V   E   R\n\n");
                    Console.WriteLine("Thank you for playing Borda's RPG Game.");
                    Console.WriteLine("\n**********************************************\n");
                    return 0;
                default:
                    break;
            }
            IncrementLevel();
            return pointsAwarded;
        }

        public void IncrementLevel()
        {
            if (Points > 0 && Points < 100)
            {
                return;
            }
            else if (Points > 100 && Points < 250)
            {
                Console.WriteLine("**********************************************");
                Console.WriteLine("LEVEL UP!\nYou have been promoted to Level 2.");
                Console.WriteLine("**********************************************");
                Level = 2;
            }
            else if (Points > 250 && Points < 400)
            {
                Level = 3;
            }
            else if (Points > 400 && Points < 550)
            {
                Level = 4;
            }
            else if (Points > 550 && Points < 750)
            {
                Level = 5;
            }

            Character.SetHP(Level);

            Console.WriteLine("**********************************************");
            Console.WriteLine("LEVEL UP!\nYou have been promoted to Level 2.");
            Console.WriteLine("**********************************************");
        }

    }
}
