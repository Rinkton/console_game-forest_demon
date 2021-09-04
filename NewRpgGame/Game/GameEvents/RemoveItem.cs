﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class RemoveItem : GameEvent
    {
        /// <param name="args">
        /// 0 - Товар, который необходимо убрать
        /// </param>
        public RemoveItem(params object[] args) : base(args) { }

        public override void Run()
        {
            Game.Shop.CommodityItems.Item commodityItem = (Game.Shop.CommodityItems.Item)Args[0];
            commodityItem.Remove();
            new Shop().Run();
        }
    }
}
