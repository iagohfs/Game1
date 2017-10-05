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
        /// Player Score.
        /// </summary>
        public static int Score { get; set; }
        /// <summary>
        /// The room that the player is currently in.
        /// </summary>
        public static Room CurrentRoom { set; get; }
        public static Player player1 { get; set; }
        
        public World()
        {
            Console.CursorVisible = false;
            CurrentRoom = new Room();

            player1 = new Player('@', new Coordinate(1, 1), ConsoleColor.Green);
            EnemyEntity enemyRoom1 = new EnemyEntity('¶', new Coordinate(8, 17), ConsoleColor.Cyan);
            Score += 1000;
            
            CurrentRoom.BuildWalls();
            CurrentRoom.DrawTrap();
            CurrentRoom.DrawWalls();

            Coin coin1 = new Coin(3, 15, ConsoleColor.Yellow, 'o', 100);
            Coin coin2 = new Coin(2, 6, ConsoleColor.Yellow, 'o', 100);
            Coin coin3 = new Coin(1, 13, ConsoleColor.Yellow, 'o', 100);
            Coin superCoin = new Coin(8, 1, ConsoleColor.Red, 'O', 250);

            

            Lever lever1 = new Lever(new Coordinate(4, 18), ConsoleColor.Magenta, CurrentRoom.RemoveWall, "Wall5");
            Lever lever3 = new Lever(new Coordinate(4, 1), ConsoleColor.Green, CurrentRoom.RemoveWall, "");
            Lever lever2 = new Lever(new Coordinate(8, 18), ConsoleColor.Green, CurrentRoom.RemoveWall, "Wall9");
            Lever trap1 = new Lever(new Coordinate(1, 10), ConsoleColor.Yellow, CurrentRoom.RemoveTrap, "Spike");

            ItemKey redKey = new ItemKey(4, 8, ConsoleColor.Red, '¥');
            ItemKey yellowKey = new ItemKey(13, 8, ConsoleColor.Yellow, '¥');

            Door doorRed = new Door(14, 5, ConsoleColor.Red, redKey);
            Exit doorGold = new Exit(10, 8, ConsoleColor.Yellow, yellowKey);

            do
            {
                Console.CursorLeft = 0;
                Console.CursorTop = 0;

                player1.UpdateVisible();
                CurrentRoom.Draw();

                player1.DrawInventory();

                player1.Move();
                enemyRoom1.Move();
                
                player1.UpdateVisible();

                // Checks if there are any items that can be picked up.
                player1.CheckTile();

            } while (player1.IsAlive && Score >= 0);

            Console.Clear();

            Console.WriteLine("Game Over!");

            Console.WriteLine($"Your score was: {Score}");

            System.Threading.Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}
