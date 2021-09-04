using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    public abstract class Item
    {
        public string Name { get; protected set; }

        /// <summary>
        /// Событие, которое происходит при экипировании(создании экземпляра) предмета
        /// </summary>
        public GameEvents.GameEvent Equiping { get; protected set; }

        /// <summary>
        /// Событие, которое происходит при использовании предмета 
        /// (Например удар по игроку вызывает событие у брони, когда же удар по врагу вызывает событие у оружия)
        /// </summary>
        public GameEvents.GameEvent Using { get; protected set; }

        //TODO: Сделать настоящий Event чтобы вызывать Using
    }
}
