using Game.IO;

namespace Game.Shop.CommodityItems.Necklets
{
    class NeckletOfLife : Necklet
    {
        public NeckletOfLife()
        {
            Items.Necklets.NeckletOfLife concreteItem = new Items.Necklets.NeckletOfLife();
            _Item = new Items.Necklets.NeckletOfLife();
            Properties = TextResources.GetStringByResourceName("max health addition properties").Replace("*", concreteItem.MaxHealthAddition.ToString());
            Cost = 500;
            State = State.InStock;
            StepanDescription = TextResources.GetStringByResourceName("stepan description necklet of life");
        }
    }
}
