using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus.Components
{
    public class Section
    {
        public readonly Str Str;

        /// <summary>
        /// Номер элемента списка, перед коим и будет раздел
        /// </summary>
        public readonly int Number;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="str"></param>
        /// <param name="number">Число, на котором список должен быть разделён строкой Str</param>
        public Section(Str str, int number)
        {
            Str = str;
            Number = number;
        }
    }
}
