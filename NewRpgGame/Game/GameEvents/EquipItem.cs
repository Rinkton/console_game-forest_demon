using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class EquipItem : GameEvent
    {
        /// <param name="args">
        /// 0 - Товар, который необходимо экипировать
        /// </param>
        public EquipItem(params object[] args) : base(args) { }

        public override void Run()
        {
            Game.Shop.CommodityItems.Item commodityItem = (Game.Shop.CommodityItems.Item)Args[0];
            commodityItem.Equip();
            new Shop().Run();
        }
    }
}
