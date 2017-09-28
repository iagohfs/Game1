using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Character : MovableEntity
    {
        public bool IsAlive = true;
        /// <summary>
        /// Creates a Character entity.
        /// </summary>
        /// <param name="Symbol">What symbol will represent the character on the map.</param>
        /// <param name="pos">Starting position of the character.</param>
        /// <param name="characterColor">What color the character will have.</param>
        public Character(char symbol, Coordinate location, ConsoleColor color)
        {
            Symbol = symbol;
            Location = location;
            Color = color;
        }
    }

}
