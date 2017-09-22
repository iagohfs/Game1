using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class MovableEntity : Entity
    {
        public bool MoveUp(int distance) // If you move a negative distance you do down. Reduces the number if methods
        {

            return true;
        }

        public bool MoveRight(int distance)
        {

            return true;
        }
    }
}
