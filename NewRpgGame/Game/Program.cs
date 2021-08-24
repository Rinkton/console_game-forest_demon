using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            //TODO: Menu of choice whether read preamble
            new StoryTellings.Preamble().Run();
        }
    }
}
