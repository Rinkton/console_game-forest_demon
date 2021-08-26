using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Weapons
{
    class Weapon : Item
    {
        protected int Damage;

        public Weapon(GameEvents.GameEvent wearing, GameEvents.GameEvent @using, int damage) : base(wearing, @using)
        {
            Damage = damage;
        }
    }
}
