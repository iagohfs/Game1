using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Character : MovableEntity
    {
        public Character()
        {

        }

        public string Name(string name)
        {
            string[] addName = new string[1];
            addName[0] = name;
            return "Your Character name is: " + addName[0];
        }

        public bool IsAlive()
        {
            return true;
        }

    }

}
