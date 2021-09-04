using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class GameMenu : GameEvent
    {
        public override void Run()
        {
            new Menus.GameMenu().Run();
        }
    }
}
