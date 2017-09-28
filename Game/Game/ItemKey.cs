using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemKey : Entity, ICollectable
    {
        public ItemKey(int keyCol, int keyPos, ConsoleColor keyColor, char keySymb)
        {
            Location.posCol = keyCol;
            Location.posRow = keyPos;
            Color = keyColor;
            Symbol = keySymb;
            Collidable = false;
            IsVisible = false;
        }

        /// <summary>
        /// Adds the item to the selected players inventory. (Not implemented, will throw exception.)
        /// </summary>
        /// <param name="c">The player that the item will added to.</param>
        /// <returns></returns>
        public bool AddToInventory(Player player)
        {
            throw new NotImplementedException();
        }
    }
}
