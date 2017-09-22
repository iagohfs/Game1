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
            int Startx = 1, Starty = 1;
            List<Room> Rooms = new List<Room>();
            Room start = new Room();
            Character player = new Character('@', new Coordinate(Startx, Starty));
            start.AddRoomEntity(player);
            Rooms.Add(start);

            do
            {
                Console.Clear();
                start.DrawRoomEntities();
                DrawCurrentRoom(start);

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        {
                            if (start.Grid[player.Location.posX, player.Location.posY - 1] != '#')
                            {
                                player.MoveY(-1);

                            }
                            break;
                        }

                    case ConsoleKey.A:
                        if (start.Grid[player.Location.posX - 1, player.Location.posY] != '#')
                        {
                            player.MoveX(-1);

                        }
                        break;
                    case ConsoleKey.S:
                        if (start.Grid[player.Location.posX, player.Location.posY + 1] != '#')
                        {
                            player.MoveY(1);

                        }
                        break;
                    case ConsoleKey.D:
                        if (start.Grid[player.Location.posX + 1, player.Location.posY] != '#')
                        {
                            player.MoveX(1);

                        }
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
        }
    }
}
