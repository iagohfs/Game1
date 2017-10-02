using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class TrapTile : FloorTile
    {

        public TrapType Type { get; set; }

        
        public int Damage { get; private set; }


        public TrapTile(TrapType type)
        {
            switch (type)
            {
                case TrapType.Spike:
                    Collidable = false;
                    IsVisible = true;
                    Symbol = '^';
                    Color = ConsoleColor.Gray;
                    Type = TrapType.Spike;
                    Damage = 500;
                    break;
                case TrapType.Pit:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = ' ';
                    Color = ConsoleColor.Red;
                    Type = TrapType.Pit;
                    Damage = 9999;
                    break;
            }

        }

        
    }

    public enum TrapType { Spike, Pit }

}
