using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Прошлая версия игры использовала для рандома дробные числа,
    /// здесь же решено было использовать проценты, но их весьма проблематично конвертировать,
    /// потому здесь будет единый метод конвертации.
    /// Если что-то не понятно посмотрите в тесты.
    /// </summary>
    public static class FractionToPercentConverter
    {
        public static int Divider = 9;

        public static int GetPercent(int dividend) => Convert.ToInt32((dividend * 100) / Divider);
    }
}
