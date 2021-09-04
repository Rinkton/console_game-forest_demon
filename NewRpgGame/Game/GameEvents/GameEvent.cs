using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    public abstract class GameEvent
    {
        /// <summary>
        /// Аргументы, нужные для игрового события.
        /// Осторожно! - динамическая типизация!
        /// </summary>
        protected readonly object[] Args;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="args">Аргументы, нужные для игрового события</param>
        public GameEvent(params object[] args)
        {
            Args = args;
        }

        public virtual void Run()
        {
            throw new NotImplementedException();
        }
    }
}
