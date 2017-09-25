using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ObjectDoor : Entity
    {
        public ObjectDoor(int doorCol, int doorRow, ConsoleColor doorColor, char doorSymb)
        {
            Location.posCol = doorCol;
            Location.posRow = doorRow;
            Color = doorColor;
            Symbol = doorSymb;
        }
    }
}
