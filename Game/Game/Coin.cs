using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Coin : Entity, ICollectable
    {

        public Coin(int Row, int Col, ConsoleColor color, char symb, int value)
        {
            Location.posRow = Row;
            Location.posCol = Col;
            Color = color;
            Symbol = symb;
            Collidable = false;
            IsVisible = false;
            PointValue = value;
        }

        public int PointValue { get; set; }

        public bool AddToInventory(Player player)
        {
            throw new NotImplementedException();
        }
    }
}