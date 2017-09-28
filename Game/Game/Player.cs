using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player : Character
    {
        List<Entity> Inventory = new List<Entity>();
        public List<ItemKey> Keyring = new List<ItemKey>();

        public Player(char symbol, Coordinate location, ConsoleColor color) : base(symbol, location, color)
        {
            Symbol = symbol;
            Location = location;
            Color = color;
            Collidable = true;
            IsVisible = true;
        }

        public void Interact()
        {
            foreach (Entity item in World.CurrentRoom.GetRoomEntities())
            {
                if(item is IInteractable && item.Location.IsAdjacent(Location))
                {
                    (item as IInteractable).OnInteract(this);
                }
            }
        }



        /// <summary>
        /// Checks if the player is standing on an item and then picks it up.
        /// </summary>
        /// <returns></returns>
        public bool PickupItems()
        {
            Entity eRef = null;

            foreach (Entity entity in World.CurrentRoom.GetRoomEntities())
            {
                if (Location.Equals(entity.Location) && entity is ICollectable)
                {
                    if (entity is ItemKey)
                    {
                        Keyring.Add((ItemKey)entity);
                        eRef = entity;
                    }
                    else
                    {
                        Inventory.Add(entity);
                        eRef = entity;
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
            Console.Write("Inventory: ");
            foreach (Entity entity in Inventory)
            {
                entity.Draw();
            }
            Console.Write(" \n");
            Console.WriteLine();


            Console.Write("Keys: ");
            foreach (Entity entity in Keyring)
            {
                entity.Draw();
            }
            Console.Write(" \n");

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

            for (int i = Location.posRow - 1; i <= Location.posRow + 1; i++)
            {
                for (int j = Location.posCol - 1; j <= Location.posCol + 1; j++)
                {
                    room[i, j].IsVisible = true;
                }
            }
        }





    }
}
