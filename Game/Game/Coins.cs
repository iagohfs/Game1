using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Coins : Entity, ICollectable
    {
        public Coins(int Row, int Col, ConsoleColor color, char symb)
        {
            Location.posRow = Row;
            Location.posCol = Col;
            Color = color;
            Symbol = symb;
            Collidable = false;
            IsVisible = false;
        }

        public bool AddToInventory(Player player)
        {
            throw new NotImplementedException();
        }


        
    }
}
