using Game.IO;

namespace Game.Shop.CommodityItems.Others
{
    class CrypticOrb : Item
    {
        public override void Initialize()
        {
            _Item = new Items.Others.CrypticOrb();
            GenetiveName = TextResources.GetStringByResourceName("cryptic orb genitive");
            Cost = 550;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description cryptic orb");
            ItemsByItsType = ImportantObjectsKeeper.StepanStock.Others;
            DefaultItemByItsType = new Items.Others.NullItem();
        }

        protected override void PutItemToPlayer(Items.Item item)
        {
            ImportantObjectsKeeper.Player.CrypticOrb = (Items.Others.CrypticOrb)item;
        }
    }
}
