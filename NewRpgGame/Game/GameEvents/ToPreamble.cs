using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class ToPreamble : GameEvent
    {
        public void Run()
        {
            new StoryTellings.Preamble().Run();
            new ToMainMenu().Run();
        }
    }
}
