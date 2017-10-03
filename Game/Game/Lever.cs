using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Lever : Entity, IInteractable
    {

        Action<String> leverAction;
        String actionTarget;

        public Lever(Coordinate Location, ConsoleColor LevColor, Action<String> action, String actionTarget)
        {
            this.Location = Location;
            Color = LevColor;
            Symbol = '¬';
            Collidable = true;
            IsVisible = false;
            leverAction = action;
            this.actionTarget = actionTarget;

            World.CurrentRoom.AddRoomEntity(this);

        }

        public bool OnInteract(Player player)
        {
            if (leverAction != null)
            {
                leverAction(actionTarget);
                return true;
            }
            return false;
        }
    }
}
