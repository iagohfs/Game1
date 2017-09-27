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
                    IsVisible = false;
                    Symbol = '^';
                    Color = ConsoleColor.Gray;
                    Type = TrapType.Pit;
                    Damage = 10;
                    break;
                case TrapType.Pit:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = ' ';
                    Color = ConsoleColor.Red;
                    Type = TrapType.Spike;
                    Damage = 100;
                    break;
            }

        }
    }

    public enum TrapType { Spike, Pit }
}
