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
        /// Moves the MovableEntity to a new row.
        /// </summary>
        /// <param name="distance">Distance moved in chosen direction. Negative numbers are opposite direction.</param>
        /// <returns></returns>
        public bool MoveRow(int distance) // If you move a negative distance you do down. Reduces the number if methods
        {
            if (!WillCollide(distance, 0))
                Location.posRow += distance;
            return true;
        }

        /// <summary>
        /// Moves the MovableEntity to a new column.
        /// </summary>
        /// <param name="distance">Distance moved in chosen direction. Negative numbers are opposite direction.</param>
        /// <returns></returns>
        public bool MoveCol(int distance)
        {
            if(!WillCollide(0, distance))
                Location.posCol += distance;
            return true;
        }

        /// <summary>
        /// Returns if the object the MovableEntity is trying to move to is collidable or not.
        /// </summary>
        /// <param name="distRow">Distance moved up or down</param>
        /// <param name="distCol">Distance moved right or left</param>
        /// <returns></returns>
        private bool WillCollide(int distRow, int distCol)
        {
            if (World.CurrentRoom.displayGrid[Location.posRow + distRow, Location.posCol + distCol].Collidable)
            {
                return true;
            }               
            return false;
        }
    }
}