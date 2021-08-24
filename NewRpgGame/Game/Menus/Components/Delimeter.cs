using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus.Components
{
    /// <summary>
    /// Имеет string, который разделяет список на разделы и число, на котором этот список должен разделиться
    /// </summary>
    public class Delimeter
    {
        public readonly Str Str;

        public readonly int Number;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="number">Число, на котором список должен быть разделён строкой Str</param>
        public Delimeter(Str str, int number)
        {
            Str = str;
            Number = number;
        }
    }
}
