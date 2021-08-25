using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.StoryTellings
{
    class Preamble : StoryTell
    {
        public void Run()
        {
            string resourceGroupName = "preamble";
            base.Run(resourceGroupName);
        }
    }
}
