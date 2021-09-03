using System;
using System.Text;
using Game.IO;

namespace Game.Shop.CommodityItems
{
    /// <summary>
    /// Товарный предмет. Предмет, который может продаваться в магазине
    /// </summary>
    public abstract class Item
    {
        public virtual Items.Item _Item { get; protected set; }

        public string Properties { get; protected set; }

        public int Cost { get; protected set; }

        public State State { get; protected set; }

        /// <summary>
        /// Как описывает товар купец Степан этот товар
        /// </summary>
        public string StepanDescription { get; protected set; }

        /// <example>Структура наименования строится по принципу: name (properties) - cost монет.
        /// properties здесь могут и не существовать, если предмет не обладает какими либо явными характеристиками.
        /// Также на всё влияет текущий <see cref="State"/>, от него зависит, какого цвета будет наименование
        /// и также если предмет уже куплен или экипирован, то его цена отображаться не будет</example>
        /// <returns></returns>
        public Str GetStrNomination()
        {
            StringBuilder SBNomination = new StringBuilder();

            SBNomination.Append($"{_Item.Name}");

            if(Properties != null)
            {
                SBNomination.Append($" ({Properties})");
            }

            if(State == State.InStock)
            {
                SBNomination.Append($" - {Cost} {TextResources.GetStringByResourceName("coins")}");
            }

            ConsoleColor color = ConsoleColor.Gray;

            switch(State)
            {
                case State.InStock:
                    color = ConsoleColor.Gray;
                    break;
                case State.Bought:
                    color = ConsoleColor.DarkYellow;
                    break;
                case State.Equiped:
                    color = ConsoleColor.Yellow;
                    break;
            }

            return new Str(SBNomination.ToString(), color);
        }
    }
}
