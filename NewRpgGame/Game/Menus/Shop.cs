using System;
using System.Collections.Generic;
using Game.IO;
using Game.Menus.Components;
using Game.Shop;
using Game.GameEvents;

namespace Game.Menus
{
    class Shop : Menu
    {
        public void Run()
        {
            //TODO: Если оружие уже куплено - цену показывать не надо. Если куплен просто предмет(загадочный шар), то его нельзя эквипнуть, он сразу жёлтый
            ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("stepan what do you want to buy"), ConsoleColor.DarkCyan));

            List<Choice> commodityItemChoices = new List<Choice>();
            commodityItemChoices.AddRange(getCommodityItemChoices());
            commodityItemChoices.Add(new Choice(new Str(TextResources.GetStringByResourceName("exit shop")), new GameEvents.GameMenu()));
            Choice[] choices = commodityItemChoices.ToArray();

            int startNumber = 1;
            Section[] sections = getSections(startNumber);

            base.Visualize(
                choices,
                sections: sections,
                tabulation: Tabulation.FourSpace,
                startNumber: startNumber
                );
            InputHandler.HandleChoice(choices, startNumber);
        }

        private Choice[] getCommodityItemChoices()
        {
            List<Choice> choiceList = new List<Choice>();

            foreach(Game.Shop.CommodityItems.Item commodityItem in new StepanStock().GetItems())
            {
                GameEvent gameEvent = new NullGameEvent();
                switch(commodityItem.State)
                {
                    case Game.Shop.CommodityItems.State.InStock:
                        gameEvent = new SureBuyItem();
                        break;
                    case Game.Shop.CommodityItems.State.Bought:
                        gameEvent = new WearItem();
                        break;
                    case Game.Shop.CommodityItems.State.Equiped:
                        gameEvent = new RemoveItem();
                        break;
                }

                choiceList.Add(new Choice(commodityItem.GetStrNomination(), gameEvent));
            }

            return choiceList.ToArray();
        }

        private Section[] getSections(int startNumber)
        {
            List<Section> sectionList = new List<Section>();

            int number = startNumber;
            StepanStock stepanStock = new StepanStock();

            sectionList.Add(new Section(new Str(TextResources.GetStringByResourceName("weapons"), ConsoleColor.Red), number));

            number += stepanStock.Weapons.Length;
            sectionList.Add(new Section(new Str(TextResources.GetStringByResourceName("armors"), ConsoleColor.Gray), number));

            number += stepanStock.Armors.Length;
            sectionList.Add(new Section(new Str(TextResources.GetStringByResourceName("necklets"), ConsoleColor.DarkMagenta), number));

            number += stepanStock.Necklets.Length;
            sectionList.Add(new Section(new Str(TextResources.GetStringByResourceName("others"), ConsoleColor.DarkGray), number));

            return sectionList.ToArray();
        }
    }
}
