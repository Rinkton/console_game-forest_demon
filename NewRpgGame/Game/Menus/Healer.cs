using System;
using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    class Healer : Menu
    {
        public void Run()
        {
            ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("pankrat what do you need"), ConsoleColor.Red));
            Choice[] choices =
                new Choice[]
                {
                    new Choice(new Str(TextResources.GetStringByResourceName("heal me").Replace("*", ImportantObjectsKeeper.Healer.HealCost.ToString())), new GameEvents.Heal()),
                    new Choice(new Str(TextResources.GetStringByResourceName("i want to buy healing potions")), new GameEvents.ReallyBuyHealingPotion()),
                    new Choice(new Str(TextResources.GetStringByResourceName("exit")), new GameEvents.GameMenu()),
                };
            int startNumber = 1;

            base.Visualize(
                choices
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
