using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Характеристики удара, который может быть нанесён игроком или врагом
    /// </summary>
    class Hit
    {
        public readonly float DamageMultipler;
        public readonly int PercentChance;

        public Hit(float damageMultipler, int percentChance)
        {
            DamageMultipler = damageMultipler;
            PercentChance = percentChance;
        }
    }
}
