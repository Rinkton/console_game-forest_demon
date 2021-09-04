using Game.IO;

namespace Game.Shop.CommodityItems.Armors
{
    class NormalClothes : Armor
    {
        public NormalClothes()
        {
            Items.Armors.NormalClothes concreteItem = new Items.Armors.NormalClothes();
            _Item = new Items.Armors.NormalClothes();
            GenetiveName = TextResources.GetStringByResourceName("normal clothes genitive");
            Properties = TextResources.GetStringByResourceName("non specific armor properties").Replace("*", concreteItem.Defense.ToString());
            Cost = 25;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description normal clothes");
        }
    }
}
