using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class LookCommodityItem : GameEvent
    {
        /// <param name="args">0 - Товар, на который необходимо взглянуть</param>
        public LookCommodityItem(params object[] args) : base(args) { }
        
        public override void Run()
        {
            new Menus.LookCommodityItem().Run((Game.Shop.CommodityItems.Item)Args[0]);
        }
    }
}
