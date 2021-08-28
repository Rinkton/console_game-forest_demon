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
    public class Hit
    {
        public readonly HitResult HitResult;
        public readonly int PercentChance;

        public Hit(HitResult hitResult, int percentChance=0)
        {
            HitResult = hitResult;
            PercentChance = percentChance;
        }
    }
}
