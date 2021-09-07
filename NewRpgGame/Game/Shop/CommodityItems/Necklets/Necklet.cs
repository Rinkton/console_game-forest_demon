using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shop.CommodityItems.Necklets
{
    abstract class Necklet : Item
    {
        public override void Initialize()
        {
            ItemsByItsType = ImportantObjectsKeeper.StepanStock.Necklets;
            DefaultItemByItsType = new Items.Necklets.NullNecklet();
        }

        protected override void PutItemToPlayer(Items.Item item)
        {
            ImportantObjectsKeeper.Player.Necklet = (Items.Necklets.Necklet)item;
        }
    }
}
