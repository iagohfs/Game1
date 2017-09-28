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

        public Door(int doorRow, int doorCol, ConsoleColor doorColor)
        {
            Location.posRow = doorRow;
            Location.posCol = doorCol;
            Color = doorColor;
            Symbol = 'D';
            IsVisible = false;
        }

        public bool OnInteract(Player player)
        {
            if (player.Keyring.Contains(Key))
            {
                IsLocked = false;
                Collidable = false;
                Color = ConsoleColor.White;

                player.Keyring.Remove(Key);

                return true;
            }

            return false;
        }
    }
}
