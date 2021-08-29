using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//TODO: Using чего-то, чтобы длинные не писать
namespace Game.Player.HitTypes
{
    /// <summary>
    /// Тип удара, выбранный игроком
    /// </summary>
    public abstract class HitType
    {
        public Hit Miss { get; protected set; }
        public Hit Weak { get; protected set; }
        public Hit Normal { get; protected set; }
        public Hit Strong { get; protected set; }

        /// <summary>
        /// В зависимости от полученного значения процента возвращает определённый <see cref="HitResult"/>
        /// </summary>
        /// <param name="luckPercent">Параметр необязательный, не задавайте. В случае, если вы не задаёте,
        /// то функция сама берёт рандомное число, однако вы можете задать своё число, нерандомное,
        /// но это нужно только для тестирования функции</param>
        /// <returns></returns>
        public HitResult GetHitResult(int luckPercent=-1)
        {
            if (luckPercent == -1)
            {
                luckPercent = new Random().Next(0, 100);
            }

            int previousPercent = 0;
            int nextPercent = 0;

            if(Miss != null)
            {
                previousPercent = nextPercent;
                nextPercent += Miss.PercentChance;
                if(luckPercent < nextPercent)
                {
                    return Miss.HitResult;
                }
            }
            if(Weak != null)
            {
                previousPercent = nextPercent;
                nextPercent += Weak.PercentChance;
                if(luckPercent < nextPercent)
                {
                    return Weak.HitResult;
                }
            }
            if(Normal != null)
            {
                previousPercent = nextPercent;
                nextPercent += Normal.PercentChance;
                if(luckPercent < nextPercent)
                {
                    return Normal.HitResult;
                }
            }
            if(Strong != null)
            {
                previousPercent = nextPercent;
                nextPercent += Strong.PercentChance;
                if(luckPercent < nextPercent)
                {
                    return Strong.HitResult;
                }
            }

            throw new Exception("Исходя из данного процента функция не в состоянии вернуть какой либо результат");
        }
    }
}
