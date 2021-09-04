using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shop.CommodityItems.Armors
{
    abstract class Armor : Item
    {
        public override void Equip()
        {
            foreach(Item commodityItem in ImportantObjectsKeeper.StepanStock.Armors)
            {
                IfStateIsEquipedThenRemove(commodityItem);
            }

            State = State.Equiped;
        }
    }
}
