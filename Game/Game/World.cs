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
            // Add the player to the list of entities in the room
            start.AddRoomEntity(player);
            // Add the room to the list of rooms.
            Rooms.Add(start);
            // Set the room as the current room, needed to access it from other places.
            CurrentRoom = start;


            ItemKey redKey = new ItemKey(4, 8, ConsoleColor.Red, '¥');
            ItemKey yellowKey = new ItemKey(13, 8, ConsoleColor.Yellow, '¥');
            Lever lever1 = new Lever(18, 2, ConsoleColor.Magenta, '¬');
            Door doorRed = new Door(14, 5, ConsoleColor.Red);

            CurrentRoom.AddRoomEntity(yellowKey);
            CurrentRoom.AddRoomEntity(doorRed);
            CurrentRoom.AddRoomEntity(redKey);
            CurrentRoom.AddRoomEntity(lever1);

            doorRed.Key = redKey;

            start.AddWall(new Coordinate(5, 12), new Coordinate(19, 5));
            start.AddWall(new Coordinate(5, 12), new Coordinate(9, 12));

            start.AddWall(new Coordinate(5, 12), new Coordinate(5, 19));
            start.AddWall(new Coordinate(7, 13), new Coordinate(7, 17));

            start.AddWall(new Coordinate(5, 1), new Coordinate(5, 8));
            start.AddWall(new Coordinate(5, 8), new Coordinate(9, 8));


            EnemyEntity enemyRoom1 = new EnemyEntity(17, 8, ConsoleColor.DarkGray, '¶');

            CurrentRoom.AddRoomEntity(enemyRoom1);
            int tilesToMove = 1;
            do
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                start.Draw();
                player.DrawInventory();



                if (enemyRoom1.IsAlive)
                {
                    enemyRoom1.Move(tilesToMove);
                }
                else
                {
                    enemyRoom1.IsVisible = false;
                }


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
                    case ConsoleKey.E:

                        foreach (Entity e in CurrentRoom.GetRoomEntities())
                        {
                            if (e.Location.IsAdjacent(player.Location))
                            {
                                if (e is Door)
                                {
                                    Door temp = (Door)e;

                                    if (player.PlayerKeys.Contains(temp.Key))
                                    {
                                        temp.Interact(temp.Key);
                                        player.PlayerKeys.Remove(temp.Key);

                                    }
                                }
                                if (e is Lever)
                                {
                                    //Interact with lever and delete wall.
                                }
                            }

                        }


                        break;
                }

                // Checks if there are any items that can be picked up.
                player.PickupItems();

            } while (player.IsAlive);

        }
    }
}
