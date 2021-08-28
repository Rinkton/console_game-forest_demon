using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.CommodityItems
{
    /// <summary>
    /// Товарный предмет. Предмет, который может продаваться в магазине
    /// </summary>
    abstract class Item
    {
        public int Cost { get; protected set; }

        /// <summary>
        /// Как описывает товар купец Степан этот товар
        /// </summary>
        public string StepanDescription { get; protected set; }

        /// <summary>
        /// Наименование, что пишется в меню выбора насчёт товара
        /// </summary>
        public string Nomination { get; protected set; }
    }
}
