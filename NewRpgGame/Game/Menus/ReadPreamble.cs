using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    /// <summary>
    /// Меню выбора, читать предисловие иль нет
    /// </summary>
    class ReadPreamble : Menu
    {
        public void Run()
        {
            Components.Choice[] choices =
                new Components.Choice[]
                {
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("yes")), new GameEvents.Preamble()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("no")), new GameEvents.MainMenu()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                IO.TextResources.GetStringByResourceName("want preamble"),
                startNumber:startNumber
                );
            InputProcessing.RunChoice(choices, startNumber);
        }
    }
}
