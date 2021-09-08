using System;
using Game.IO;
using Game.Menus.Components;

namespace Game.Menus
{
    class ReallyBuyHealingPotion : Menu
    {
        public void Run()
        {
            ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("pankrat about healing potions"), ConsoleColor.Red));

            Str buyHealingPotionStr;
            if(ImportantObjectsKeeper.Player.HealingPotionCount >= ImportantObjectsKeeper.Healer.MaxHealingPotionCount)
            {
                buyHealingPotionStr = new Str(TextResources.GetStringByResourceName("buy healing potion"));
            }
            else
            {
                string stringHealingPotionCost = (ImportantObjectsKeeper.Healer.GetActualHealingPotionCost(ImportantObjectsKeeper.Player.HealingPotionCount)).ToString();
                buyHealingPotionStr = new Str(TextResources.GetStringByResourceName("buy healing potion with cost").Replace("*", stringHealingPotionCost));
            }

            Choice[] choices =
                new Choice[]
                {
                    new Choice(buyHealingPotionStr, new GameEvents.BuyHealingPotion()),
                    new Choice(new Str(TextResources.GetStringByResourceName("cancel")), new GameEvents.Healer()),
                };
            int startNumber = 1;

            base.Visualize(
                choices
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
