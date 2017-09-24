using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class WallTile : Entity
    {
        public WallTile()
        {
            Collidable = true;
            IsVisible = true;
            Symbol = '#';
            Color = ConsoleColor.White;
        }

    }
}
