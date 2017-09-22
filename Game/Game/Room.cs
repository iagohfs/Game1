using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room
    {
        private int SizeX = 10;
        private int SizeY = 20;

        public Room()
        {
            char[,] room = new char[SizeX, SizeY];

        }

        // Something to store the entities in the current room
        // Ordered list. Keep the player at the lowest index and iterate backwards, to draw the player last.
    }
}
