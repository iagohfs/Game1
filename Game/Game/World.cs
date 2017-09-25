using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        /// <summary>
        /// The room that the player is currently in.
        /// </summary>
        public static Room CurrentRoom { set; get; }

        public World()
        {
            List<Room> Rooms = new List<Room>();
            Room start = new Room();
            Character player = new Character('@', new Coordinate(1, 1));
            start.AddRoomEntity(player);
            Rooms.Add(start);
            CurrentRoom = start;
            start.AddWall(new Coordinate(5, 12), new Coordinate(19, 5));
            start.AddWall(new Coordinate(5, 12), new Coordinate(9, 12));

            

            do
            {
                Console.Clear();

                start.Draw();

                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.W:
                        player.MoveRow(-1);
                        break;

                    case ConsoleKey.A:
                        player.MoveCol(-1);
                        break;

                    case ConsoleKey.S:
                        player.MoveRow(1);
                        break;
                    case ConsoleKey.D:
                        player.MoveCol(1);
                        break;
                }
            } while (player.IsAlive);

        }
    }
}
