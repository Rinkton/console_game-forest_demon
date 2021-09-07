using Game.IO;

namespace Game.Items.Weapons
{
    class Club : Weapon
    {
        public Club()
        {
            Name = TextResources.GetStringByResourceName("club");
            Damage = 13;
        }
    }
}
