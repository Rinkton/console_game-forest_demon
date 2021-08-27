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

        //TODO: Стоп... так у него не так ведь система ударов работает!
        //Шансы в процентах на какой-либо определённый вид удара:
        public int MissPercentChance;
        public int WeakPercentChance;
        public int NormalPercentChance;
        public int StrongPercentChance;

        public Player()
        {
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Weapon = new Items.Weapons.IvanHands();
            Armor = new Items.Armors.IvanRags();
            Necklet = new Items.Necklets.NullNecklet();
            PunishmentPercent = 0;
            Money = 0;
            HealingPotionCount = 0;
        }
    }
}
