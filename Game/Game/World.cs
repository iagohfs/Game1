using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        

        public World()
        {
            List<Room> Rooms = new List<Room>();
            Room start = new Room();
            Character player = new Character();
            Rooms.Add(start);
            DrawCurrentRoom(start);
        }

        public void DrawCurrentRoom(Room r)
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
