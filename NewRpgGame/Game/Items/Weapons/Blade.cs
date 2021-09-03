using Game.IO;

namespace Game.Items.Weapons
{
    class Blade : Weapon
    {
        public Blade()
        {
            Name = TextResources.GetStringByResourceName("blade");
            Damage = 8;
        }
    }
}
