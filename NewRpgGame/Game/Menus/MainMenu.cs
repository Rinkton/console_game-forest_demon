using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    class MainMenu : Menu
    {
        public void Run()
        {
            ConsoleWriter.WriteLineWithLineBreak(new Str(IO.TextResources.GetStringByResourceName("game name"), ConsoleColor.Red));
            Components.Choice[] choices =
                new Components.Choice[]
                {
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("start game")), new GameEvents.NewGame()),
                    //TODO: Если сэйва нет, то кнопка потухает
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("continue game")), new GameEvents.ContinueGame()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("exit game")), new GameEvents.ExitGame()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                startNumber:startNumber
                );
            ConsoleWriter.WriteLine(new Str(""));
            ConsoleWriter.WriteLine(new Str(IO.TextResources.GetStringByResourceName("developer vk"), ConsoleColor.Blue));
            InputProcessing.RunChoice(choices, startNumber);
        }
    }
}
