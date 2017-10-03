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
            Collidable = true;
            IsVisible = true;
        }

        public void Interact()
        {
            foreach (Entity item in World.CurrentRoom.displayGrid)
            {
                if (item is IInteractable && item.Location.IsAdjacent(Location))
                {
                    (item as IInteractable).OnInteract(this);

                }
            }
        }



        /// <summary>
        /// Checks if the player is standing on an item and then picks it up.
        /// </summary>
        /// <returns></returns>
        public bool CheckTile()
        {
            // Since we can't modify a list whilst iterating through it, we need to catch a reference to which object we pick up.
            Entity eRef = null;

            Entity entity = World.CurrentRoom.displayGrid[Location.posRow, Location.posCol];

            if (entity is ICollectable)
            {
                if (entity is ItemKey)
                {
                    Keyring.Add((ItemKey)entity);
                    eRef = entity;
                    World.Score += 100;
                }
                else
                {
                    Inventory.Add(entity);
                    eRef = entity;
                    if (entity is Coin)
                    {
                        World.Score += (entity as Coin).PointValue;
                    }
                }
                World.CurrentRoom.displayGrid[World.player1.Location.posRow, World.player1.Location.posCol] = new FloorTile();
            }

            if (World.CurrentRoom.displayGrid[Location.posRow, Location.posCol] is TrapTile)
            {
                TrapTile trapTile = (TrapTile)World.CurrentRoom.displayGrid[Location.posRow, Location.posCol];
                World.Score -= trapTile.Damage;
            }

            //if (eRef != null)
            // World.CurrentRoom.GetRoomEntities().Remove(eRef);

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
            Console.Write("Your Score: ");
            Console.Write(World.Score);
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

        public void Move()
        {
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:

                    MoveSouth(-1);
                    break;

                case ConsoleKey.A:
                    MoveEast(-1);
                    break;

                case ConsoleKey.S:
                    MoveSouth(1);
                    break;
                case ConsoleKey.D:
                    MoveEast(1);
                    break;
                case ConsoleKey.E:
                    Interact();
                    break;
            }
            World.Score -= 10;
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
