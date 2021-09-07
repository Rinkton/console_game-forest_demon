using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.Items;

namespace Game.Shop.CommodityItems.Others
{
    public class NullItem : CommodityItems.Item
    {
        protected override void PutItemToPlayer(Items.Item item)
        {
            throw new NotImplementedException();
        }
    }
}
