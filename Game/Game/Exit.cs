using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Exit : Door, IInteractable
    {
        public Exit(int doorCol, int doorRow, ConsoleColor doorColor, ItemKey Key) : base(doorCol, doorRow, doorColor, Key)
        {
        }

        public new bool OnInteract(Player player)
        {
            if (player.Keyring.Contains(Key))
            {
                IsLocked = false;
                Collidable = false;
                Color = ConsoleColor.White;
                World.Score += 150;

                player.Keyring.Remove(Key);

                World.HasWon = true;

                return true;
            }

            return false;
        }

        
    }
}
