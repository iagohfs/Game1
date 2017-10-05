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

        // Game was originally supposed to be multi-room, but the feature was cut.
        public static Room CurrentRoom { set; get; }
        public static Player Player1 { get; set; }
        public static bool HasWon { get; set; }


        public World()
        {
            Console.CursorVisible = false;
            HasWon = false;

            CurrentRoom = new Room();
            Score += 1000;

            // Players and enemies
            Player1 = new Player('@', new Coordinate(1, 1), ConsoleColor.Green);
            EnemyEntity enemy1 = new EnemyEntity('¶', new Coordinate(8, 17), ConsoleColor.DarkRed, 100);
            EnemyEntity enemy2 = new EnemyEntity('¶', new Coordinate(8, 4), ConsoleColor.DarkCyan, 200);
            
            // Add the walls of the level
            CurrentRoom.BuildWalls();

            // Draw them to the displaygrid
            CurrentRoom.DrawTraps();
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

                // Update the players view range.
                Player1.UpdateVisible();

                // Draw the map and inventory to console.
                CurrentRoom.Draw();
                Player1.DrawInventory();

                // Get user input and move the player and update view range again.
                Player1.Move();
                Player1.UpdateVisible();

                enemy1.Move();
                enemy2.Move();

                // Checks if there are any items that can be picked up.
                Player1.CheckTile();

            } while (Player1.IsAlive && Score >= 0 && !HasWon);

            Console.Clear();
            if (!HasWon)
            {
                Console.WriteLine("Game Over!");
            }
            else
            {
                Console.WriteLine("You won!");
                Console.WriteLine($"Your score was: {Score}");
            }

            System.Threading.Thread.Sleep(1000);
            Console.ReadKey();
        }
    }
}
