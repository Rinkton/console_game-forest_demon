using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player
{
    class Obj
    {
        public int MaxHealth;
        public int CurrentHealth;
        public Items.Weapons.Weapon Weapon;
        public Items.Armors.Armor Armor;
        public Items.Necklets.Necklet Necklet;
        public int PunishmentPercent;
        public int Money;
        public int HealingPotionCount;

        public Obj()
        {
            MaxHealth = 100;
            CurrentHealth = MaxHealth;
            Weapon = new Items.Weapons.IvanHands();
            Armor = new Items.Armors.IvanRags();
            Necklet = new Items.Necklets.NullNecklet();
            PunishmentPercent = 0;
            Money = 500;
            HealingPotionCount = 0;
        }
    }
}
