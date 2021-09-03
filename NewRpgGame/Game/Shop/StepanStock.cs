using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shop
{
    class StepanStock : Stock
    {
        public StepanStock()
        {
            Weapons = new CommodityItems.Weapons.Weapon[]
            {
                new CommodityItems.Weapons.Club(),
                new CommodityItems.Weapons.Blade(),
            };
            Armors = new CommodityItems.Armors.Armor[]
            {
                new CommodityItems.Armors.NormalClothes(),
            };
            Necklets = new CommodityItems.Necklets.Necklet[]
            {
                new CommodityItems.Necklets.NeckletOfLife(),
            };
            Others = new CommodityItems.Item[]
            {
                new CommodityItems.Others.CrypticOrb()
            };
        }
    }
}
