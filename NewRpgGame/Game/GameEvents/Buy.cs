using System;
using Game.IO;

namespace Game.GameEvents
{
    class Buy : GameEvent
    {
        /// <param name="args">
        /// 0 - Товар, который необходимо купить
        /// </param>
        public Buy(params object[] args) : base(args) { }

        public override void Run()
        {
            Game.Shop.CommodityItems.Item commodityItem = (Game.Shop.CommodityItems.Item)Args[0];

            if(ImportantObjectsKeeper.Player.Money < commodityItem.Cost)
            {
                ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("not enough money"), ConsoleColor.Red));
                InputHandler.WaitKey();
                new Shop().Run();
            }
            ImportantObjectsKeeper.Player.Money -= commodityItem.Cost;
            commodityItem.Equip(); // Да, сразу после покупки экипируем
            ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("you bought commodity item").Replace("*", commodityItem.GenetiveName), ConsoleColor.Yellow));
            InputHandler.WaitKey();

            new Shop().Run();
        }
    }
}
