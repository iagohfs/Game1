using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemKey : Entity
    {
        public ItemKey(int keyCol, int keyPos, ConsoleColor keyColor, char keySymb)
        {
            Location.posCol = keyCol;
            Location.posRow = keyPos;
            Color = keyColor;
            Symbol = keySymb;
        }
    }
}
