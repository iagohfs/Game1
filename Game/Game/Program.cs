using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            Character Player = new Character();
            Console.WriteLine("Add a character name: ");
            string input = Console.ReadLine();
            input = Player.Name(input);

            Console.WriteLine(input);

            Console.ReadLine();
            
        }
    }

}
