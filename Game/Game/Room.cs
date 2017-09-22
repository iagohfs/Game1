using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Room
    {
        int SizeX;
        int SizeY;
        List<Entity> roomEntities = new List<Entity>();
        public char[,] Grid;

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
            AddWall(new Coordinate(0, 0), new Coordinate(20, 0));
            AddWall(new Coordinate(0, 0), new Coordinate(0, 10));
            AddWall(new Coordinate(0, 9), new Coordinate(20, 9));
            AddWall(new Coordinate(19, 0), new Coordinate(19, 10));
        }

        /// <summary>
        /// Generate a new room.
        /// </summary>
        /// <param name="SizeX">Width of the room</param>
        /// <param name="SizeY">Height of the room</param>
        public Room(int SizeX, int SizeY)
        {
            Grid = GenerateNewGrid(SizeX, SizeY);

        }

        public char[,] GenerateNewGrid(int SizeX, int SizeY)
        {
            char[,] newGrid = new char[SizeY, SizeX];

            for (int i = 0; i < newGrid.GetLength(0); i++)
            {
                for (int j = 0; j < newGrid.GetLength(1); j++)
                {
                    newGrid[i, j] = '.';
                }
            }

            return newGrid;
        }

        /// <summary>
        /// Generate wall between two coordinates
        /// </summary>
        /// <param name="start"></param>
        /// <param name="end"></param>
        public void AddWall(Coordinate start, Coordinate end)
        {

            if (start.posX == end.posX)
            {
                for (int i = start.posY; i < end.posY; i++)
                {
                    Grid[i, start.posX] = '#';
                }
            }
            else if (start.posY == end.posY)
            {
                for (int i = start.posX; i < end.posX; i++)
                {
                    Grid[start.posY, i] = '#';
                }
            }

            // TODO: Calculate non-straight walls.
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
                Grid[e.Location.posX, e.Location.posY] = e.Symbol;

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

    public enum RoomShape { TShape, Corridor, Circle }

    public struct Coordinate
    {
        public int posX, posY;

        public Coordinate(int posX, int posY)
        {
            this.posX = posX;
            this.posY = posY;            
        }        

        public bool Equals(Coordinate c)
        {
            if (posX == c.posX && posY == c.posY)
                return true;
            else
                return false;
        }

    }
}
