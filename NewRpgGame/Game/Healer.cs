using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Healer
    {
        public readonly int HealCost = 10;

        public readonly int StartHealingPotionCost = 30;
        public readonly int MaxHealingPotionCount = 5;

        public int GetActualHealingPotionCost(int playerHealingPotionCount)
        {
            return StartHealingPotionCost * (playerHealingPotionCount + 1);
        }
    }
}
