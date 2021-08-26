using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Armors
{
    class Armor : Item
    {
        protected int Defense;

        public Armor(GameEvents.GameEvent wearing, GameEvents.GameEvent @using, int defense) : base(wearing, @using)
        {
            Defense = defense;
        }
    }
}
