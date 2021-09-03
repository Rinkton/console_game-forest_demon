using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    class GameMenu : Menu
    {
        public void Run()
        {
            Choice[] choices =
                new Choice[]
                {
                    new Choice(new Str(TextResources.GetStringByResourceName("walk in forest")), new GameEvents.Fight()),
                    new Choice(new Str(TextResources.GetStringByResourceName("go to stepan shop")), new GameEvents.Shop()),
                    new Choice(new Str(TextResources.GetStringByResourceName("check ivan statistics")), new GameEvents.Statistics()),
                    new Choice(new Str(TextResources.GetStringByResourceName("go to pankrat the healer")), new GameEvents.Healer()),
                    new Choice(new Str(TextResources.GetStringByResourceName("save game")), new GameEvents.SaveGame()),
                    new Choice(new Str(TextResources.GetStringByResourceName("exit game")), new GameEvents.ExitGame()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                TextResources.GetStringByResourceName("what do you want to do in this village for now"),
                startNumber: startNumber
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
