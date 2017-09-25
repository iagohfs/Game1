using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room : IEntity
    {
        int SizeX;
        int SizeY;
        List<Entity> roomEntities = new List<Entity>();

        Entity[,] Grid;
        public Entity[,] displayGrid;


        /// <summary>
        /// Draws the room to the console.
        /// </summary>
        public void Draw()
        {
            // Creates a clone of the room so that we can draw on it instead of the room.
            displayGrid = (Entity[,])Grid.Clone();

            // Put all the entities in the clone.
            DrawRoomEntities();

            // Draw the clone to the console window.
            for (int row = 0; row < displayGrid.GetLength(0); row++)
            {
                for (int column = 0; column < displayGrid.GetLength(1); column++)
                {
                    displayGrid[row, column].Draw();
                }
                Console.WriteLine();
            }
        }

        /// <summary>
        /// Generate a "square" room of size 20x10.
        /// </summary>
        public Room()
        {
            // Default room size.
            SizeX = 20;
            SizeY = 10;

            Grid = GenerateNewGrid(SizeX, SizeY);

            // TODO: Change this to remove magic numbers...
            AddWall(new Coordinate(0, 0), new Coordinate(9, 0));
            AddWall(new Coordinate(0, 0), new Coordinate(0, 19));
            AddWall(new Coordinate(0, 19), new Coordinate(9, 19));
            AddWall(new Coordinate(9, 0), new Coordinate(9, 20));
        }

        /// <summary>
        /// Generate a new room.
        /// </summary>
        /// <param name="sizeY">Height of the room</param>
        /// <param name="sizeX">Width of the room</param>
        public Room(int sizeY, int sizeX)
        {
            Grid = GenerateNewGrid(SizeX, SizeY);

        }

        public Entity[,] GenerateNewGrid(int sizeY, int sizeX)
        {
            Entity[,] newGrid = new Entity[SizeY, SizeX];

            for (int i = 0; i < newGrid.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.GetLength(1); j++)
                {
                    newGrid[i, j] = new FloorTile(TileType.Floor);
                }
            }

            return newGrid;
        }

        /// <summary>
        /// Generate wall between two coordinates. Can only generate horizontal or vertical walls.
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void AddWall(Coordinate start, Coordinate end)
        {

            if (start.posCol == end.posCol)
            {
                for (int i = start.posRow; i < end.posRow; i++)
                {
                    Grid[i, start.posCol] = new WallTile();
                }
            }
            else if (start.posRow == end.posRow)
            {
                for (int i = start.posCol; i < end.posCol; i++)
                {
                    Grid[start.posRow, i] = new WallTile();
                }
            }
        }

        public void AddRoomEntity(Entity e)
        {
            if(e is Character)
            {
                roomEntities.Insert(0, e);
            }
            else
            {
                roomEntities.Add(e);
            }
        }


        public void DrawRoomEntities()
        {
            for(int i = roomEntities.Count() - 1; i >= 0; i--)
            {
                // Put each entity on the drawn grid
                displayGrid[roomEntities[i].Location.posRow, roomEntities[i].Location.posCol] = roomEntities[i];
            }
                // Draw order.
                // Room (Walls floor)
                // Entities (Items, doors)
                // Characters (Player) The player must be drawn last.
        }

        public List<Entity> GetRoomEntities()
        {
            return roomEntities;
        }

        public void RemoveRoomEntity(Entity e)
        {
            roomEntities.Remove(e);
        }
        

        // Something to store the entities in the current room
        // Ordered list. Keep the player at the lowest index and iterate backwards, to draw the player last.

        // Enum for room types?
    }

    public struct Coordinate
    {
        public int posCol, posRow;

        public Coordinate(int posRow, int posCol)
        {
            this.posCol = posCol;
            this.posRow = posRow;            
        }        

        /// <summary>
        /// Checks if the coordinate is in the same location.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool Equals(Coordinate c)
        {
            if (posCol == c.posCol && posRow == c.posRow)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Checks if the coordinate is adjacent.
        /// </summary>
        /// <param name="c"></param>
        /// <returns></returns>
        public bool IsAdjacent(Coordinate c)
        {

            if(c.posCol == posCol - 1 && c.posRow == posRow)
            {
                return true;
            }
            else if(c.posCol == posCol + 1 && c.posRow == posRow)
            {
                return true;
            }
            else if(c.posCol == posCol && c.posRow == posRow - 1)
            {
                return true;
            }
            else if(c.posCol == posCol && c.posRow == posRow + 1)
            {
                return true;
            }

            return false;
        }

    }
}
