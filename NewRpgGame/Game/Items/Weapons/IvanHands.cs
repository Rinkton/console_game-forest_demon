using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Weapons
{
    class IvanHands : Weapon
    {
        public IvanHands()
        {
            Name = IO.TextResources.GetStringByResourceName("ivan hands");
            Damage = 10;
        }
    }
}
