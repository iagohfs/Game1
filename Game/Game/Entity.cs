using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    public abstract class Entity : IEntity
    {
        // The character that represents the entity
        public char Symbol { get; protected set; }

        public void Draw()
        {
            // Do draw stuff
        }


    }
}
