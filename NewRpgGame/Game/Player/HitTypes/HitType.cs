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

            //TODO: currentPercent - должен иметь более хорошее название
            int previousPercent = 0;
            int nextPercent = Miss.PercentChance;

            //TODO: А зачем проверять previousPercent? Всё ж и без этой доп. переменной и проверки можно сделать?
            //TODO: Здесь также должен быть > previousPercent, но на ноль тож проверяется, а может он и не нужен?
            if(Miss != null && luckPercent <= nextPercent)
            {
                return Miss.HitResult;
            }
            previousPercent = nextPercent;
            nextPercent += Weak.PercentChance;
            if(Weak != null && luckPercent > previousPercent && luckPercent <= nextPercent)
            {
                return Weak.HitResult;
            }
            previousPercent = nextPercent;
            nextPercent += Normal.PercentChance;
            if (Normal != null && luckPercent > previousPercent && luckPercent <= nextPercent)
            {
                return Normal.HitResult;
            }
            previousPercent = nextPercent;
            nextPercent += Strong.PercentChance;
            if (Strong != null && luckPercent > previousPercent && luckPercent <= nextPercent)
            {
                return Strong.HitResult;
            }

            throw new Exception("Исходя из данного процента функция не в состоянии вернуть какой либо результат");
        }
    }
}
