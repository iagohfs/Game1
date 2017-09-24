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

        public Entity[,] Grid;
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
                    // Sets the color to the entities specified color and draws it.
                    Console.ForegroundColor = displayGrid[row, column].Color;
                    Console.Write(displayGrid[row, column].Symbol);
                }
                Console.WriteLine();
            }
            // Resets the console color.
            Console.ForegroundColor = ConsoleColor.White;
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
            foreach (Entity e in roomEntities)
            {
                // Put each entity on the drawn grid
                displayGrid[e.Location.posRow, e.Location.posCol] = e;

                // Draw order.
                // Room (Walls floor)
                // Entities (Items, doors)
                // Characters (Player) The player must be drawn last.
            }
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

        public bool Equals(Coordinate c)
        {
            if (posCol == c.posCol && posRow == c.posRow)
                return true;
            else
                return false;
        }

    }
}
