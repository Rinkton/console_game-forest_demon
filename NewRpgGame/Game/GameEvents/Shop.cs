﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class Shop : GameEvent
    {
        public void Run()
        {
            new Menus.Shop().Run();
        }
    }
}
