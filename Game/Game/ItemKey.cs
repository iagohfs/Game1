using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemKey : Entity
    {
        public ItemKey()
        {
            Location.posCol = 7;
            Location.posRow = 7;
            Color = ConsoleColor.Yellow;
            Symbol = '¥';
        }
    }
}
