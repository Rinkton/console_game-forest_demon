using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Shop
{
    abstract class Stock
    {
        #region item types
        public CommodityItems.Weapons.Weapon[] Weapons { get; protected set; }

        public CommodityItems.Armors.Armor[] Armors { get; protected set; }

        public CommodityItems.Necklets.Necklet[] Necklets { get; protected set; }

        public CommodityItems.Item[] Others { get; protected set; }
        #endregion

        public CommodityItems.Item[] GetItems()
        {
            List<CommodityItems.Item> itemList = new List<CommodityItems.Item>();

            itemList.AddRange(Weapons.Select(concreteItem => (CommodityItems.Item)concreteItem));
            itemList.AddRange(Armors.Select(concreteItem => (CommodityItems.Item)concreteItem));
            itemList.AddRange(Necklets.Select(concreteItem => (CommodityItems.Item)concreteItem));
            itemList.AddRange(Others.Select(concreteItem => (CommodityItems.Item)concreteItem));

            return itemList.ToArray();
        }

        public void EquipThisItem(CommodityItems.Item commodityItem)
        {
            foreach(CommodityItems.Item someCommodityItem in GetItems())
            {
                if(commodityItem.GetType() == someCommodityItem.GetType())
                {
                    someCommodityItem.ChangeState(CommodityItems.State.Equiped);
                }
            }
        }

        public void InitializeAll()
        {
            foreach(CommodityItems.Item item in GetItems())
            {
                item.Initialize();
            }
        }
    }
}
