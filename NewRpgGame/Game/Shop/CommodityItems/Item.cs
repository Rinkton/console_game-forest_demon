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

        public string GenetiveName { get; protected set; }

        public string Properties { get; protected set; }

        public int Cost { get; protected set; }

        /// <summary>
        /// Как описывает товар купец Степан этот товар
        /// </summary>
        public string StepanDescription { get; protected set; }

        /// <summary>
        /// Все предметы в магазине такого же типа (смотрите <see cref="Stock"/>)
        /// </summary>
        public CommodityItems.Item[] ItemsByItsType { get; protected set; }

        public Items.Item DefaultItemByItsType { get; protected set; }

        public State State;

        public virtual void Initialize() { }

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

        public void ChangeState(State newState) => State = newState;

        public void Equip()
        {
            clearEquipmentOfItemType();
            State = State.Equiped;
            PutItemToPlayer(this._Item);
        }

        /// <remarks>
        /// Default - <see cref="DefaultItemByItsType"/>
        /// </remarks>
        public void RemoveAndEquipDefault()
        {
            clearEquipmentOfItemType();
            PutItemToPlayer(DefaultItemByItsType);
        }

        /// <summary>
        /// Всовывает себя в нужное поле <see cref="Player.Obj"/>
        /// </summary>
        protected abstract void PutItemToPlayer(Items.Item item);

        /// <summary>
        /// Убирает из экипировки все предметы этого типа
        /// </summary>
        /// <remarks>
        /// Item type - посмотрите в <see cref="Stock"/>
        /// </remarks>
        private void clearEquipmentOfItemType()
        {
            foreach(CommodityItems.Item commodityItem in ItemsByItsType)
            {
                if(commodityItem.State == State.Equiped)
                {
                    commodityItem.State = State.Bought;
                }
            }
        }
    }
}
