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
            Character player = new Character('@', new Coordinate(1, 1));
            start.AddRoomEntity(player);
            Rooms.Add(start);
            do
            {
                Console.Clear();
                DrawCurrentRoom(start);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        player.MoveUp(1);
                        break;
                    case ConsoleKey.A:
                        player.MoveRight(-1);
                        break;
                    case ConsoleKey.S:
                        player.MoveUp(-1);
                        break;
                    case ConsoleKey.D:
                        player.MoveRight(1);
                        break;
                }
            } while (player.IsAlive);
            
        }

        public void DrawCurrentRoom(Room r)
        {
            for (int i = 0; i < r.Grid.GetLength(0); i++)
            {
                for (int j = 0; j < r.Grid.GetLength(1); j++)
                {
                    Console.Write(r.Grid[i, j]);
                }
                Console.WriteLine();
            }

            r.DrawRoomEntities();
        }
    }
}
