using Game.IO;

namespace Game.Shop.CommodityItems.Others
{
    class CrypticOrb : Item
    {
        public CrypticOrb()
        {
            _Item = new Items.Others.CrypticOrb();
            GenetiveName = TextResources.GetStringByResourceName("cryptic orb genitive");
            Cost = 550;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description cryptic orb");
        }
    }
}
