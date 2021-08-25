using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items
{
    abstract class Item
    {
        //TODO: Сделать обязательные параметры в конструкторе
        /// <summary>
        /// Событие, которое происходит при надевании(создании экземпляра) предмета
        /// </summary>
        public readonly GameEvents.GameEvent Wearing;

        /// <summary>
        /// Событие, которое происходит при использовании предмета 
        /// (Например удар по игроку вызывает событие у брони, когда же удар по врагу вызывает событие у оружия)
        /// </summary>
        public readonly GameEvents.GameEvent Using;

        public Item()
        {
            Wearing.Run();
        }

        //TODO: Сделать настоящий Event чтобы вызывать Using
    }
}
