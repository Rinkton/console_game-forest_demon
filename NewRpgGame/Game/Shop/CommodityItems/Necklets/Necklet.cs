using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shop.CommodityItems.Necklets
{
    abstract class Necklet : Item
    {
        public override void Equip()
        {
            foreach(Item commodityItem in ImportantObjectsKeeper.StepanStock.Necklets)
            {
                IfStateIsEquipedThenRemove(commodityItem);
            }

            State = State.Equiped;
        }
    }
}
