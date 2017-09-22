using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Character : MovableEntity
    {
        List<InventoryEntity> Inventory = new List<InventoryEntity>();
        public bool IsAlive = true;


        public Character(char Symbol, Coordinate pos)
        {
            this.Symbol = Symbol;
            Location = pos;
        }

        

    }

}
