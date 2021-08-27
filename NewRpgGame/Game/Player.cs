using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    class Player
    {
        #region Отображаемые характеристики
        public int MaxHealth;
        public int CurrentHealth;
        public Items.Weapons.Weapon Weapon;
        public Items.Armors.Armor Armor;
        public Items.Necklets.Necklet Necklet;
        public int PunishmentPercent;
        public int Money;
        public int HealingPotionCount;
        #endregion

        //Шансы в процентах на какой-либо определённый вид удара:
        public int MissPercentChance;
        public int WeakPercentChance;
        public int NormalPercentChance;
        public int StrongPercentChance;
    }
}
