using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyEntity : MovableEntity
    {

        public bool IsAlive = true;

        public EnemyEntity(int enemCol, int enemRow, ConsoleColor enemColor, char enemSymb)
        {
            Location.posCol = enemCol;
            Location.posRow = enemRow;
            Color = enemColor;
            Symbol = enemSymb;
            Collidable = false;
            IsVisible = true;

        }

        private bool X = true, Y = true;
        private int distX = 5, distY = 0;
        private int Xmax = 5, Xmin = 0, Ymax = 2, Ymin = 0;

        public bool Move(int distance)
        {

            if (IsAlive)
            {
                if (X)
                {
                    MoveEast(distance);
                    if (distX != Xmax)
                    {
                        distX++;
                    }
                    else
                    {
                        X = false;
                        distX--;
                    }
                }
                else if (!X)
                {
                    MoveEast(-distance);
                    if (distX != Xmin)
                    {
                        distX--;
                    }
                    else
                    {
                        X = true;
                        distX++;
                    }
                }
                else if (Y)
                {

                    MoveSouth(-distance);
                    if (distY != Ymax)

                    {
                        distY++;
                    }
                    else
                    {

                        X = false;
                        distY--;
                    }
                }
                else if (!Y)
                {

                    MoveSouth(distance);
                    if (distY != Ymin)
                    {
                        distY--;
                    }
                    else
                    {
                        X = false;
                        distY++;
                    }
                }

                return false;

            }

            return false;
        }

    }
}
