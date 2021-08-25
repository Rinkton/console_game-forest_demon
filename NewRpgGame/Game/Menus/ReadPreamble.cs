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
            base.Run(
                new Components.Choice[]
                {
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("yes")), new GameEvents.ToPreamble()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("no")), new GameEvents.ToMainMenu()),
                },
                IO.TextResources.GetStringByResourceName("want preamble")
                );
        }
    }
}
