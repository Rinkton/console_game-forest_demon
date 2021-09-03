using System;
using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    class MainMenu : Menu
    {
        public void Run()
        {
            ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("game name"), ConsoleColor.Red));
            Choice[] choices =
                new Components.Choice[]
                {
                    new Choice(new Str(TextResources.GetStringByResourceName("start game")), new GameEvents.GameMenu()),
                    //TODO: Если сэйва нет, то кнопка потухает
                    new Choice(new Str(TextResources.GetStringByResourceName("continue game")), new GameEvents.LoadGame()),
                    new Choice(new Str(TextResources.GetStringByResourceName("exit game")), new GameEvents.ExitGame()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                startNumber:startNumber
                );
            ConsoleWriter.WriteLine(new Str(""));
            ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("developer vk"), ConsoleColor.Blue));
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
