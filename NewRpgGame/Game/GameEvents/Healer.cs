﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class Healer : GameEvent
    {
        public override void Run()
        {
            new Menus.Healer().Run();
        }
    }
}
