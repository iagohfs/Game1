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
            Character player = new Character('@', new Coordinate(1, 1), ConsoleColor.Green);

            start.AddRoomEntity(player);
            Rooms.Add(start);
            CurrentRoom = start;

            start.AddWall(new Coordinate(5, 12), new Coordinate(19, 5));
            start.AddWall(new Coordinate(5, 12), new Coordinate(9, 12));

            ItemKey yellowKey = new ItemKey(13, 8, ConsoleColor.Yellow, '¥');
            ObjectDoor door1 = new ObjectDoor(14, 5, ConsoleColor.Red, 'D');

            CurrentRoom.AddRoomEntity(yellowKey);
            CurrentRoom.AddRoomEntity(door1);

            start.AddWall(new Coordinate(5, 12), new Coordinate(5, 19));
            start.AddWall(new Coordinate(7, 13), new Coordinate(7, 17));

            ItemKey redKey = new ItemKey(4, 8, ConsoleColor.Red, '¥');
            CurrentRoom.AddRoomEntity(redKey);

            EnemyEntity enemyRoom1 = new EnemyEntity(16, 8, ConsoleColor.DarkGray, '¶');

            if (enemyRoom1.IsAlive)
            {
                enemyRoom1.Collidable = true;

            }

            CurrentRoom.AddRoomEntity(enemyRoom1);

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
