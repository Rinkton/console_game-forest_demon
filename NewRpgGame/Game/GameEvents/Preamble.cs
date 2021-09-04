using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class Preamble : GameEvent
    {
        public override void Run()
        {
            new StoryTellings.Preamble().Run();
            new MainMenu().Run();
        }
    }
}
