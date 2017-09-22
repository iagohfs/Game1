using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class MovableEntity : Entity
    {
        /// <summary>
        /// Tries to move the entity upwards.
        /// </summary>
        /// <param name="distance">Distance moved in chosen direction. Negative numbers are opposite direction.</param>
        /// <returns></returns>
        public bool MoveY(int distance) // If you move a negative distance you do down. Reduces the number if methods
        {            
            Location.posY += distance;
            return true;
        }

        /// <summary>
        /// Tries to move the character to the right
        /// </summary>
        /// <param name="distance">Distance moved in chosen direction. Negative numbers are opposite direction.</param>
        /// <returns></returns>
        public bool MoveX(int distance)
        {
            Location.posX += distance;
            return true;
        }
    }
}