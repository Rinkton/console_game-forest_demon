using Game.IO;

namespace Game.Items.Armors
{
    class NormalClothes : Armor
    {
        public NormalClothes()
        {
            Name = TextResources.GetStringByResourceName("normal clothes");
            Defense = 3;
        }
    }
}
