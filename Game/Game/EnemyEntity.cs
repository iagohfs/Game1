using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyEntity : Character
    {


        public EnemyEntity(char enemSymb, Coordinate Location, ConsoleColor enemColor) : base(enemSymb, Location, enemColor)
        {
            Collidable = false;
            IsVisible = true;
            
        }

        public void Move()
        {

            if (IsAlive)
            {
                MoveEast(-1);
                UpdateVisible();

            }
        }

        public void UpdateVisible()
        {
            Entity[,] room = World.CurrentRoom.displayGrid;

            for (int i = Location.posRow - 1; i <= Location.posRow + 1; i++)
            {
                for (int j = Location.posCol - 1; j <= Location.posCol + 1; j++)
                {
                    room[i, j].IsVisible = true;
                }
            }

        }
        
    }
}
