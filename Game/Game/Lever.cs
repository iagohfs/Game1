using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Lever : Entity
    {
        public Lever(int Col, int Row, ConsoleColor LevColor, char Symb)
        {
            Location.posCol = Col;
            Location.posRow = Row;
            Color = LevColor;
            Symbol = Symb;
            Collidable = false;
            IsVisible = true;
        }

        /// <summary>
        /// Adds the item to the selected players inventory. (Not implemented, will throw exception.)
        /// </summary>
        /// <param name="c">The player that the item will added to.</param>
        /// <returns></returns>
        public bool AddToInventory(Character c)
        {
            throw new NotImplementedException();
        }
    }
}
