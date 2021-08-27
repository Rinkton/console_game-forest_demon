using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Enemies
{
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

        public Hit Miss { get; protected set; }
        public Hit Weak { get; protected set; }
        public Hit Normal { get; protected set; }
        public Hit Strong { get; protected set; }
    }
}
