using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player.HitTypes
{
    /// <summary>
    /// Тип удара, выбранный игроком
    /// </summary>
    class HitType
    {
        public Hit Miss { get; protected set; }
        public Hit Weak { get; protected set; }
        public Hit Normal { get; protected set; }
        public Hit Strong { get; protected set; }

        //TODO: Needa to create test for some HitType
        /// <summary>
        /// Рандомит, и в зависимости от рандома выдаёт свой множитель урона
        /// </summary>
        /// <returns></returns>
        public int GetDamageMultipler()
        {
            return 0;
        }
    }
}
