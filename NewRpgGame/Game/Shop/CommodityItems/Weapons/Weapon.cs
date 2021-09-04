
namespace Game.Shop.CommodityItems.Weapons
{
    abstract class Weapon : Item
    {
        public override void Equip()
        {
            foreach(Item commodityItem in ImportantObjectsKeeper.StepanStock.Weapons)
            {
                IfStateIsEquipedThenRemove(commodityItem);
            }

            State = State.Equiped;
        }
    }
}
