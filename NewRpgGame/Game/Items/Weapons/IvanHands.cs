using Game.IO;

namespace Game.Items.Weapons
{
    class IvanHands : Weapon
    {
        public IvanHands()
        {
            Name = TextResources.GetStringByResourceName("ivan hands");
            Damage = 10;
        }
    }
}
