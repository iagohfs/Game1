using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        List<Room> Rooms; // Store a list of the rooms (Procedural generation maybe?)

        public World()
        {
            Room start = new Room();
            start.AddWall(new Coordinate(0, 0), new Coordinate(10, 0));
            PrintCurrentRoom(start);
        }

        public void PrintCurrentRoom(Room r)
        {
            for(int i = 0; i < r.Grid.GetLength(0); i++)
            {
                for(int j = 0; j < r.Grid.GetLength(1); j++)
                {
                    Console.Write(r.Grid[i, j]);
                }
                Console.WriteLine();
            }
        }
    }
}
