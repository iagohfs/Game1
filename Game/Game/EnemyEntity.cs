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

        public bool Move(int distance)
        {
            if (IsAlive)
            {
                /*
                if (MoveCol(distance))
                {
                    return true;
                }
                else if (MoveRow(-distance))
                {
                    return true;
                }
                else if (MoveRow(-distance))
                {
                    return true;
                }
                else if (MoveCol(-distance))
                {
                    return true;
                }*/

                if (MoveEast(distance))
                {
                    if (MoveSouth(distance))
                    {

                    }
                    else
                    {
                        MoveSouth(-distance);
                    }
                }
                else
                {
                    MoveEast(-distance);
                }

                return false;

            }

            return false;
        }

    }
}
