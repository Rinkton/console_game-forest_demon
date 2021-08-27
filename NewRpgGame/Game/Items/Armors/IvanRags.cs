using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Game.GameEvents;

namespace Game.Items.Armors
{
    class IvanRags : Armor
    {
        public IvanRags()
        {
            Name = IO.TextResources.GetStringByResourceName("ivan rags");
            Defense = 0;
        }
    }
}
