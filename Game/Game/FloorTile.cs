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
        /// What type the Floortile is.
        /// </summary>
        public TileType FloorType { get; set; }

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
                    FloorType = TileType.Floor;
                    break;
                case TileType.Pit:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = ' ';
                    Color = ConsoleColor.Gray;
                    FloorType = TileType.Pit;
                    break;
                case TileType.Spike:
                    Collidable = false;
                    IsVisible = false;
                    Symbol = '^';
                    Color = ConsoleColor.Red;
                    FloorType = TileType.Spike;
                    break;
            }
        }
    }

    /// <summary>
    /// What properties the FloorTile will have
    /// </summary>
    public enum TileType { Floor, Pit, Spike }
}
