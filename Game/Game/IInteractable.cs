using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    interface IInteractable
    {
        bool Interact();
        bool Interact(ItemKey k);
    }
}
