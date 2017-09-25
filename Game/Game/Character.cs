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
        public bool IsAlive = true;


        public Character(char Symbol, Coordinate pos, ConsoleColor characterColor)
        {
            this.Symbol = Symbol;
            Location = pos;
            Color = characterColor;
        }

        public bool PickupItems()
        {
            Entity eRef = null;

            foreach(Entity e in World.CurrentRoom.GetRoomEntities())
            {
                if(Location.Equals(e.Location) && e is ICollectable)
                {
                    Inventory.Add(e);
                    eRef = e;
                }
            }
            World.CurrentRoom.GetRoomEntities().Remove(eRef);
            return true;
        }

        public void DrawInventory()
        {
            Console.WriteLine("Inventory:");
            Console.WriteLine("***********");
            foreach (Entity e in Inventory)
            {
                e.Draw();
            }
            Console.WriteLine();
        }
        

    }

}
