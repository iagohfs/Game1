using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Door : Entity, IInteractable
    {

        public bool IsLocked { get; set; }

        /// <summary>
        /// A reference to the key that unlocks the door.
        /// </summary>
        public ItemKey Key { get; set; }

        public Door(int doorCol, int doorRow, ConsoleColor doorColor)
        {
            Location.posCol = doorCol;
            Location.posRow = doorRow;
            Color = doorColor;
            Symbol = 'D';
            IsVisible = false;
        }

        public bool Interact()
        {
            
            return true;
        }

        /// <summary>
        /// Opens the door if the key fits.
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public bool Interact(ItemKey Key)
        {
            if (this.Key.Equals(Key))
            {
                IsLocked = false;
                IsVisible = true;
                Color = ConsoleColor.White;
                Collidable = false;
            }
            return true;
        }

        
    }
}
