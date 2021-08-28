using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Каков множитель урона и описание у удара - эту информацию несёт в себе этот DTO
    /// </summary>
    public class HitResult
    {
        public readonly float DamageMultiplier;

        public readonly string Description;

        public HitResult(string description, float damageMultiplier = 0)
        {
            Description = description;
            DamageMultiplier = damageMultiplier;
        }
    }
}
