using Game.IO;

namespace Game.Shop.CommodityItems.Weapons
{
    class Club : Weapon
    {
        public Club()
        {
            Items.Weapons.Club concreteItem = new Items.Weapons.Club();
            _Item = new Items.Weapons.Club();
            GenetiveName = TextResources.GetStringByResourceName("club genitive");
            Properties = TextResources.GetStringByResourceName("non specific weapon properties").Replace("*", concreteItem.Damage.ToString());
            Cost = 20;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description club");
        }
    }
}
