using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Items;

namespace Game.Shop.CommodityItems.Armors
{
    abstract class Armor : Item
    {
        public override void Initialize()
        {
            ItemsByItsType = ImportantObjectsKeeper.StepanStock.Armors;
            DefaultItemByItsType = new Items.Armors.IvanRags();
        }

        protected override void PutItemToPlayer(Items.Item item)
        {
            ImportantObjectsKeeper.Player.Armor = (Items.Armors.Armor)item;
        }
    }
}
