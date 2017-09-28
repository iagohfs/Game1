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
        ItemKey Key { get; set; }

        public Door(int doorCol, int doorRow, ConsoleColor doorColor, ItemKey Key)
        {
            Location.posCol = doorCol;
            Location.posRow = doorRow;
            Color = doorColor;
            Symbol = 'D';
            IsVisible = false;
            this.Key = Key;
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
