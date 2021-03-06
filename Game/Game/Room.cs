﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room : IEntity
    {
        int SizeCols;
        int SizeRows;
        List<Character> roomCharacters = new List<Character>();
        // These lists are used to keep track of the traps and walls, so that we can remove them.
        List<Wall> roomWalls = new List<Wall>();
        List<Wall> roomTraps = new List<Wall>();

        //Entity[,] Grid;
        public Entity[,] displayGrid;

        public void AddRoomCharacters(Character character)
        {
            roomCharacters.Add(character);
        }

        public List<Character> GetRoomCharacters()
        {
            return roomCharacters;
        }

        /// <summary>
        /// Draws the room to the console.
        /// </summary>
        public void Draw()
        {
            for (int row = 0; row < displayGrid.GetLength(0); row++)
            {
                for (int column = 0; column < displayGrid.GetLength(1); column++)
                {
                    Coordinate CurrentPosition = new Coordinate(row, column);    
                    // Get any character that is at the current coordinate.
                    Character character = roomCharacters.Find(Character => Character.Location.Equals(CurrentPosition));
                    
                    // Set the edge tiles to visible.
                    if (row == 0 || row == displayGrid.GetLength(0) - 1 || column == 0 || column == displayGrid.GetLength(1) - 1)
                    {
                        displayGrid[row, column].IsVisible = true;
                    }

                    // If there is a character at this coordinate, draw them first.
                    if(character != null)
                    {
                        character.Draw();
                    }
                    else
                    {
                        displayGrid[row, column].Draw();
                    }                    

                }

                Console.WriteLine();
            }
        }
        
        // Get the walls from the list and put them in the displayGrid.
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

        public void BuildWalls()
        {
            World.CurrentRoom.AddWall(new Coordinate(5, 12), new Coordinate(19, 5), "Wall1");
            World.CurrentRoom.AddWall(new Coordinate(5, 12), new Coordinate(9, 12), "Wall2");

            World.CurrentRoom.AddWall(new Coordinate(5, 12), new Coordinate(5, 19), "Wall3");
            World.CurrentRoom.AddWall(new Coordinate(7, 13), new Coordinate(7, 17), "Wall4");

            World.CurrentRoom.AddWall(new Coordinate(5, 1), new Coordinate(5, 8), "Wall5");
            World.CurrentRoom.AddWall(new Coordinate(5, 8), new Coordinate(9, 8), "Wall6");

            World.CurrentRoom.AddWall(new Coordinate(1, 8), new Coordinate(4, 8), "Wall7");
            World.CurrentRoom.AddWall(new Coordinate(1, 12), new Coordinate(4, 12), "Wall8");
            World.CurrentRoom.AddWall(new Coordinate(3, 9), new Coordinate(3, 12), "Wall9");
            World.CurrentRoom.AddTrap(new Coordinate(5, 9), new Coordinate(5, 12), "Spike");
        }

        // Same principle as the DrawWalls method.
        public void DrawTraps()
        {
            foreach (Wall wall in roomTraps)
            {
                if (wall.Start.posCol == wall.End.posCol)
                {
                    for (int i = wall.Start.posRow; i < wall.End.posRow; i++)
                    {
                        displayGrid[i, wall.Start.posCol] = new TrapTile(TrapType.Spike);
                    }
                }
                else if (wall.Start.posRow == wall.End.posRow)
                {
                    for (int i = wall.Start.posCol; i < wall.End.posCol; i++)
                    {
                        displayGrid[wall.Start.posRow, i] = new TrapTile(TrapType.Spike);
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
            SizeCols = 20;
            SizeRows = 10;

            displayGrid = GenerateNewGrid(SizeCols, SizeRows);

            AddWall(new Coordinate(0, 0), new Coordinate(SizeRows-1, 0), "WestWall");
            AddWall(new Coordinate(0, 0), new Coordinate(0, SizeCols-1), "NorthWall");
            AddWall(new Coordinate(0, SizeCols-1), new Coordinate(SizeRows-1, SizeCols-1), "EastWall");
            AddWall(new Coordinate(SizeRows-1, 0), new Coordinate(SizeRows-1, SizeCols), "SouthWall");

        }

        /// <summary>
        /// Generate a new room.
        /// </summary>
        /// <param name="sizeRows">Height of the room</param>
        /// <param name="sizeCols">Width of the room</param>
        public Room(int sizeRows, int sizeCols)
        {
            displayGrid = GenerateNewGrid(sizeRows, sizeCols);
        }

        // Create a grid with only floortiles.
        public Entity[,] GenerateNewGrid(int sizeRows, int sizeCols)
        {
            Entity[,] newGrid = new Entity[sizeCols, sizeRows];

            for (int i = 0; i < newGrid.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.GetLength(1); j++)
                {
                    newGrid[i, j] = new FloorTile();
                }
            }

            return newGrid;
        }

        public void AddWall(Coordinate start, Coordinate end, String id)
        {
            roomWalls.Add(new Wall(start, end, id));
        }

        public void SetWallDraw(String id)
        {
            throw new NotImplementedException();
        }

        public void RemoveWall(String ID)
        {

            Wall wall = roomWalls.Find(Wall => Wall.ID == ID);
            if (wall.Start.posCol == wall.End.posCol)
            {
                for (int i = wall.Start.posRow; i < wall.End.posRow; i++)
                {
                    World.CurrentRoom.displayGrid[i, wall.Start.posCol] = new FloorTile();
                }
            }
            else if (wall.Start.posRow == wall.End.posRow)
            {
                for (int j = wall.Start.posCol; j < wall.End.posCol; j++)
                {
                    World.CurrentRoom.displayGrid[wall.Start.posRow, j] = new FloorTile();
                }
            }

        }

        public void AddTrap(Coordinate start, Coordinate end, String id)
        {
            roomTraps.Add(new Wall(start, end, id));
        }

        public void RemoveTrap(String ID)
        {

            Wall wall = roomTraps.Find(Wall => Wall.ID == ID);
            if (wall.Start.posCol == wall.End.posCol)
            {
                for (int i = wall.Start.posRow; i < wall.End.posRow; i++)
                {
                    World.CurrentRoom.displayGrid[i, wall.Start.posCol] = new FloorTile();
                }
            }
            else if (wall.Start.posRow == wall.End.posRow)
            {
                for (int j = wall.Start.posCol; j < wall.End.posCol; j++)
                {
                    World.CurrentRoom.displayGrid[wall.Start.posRow, j] = new FloorTile();
                }
            }

        }

        /// <summary>
        /// Adds an entity to the rooms list of entities.
        /// </summary>
        /// <param name="e"></param>
        public void AddRoomEntity(Entity entity)
        {
            displayGrid[entity.Location.posRow, entity.Location.posCol] = entity;
        }


        /// <summary>
        /// Removes the entity from list.
        /// </summary>
        /// <param name="e"></param>
        public void RemoveRoomEntity(Entity entity)
        {
            displayGrid.Equals(entity);
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

        public Wall(Coordinate start, Coordinate end, String id)
        {
            Start = start;
            End = end;
            ID = id;

        }

    }

    public struct Trap
    {
        public Coordinate Start, End;
        public String ID;

        public Trap(Coordinate start, Coordinate end, String id)
        {
            Start = start;
            End = end;
            ID = id;

        }

    }

}
