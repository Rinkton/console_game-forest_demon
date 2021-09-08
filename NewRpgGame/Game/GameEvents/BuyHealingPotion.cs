using System;
using Game.IO;

namespace Game.GameEvents
{
    class BuyHealingPotion : GameEvent
    {
        public override void Run()
        {
            if(ImportantObjectsKeeper.Player.HealingPotionCount < ImportantObjectsKeeper.Healer.MaxHealingPotionCount)
            {
                if(ImportantObjectsKeeper.Healer.GetActualHealingPotionCost(ImportantObjectsKeeper.Player.HealingPotionCount) <= ImportantObjectsKeeper.Player.Money)
                {
                    ImportantObjectsKeeper.Player.Money -= ImportantObjectsKeeper.Healer.GetActualHealingPotionCost(ImportantObjectsKeeper.Player.HealingPotionCount);
                    ImportantObjectsKeeper.Player.HealingPotionCount++;
                    ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("you bought healing potion"), ConsoleColor.Yellow));
                }
                else
                {
                    ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("pankrat too low money to buy healing potion"), ConsoleColor.Red));
                }
            }
            else
            {
                ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("pankrat healing potions ended"), ConsoleColor.Red));
            }

            InputHandler.WaitKey();
            new ReallyBuyHealingPotion().Run();
        }
    }
}
