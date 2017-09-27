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

            // Add the room to the list of rooms.
            Rooms.Add(start);
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

            start.AddWall(new Coordinate(5, 12), new Coordinate(19, 5), "Wall1");
            start.AddWall(new Coordinate(5, 12), new Coordinate(9, 12), "Wall2");

            start.AddWall(new Coordinate(5, 12), new Coordinate(5, 19), "Wall3");
            start.AddWall(new Coordinate(7, 13), new Coordinate(7, 17), "Wall4");

            start.AddWall(new Coordinate(5, 1), new Coordinate(5, 8), "Wall5");
            start.AddWall(new Coordinate(5, 8), new Coordinate(9, 8), "Wall6");


            EnemyEntity enemyRoom1 = new EnemyEntity(16, 8, ConsoleColor.DarkGray, '¶');

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
                        player.MoveSouth(-1);
                        break;

                    case ConsoleKey.A:
                        player.MoveEast(-1);
                        break;

                    case ConsoleKey.S:
                        player.MoveSouth(1);
                        break;
                    case ConsoleKey.D:
                        player.MoveEast(1);
                        break;
                    case ConsoleKey.E:

                        foreach (Entity e in CurrentRoom.GetRoomEntities())
                        {
                            if (e.Location.IsAdjacent(player.Location))
                            {
                                if (e is Door)
                                {
                                    Door temp = (Door)e;

                                    if (player.Keyring.Contains(temp.Key))
                                    {
                                        temp.Interact(temp.Key);
                                        player.Keyring.Remove(temp.Key);

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
                player.UpdateVisible();

            } while (player.IsAlive);

        }
    }
}
