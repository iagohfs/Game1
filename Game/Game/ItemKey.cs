﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class ItemKey : Entity, ICollectable
    {
        public ItemKey(int keyCol, int keyPos, ConsoleColor keyColor, char keySymb)
        {
            Location.posCol = keyCol;
            Location.posRow = keyPos;
            Color = keyColor;
            Symbol = keySymb;
            Collidable = false;
            IsVisible = false;

            World.CurrentRoom.AddRoomEntity(this);
        }

        public int PointValue => 100;

    }
}
