using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Character : MovableEntity
    {
        List<Entity> Inventory = new List<Entity>();
        public List<ItemKey> PlayerKeys = new List<ItemKey>();

        public bool IsAlive = true;



        /// <summary>
        /// Creates a Character entity.
        /// </summary>
        /// <param name="Symbol">What symbol will represent the character on the map.</param>
        /// <param name="pos">Starting position of the character.</param>
        /// <param name="characterColor">What color the character will have.</param>
        public Character(char Symbol, Coordinate pos, ConsoleColor characterColor)
        {
            this.Symbol = Symbol;
            Location = pos;
            Color = characterColor;
        }

        /// <summary>
        /// Checks if the player is standing on an item and then picks it up.
        /// </summary>
        /// <returns></returns>
        public bool PickupItems()
        {
            Entity eRef = null;

            foreach (Entity e in World.CurrentRoom.GetRoomEntities())
            {
                if (Location.Equals(e.Location) && e is ICollectable)
                {
                    if(e is ItemKey)
                    {
                        PlayerKeys.Add((ItemKey)e);
                        eRef = e;
                    }
                    else
                    {
                        Inventory.Add(e);
                        eRef = e;
                    }                    
                }
            }
            World.CurrentRoom.GetRoomEntities().Remove(eRef);
            return true;
        }

        /// <summary>
        /// Draws the inventory to the console.
        /// </summary>
        public void DrawInventory()
        {
            Console.WriteLine("Inventory:");
            Console.WriteLine("***********");
            foreach (Entity e in Inventory)
            {
                e.Draw();
            }
            foreach (Entity e in PlayerKeys)
            {
                e.Draw();
            }
            Console.WriteLine();
        }

        /// <summary>
        /// Returns the players inventory.
        /// </summary>
        /// <returns></returns>
        public List<Entity> GetInventory()
        {
            return Inventory;
        }

        /// <summary>
        /// Updates what is visible to the player.
        /// </summary>
        public void UpdateVisible()
        {
            Entity[,] room = World.CurrentRoom.displayGrid;

            for(int i = Location.posRow - 1; i <= Location.posRow + 1; i++)
            {
                for(int j = Location.posCol - 1; j <= Location.posCol + 1; j++)
                {
                    room[i, j].IsVisible = true;
                }
            }
        }


    }

}
