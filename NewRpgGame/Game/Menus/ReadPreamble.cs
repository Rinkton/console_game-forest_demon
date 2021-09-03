using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    /// <summary>
    /// Меню выбора, читать предисловие иль нет
    /// </summary>
    class ReadPreamble : Menu
    {
        public void Run()
        {
            Choice[] choices =
                new Choice[]
                {
                    new Choice(new Str(TextResources.GetStringByResourceName("yes")), new GameEvents.Preamble()),
                    new Choice(new Str(TextResources.GetStringByResourceName("no")), new GameEvents.MainMenu()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                TextResources.GetStringByResourceName("want preamble"),
                startNumber:startNumber
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
