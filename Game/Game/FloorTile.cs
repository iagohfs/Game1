using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class FloorTile : Entity
    {

        /// <summary>
        /// Generates a RoomTile entity. Placed in a Roomgrid to build a map.
        /// </summary>
        /// <param name="tile">Sets the properties for the tile</param>
        public FloorTile(TileType tile)
        {
            switch (tile)
            {
                case TileType.Floor:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = '.';
                    Color = ConsoleColor.White;
                    break;
                case TileType.Pit:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = ' ';
                    Color = ConsoleColor.Gray;
                    break;
            }
        }
    }

    /// <summary>
    /// What properties the FloorTile will have
    /// </summary>
    public enum TileType { Floor, Pit }
}
