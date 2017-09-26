using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : IEntity
    {
        // The character that represents the entity
        public char Symbol { get; protected set; }

        public Coordinate Location;

        public ConsoleColor Color;

        public bool Collidable = true;

        public bool IsVisible = true;

        public void Draw()
        {
            if (IsVisible)
            {
                Console.ForegroundColor = Color;
                Console.Write(Symbol);
                Console.ResetColor();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write('?');
                Console.ResetColor();
            }
            
        }

    }
}
