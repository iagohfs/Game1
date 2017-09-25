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
        }
    }
}
