using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Enemies
{
    //TODO: И все же надо сделать все такие вот класса типа Enemy абстрактными
    class Enemy
    {
        public string Name;
        public string Description;
        public int Health;
        public int Damage;
        public int Defense;
        /// <summary>
        /// Среднее кол-во монет, коеи можно получить, победив этого врага
        /// </summary>
        public int AverageLoot;

        //Шансы в процентах на какой-либо определённый вид удара:
        public int MissPercentChance;
        public int WeakPercentChance;
        public int NormalPercentChance;
        public int StrongPercentChance;
    }
}
