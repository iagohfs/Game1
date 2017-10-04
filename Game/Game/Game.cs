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
            
            Console.WriteLine("\n1. Start Game\n2. See instructions\n\nESC. Exit Game");

            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.D1:
                    {
                        Console.Clear();
                        System.Threading.Thread.Sleep(100);
                        World world = new World();
                        
                        break;
                    }
                case ConsoleKey.D2:
                    {
                        Instructions();
                        break;
                    }
                case ConsoleKey.Escape:
                    {
                        Console.Clear();
                        break;
                    }
                default:
                    {                        
                        Console.WriteLine("You've entered the wrong key.");
                        System.Threading.Thread.Sleep(1500);
                        Console.Clear();
                        Menu();
                        break;
                    }
            }
        }

        public void Instructions()
        {
            Console.Clear();
            Console.WriteLine($"\nYou're locked in a dungeon. To escape you must find the secret levers '¬' and keys '¥'!");
            Console.WriteLine("Your score is your best friend. Watch out for the monster (he eats score).");
            Console.WriteLine("Every time you move you lose score. Plan your movements accordingly.\n");

            Console.WriteLine("Ingame commands: W,A,S,D to move the player around. ESC to exit. M to go to Menu (and lose all progress).");
            Console.WriteLine("Press E to interact with objects.\n\nWalk over coins and keys to pick them up.\n");

            Console.WriteLine("Goodluck!");
            Console.WriteLine("Press any key to go to Menu. . .");
            Console.ReadLine();
            Console.Clear();
            Menu();
            
        }
    }
}
