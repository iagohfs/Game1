using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Game
    {
        public void Menu()
        {
            Console.CursorVisible = false;
            Console.WriteLine("\n1. Start Game\n2. See instructions\n\nESC. Exit Game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:

                    Console.Clear();
                    System.Threading.Thread.Sleep(100);
                    World world = new World();

                    break;

                case ConsoleKey.D2:

                    Instructions();
                    break;

                case ConsoleKey.Escape:

                    Console.Clear();
                    break;

                default:

                    Console.WriteLine("You've entered the wrong key.");
                    System.Threading.Thread.Sleep(1500);
                    Console.Clear();
                    Menu();
                    break;

            }

        }

        public void Instructions()
        {
            Console.CursorVisible = false;
            Console.Clear();
            Console.WriteLine($"\n You're locked in a dungeon. To escape you must find the secret levers '¬' and keys '¥'!");
            Console.WriteLine(" Your score is your best friend. Watch out for the monster (he eats score).");
            Console.WriteLine(" Every time you move you lose score. Plan your movements accordingly.\n");            

            Console.WriteLine(" Ingame commands:\n\n W,A,S,D to move the player around." +
                "\n E to interact with objects (Doors and levers)." +
                "\n ESC to exit." +
                "\n M to go to Menu (and lose all progress).");
            Console.WriteLine("\n\n Walk over coins and keys to pick them up.");
            Console.WriteLine(" Enemies will only be visible if you look directly at them\n");

            Console.WriteLine(" Goodluck!");
            Console.WriteLine(" Press any key to go to Menu. . .");
            Console.ReadKey();
            Console.Clear();
            Menu();

        }
    }
}
