using Game.IO;

namespace Game.Shop.CommodityItems.Weapons
{
    class Blade : Weapon
    {
        public Blade()
        {
            Items.Weapons.Blade concreteItem = new Items.Weapons.Blade();
            _Item = new Items.Weapons.Blade();
            Properties = TextResources.GetStringByResourceName("non specific weapon properties").Replace("*", concreteItem.Damage.ToString());
            Cost = 55;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description blade");
        }
    }
}
