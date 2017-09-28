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
        List<Character> roomCharacters = new List<Character>();
        List<Wall> roomWalls = new List<Wall>();

        Entity[,] Grid;
        public Entity[,] displayGrid;


        /// <summary>
        /// Draws the room to the console.
        /// </summary>
        public void Draw()
        {
            displayGrid = (Entity[,])Grid.Clone();


            DrawWalls();

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
        /// Draws all the entities in the rooms list of entities.
        /// </summary>
        public void DrawRoomEntities()
        {
            for (int i = roomEntities.Count() - 1; i >= 0; i--)
            {
                // Put each entity on the drawn grid
                displayGrid[roomEntities[i].Location.posRow, roomEntities[i].Location.posCol] = roomEntities[i];
            }
        }

        public void DrawWalls()
        {
            foreach (Wall wall in roomWalls)
            {

                if (wall.Start.posCol == wall.End.posCol)
                {
                    for (int i = wall.Start.posRow; i < wall.End.posRow; i++)
                    {
                        displayGrid[i, wall.Start.posCol] = new WallTile();
                    }
                }
                else if (wall.Start.posRow == wall.End.posRow)
                {
                    for (int i = wall.Start.posCol; i < wall.End.posCol; i++)
                    {
                        displayGrid[wall.Start.posRow, i] = new WallTile();
                    }
                }

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

            AddWall(new Coordinate(0, 0), new Coordinate(9, 0), "WestWall", true);
            AddWall(new Coordinate(0, 0), new Coordinate(0, 19), "NorthWall", true);
            AddWall(new Coordinate(0, 19), new Coordinate(9, 19), "EastWall", true);
            AddWall(new Coordinate(9, 0), new Coordinate(9, 20), "SouthWall", true);
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
                    newGrid[i, j] = new FloorTile();
                }
            }

            return newGrid;
        }

        public void AddWall(Coordinate start, Coordinate end, String id, bool draw)
        {
            roomWalls.Add(new Wall(start, end, id, draw));
        }

        public void SetWallDraw(String id)
        {
            throw new NotImplementedException();
        }

        public void RemoveWall(String ID)
        {
            roomWalls.RemoveAll(Wall => Wall.ID == ID);
        }

        /// <summary>
        /// Adds an entity to the rooms list of entities.
        /// </summary>
        /// <param name="e"></param>
        public void AddRoomEntity(Entity entity)
        {
            if (entity is Character)
            {
                roomEntities.Insert(0, entity);
            }
            else
            {
                roomEntities.Add(entity);
            }
        }

        /// <summary>
        /// Returns a list of all entites in the room.
        /// </summary>
        /// <returns></returns>
        public List<Entity> GetRoomEntities()
        {
            return roomEntities;
        }

        /// <summary>
        /// Removes the entity from list.
        /// </summary>
        /// <param name="e"></param>
        public void RemoveRoomEntity(Entity entity)
        {
            roomEntities.Remove(entity);
        }
    }

    /// <summary>
    /// Location on a 2D grid.
    /// </summary>
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

            if (c.posCol == posCol - 1 && c.posRow == posRow)
            {
                return true;
            }
            else if (c.posCol == posCol + 1 && c.posRow == posRow)
            {
                return true;
            }
            else if (c.posCol == posCol && c.posRow == posRow - 1)
            {
                return true;
            }
            else if (c.posCol == posCol && c.posRow == posRow + 1)
            {
                return true;
            }

            return false;
        }

    }

    /// <summary>
    /// Contains the Start and End coordinates for the wall as well as its unique ID.
    /// </summary>
    public struct Wall
    {
        public Coordinate Start, End;
        public String ID;
        public bool Draw;


        public Wall(Coordinate start, Coordinate end, String id, bool draw)
        {
            Start = start;
            End = end;
            ID = id;
            Draw = draw;
        }
    }

}
