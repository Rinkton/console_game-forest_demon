using System;
using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    class LookCommodityItem : Menu
    {
        public void Run(Game.Shop.CommodityItems.Item commodityItem)
        {
            ConsoleWriter.WriteLineWithLineBreak(new Str(commodityItem.GetStrNomination().Text, ConsoleColor.Yellow));
            ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("sure want buy this commodity item")));
            ConsoleWriter.WriteLineWithLineBreak(new Str(commodityItem.StepanDescription, ConsoleColor.DarkCyan));
            Choice[] choices =
                new Choice[]
                {
                    new Choice(new Str(TextResources.GetStringByResourceName("buy cost").Replace("*", commodityItem.Cost.ToString())), new GameEvents.Buy(commodityItem)),
                    new Choice(new Str(TextResources.GetStringByResourceName("cancel")), new GameEvents.Shop()),
                };
            int startNumber = 1;

            base.Visualize(
                choices
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
