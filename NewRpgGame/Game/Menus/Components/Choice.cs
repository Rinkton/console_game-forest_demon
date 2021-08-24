using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus.Components
{
    public class Choice
    {
        public readonly Str Str;

        /// <summary>
        /// Какое событие произойдёт, если этот выбор будет выбран?
        /// </summary>
        public readonly GameEvents.GameEvent GameEvent;

        public Choice(Str str, GameEvents.GameEvent gameEvent)
        {
            Str = str;
            GameEvent = gameEvent;
        }
    }
}
