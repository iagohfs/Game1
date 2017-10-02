using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class World
    {
        public static int Score { get; set; }
        /// <summary>
        /// The room that the player is currently in.
        /// </summary>
        public static Room CurrentRoom { set; get; }

        public World()
        {
            List<Room> Rooms = new List<Room>();
            Room start = new Room();
            Player player = new Player('@', new Coordinate(1, 1), ConsoleColor.Green);
            start.AddRoomEntity(player);

            // Add the room to the list of rooms.
            Rooms.Add(start);
            CurrentRoom = start;

            Coin coin1 = new Coin(3, 15, ConsoleColor.Yellow, 'o', 100);
            Coin coin2 = new Coin(2, 6, ConsoleColor.Yellow, 'o', 100);
            Coin coin3 = new Coin(1, 13, ConsoleColor.Yellow, 'o', 100);
            Coin superCoin = new Coin(8, 1, ConsoleColor.Red, 'O', 250);

            EnemyEntity enemyRoom1 = new EnemyEntity(17, 8, ConsoleColor.DarkGray, '¶');

            CurrentRoom.AddRoomEntity(enemyRoom1);

            Lever lever1 = new Lever(new Coordinate(4, 18), ConsoleColor.Magenta, CurrentRoom.RemoveWall, "Wall5");
            Lever lever2 = new Lever(new Coordinate(8, 18), ConsoleColor.Green, CurrentRoom.RemoveWall, "Wall9");
            Lever lever3 = new Lever(new Coordinate(1, 10), ConsoleColor.Yellow, CurrentRoom.RemoveWall, "Wall7");

            CurrentRoom.AddTrap(new Coordinate(5, 9), new Coordinate(5, 12), "Spike", true);


            ItemKey redKey = new ItemKey(4, 8, ConsoleColor.Red, '¥');
            ItemKey yellowKey = new ItemKey(13, 8, ConsoleColor.Yellow, '¥');

            Door doorRed = new Door(14, 5, ConsoleColor.Red, redKey);
            Door doorGold = new Door(10, 8, ConsoleColor.Yellow, yellowKey);

            CurrentRoom.AddRoomEntity(coin1);
            CurrentRoom.AddRoomEntity(coin2);
            CurrentRoom.AddRoomEntity(coin3);
            CurrentRoom.AddRoomEntity(superCoin);

            CurrentRoom.AddRoomEntity(yellowKey);
            CurrentRoom.AddRoomEntity(doorRed);
            CurrentRoom.AddRoomEntity(doorGold);
            CurrentRoom.AddRoomEntity(redKey);

            CurrentRoom.AddRoomEntity(lever1);
            CurrentRoom.AddRoomEntity(lever2);
            CurrentRoom.AddRoomEntity(lever3);

            start.BiuldWalls();

            Score += 1000;

            int tilesToMove = 1;
            do
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                start.Draw();
                player.DrawInventory();


                if (player.Location.Equals(enemyRoom1.Location))
                {
                    Score -= 100;
                }

                if (enemyRoom1.IsAlive)
                {
                    enemyRoom1.Move(tilesToMove);
                }
                else
                {
                    enemyRoom1.IsVisible = false;
                }



                player.Move();


                // Checks if there are any items that can be picked up.                

                player.CheckTile();
                player.UpdateVisible();

            } while (player.IsAlive && Score >= 0);
            Console.Write("Game Over.");
            System.Threading.Thread.Sleep(2000);
        }
    }
}
