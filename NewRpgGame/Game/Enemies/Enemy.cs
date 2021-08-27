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
        public string Name { get; protected set; }
        public string Description { get; protected set; }
        public int Health { get; protected set; }
        public int Damage { get; protected set; }
        public int Defense { get; protected set; }
        /// <summary>
        /// Среднее кол-во монет, коеи можно получить, победив этого врага
        /// </summary>
        public int AverageLoot { get; protected set; }

        //Шансы в процентах на какой-либо определённый вид удара:
        public int MissPercentChance { get; protected set; }
        public int WeakPercentChance { get; protected set; }
        public int NormalPercentChance { get; protected set; }
        public int StrongPercentChance { get; protected set; }
    }
}
