using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemKey : Entity
    {
        Coordinate Key = new Coordinate();

        public ItemKey()
        {
            Location.posX = 7;
            Location.posY = 7;

            Symbol = '¥';
        }

        

        

    }
}
