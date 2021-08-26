using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.StoryTellings
{
    class StoryTell
    {
        protected void Run(string resourceGroupName)
        {
            string[] strings = IO.TextResources.GetStringsByResourceGroupName(resourceGroupName);
            tell(strings);
        }
        
        private void tell(string[] strings)
        {
            foreach(string str in strings)
            {
                Console.Clear();
                ConsoleWriter.WriteLine(new Str(str));
                Console.ReadKey();
            }
            Console.Clear();
        }
    }
}
