using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class InventoryEntity : Entity
    {
        public new void Draw()
        {
            Console.ForegroundColor = Color;
            Console.WriteLine(Symbol);
            Console.ForegroundColor = ConsoleColor.White;
        }
    }
}
