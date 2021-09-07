
namespace Game.Shop.CommodityItems.Weapons
{
    abstract class Weapon : Item
    {
        public override void Initialize()
        {
            ItemsByItsType = ImportantObjectsKeeper.StepanStock.Weapons;
            DefaultItemByItsType = new Items.Weapons.IvanHands();
        }

        protected override void PutItemToPlayer(Items.Item item)
        {
            ImportantObjectsKeeper.Player.Weapon = (Items.Weapons.Weapon)item;
        }
    }
}
