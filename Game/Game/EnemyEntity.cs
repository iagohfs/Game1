using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class EnemyEntity : Character
    {
        public int Damage { get; set; }

        public EnemyEntity(char enemSymb, Coordinate Location, ConsoleColor enemColor, int dmg) : base(enemSymb, Location, enemColor)
        {
            Collidable = false;
            IsVisible = false;
            Damage = dmg;
        }

        public void Move()
        {
            if (IsAlive)
            {
                Random random = new Random();

                if (World.Player1.Location.IsAdjacent(Location))
                {
                    IsVisible = true;
                }

                System.Threading.Thread.Sleep(05);
                switch (random.Next(1, 8))
                {
                    case 1:
                        MoveSouth(-1);
                        break;

                    case 2:
                        MoveEast(-1);
                        break;

                    case 3:
                        MoveSouth(1);
                        break;

                    case 4:
                        MoveEast(1);
                        break;
                }

            }
        }
        
    }
}
