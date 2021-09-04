using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class Shop : GameEvent
    {
        //TODO: А вот номера вариков не окрашиваются вместе с Str!
        //TODO: Сделать, чтобы при покупке предметы активизировались не только в магазе, но и в статистике Ивана
        public override void Run()
        {
            new Menus.Shop().Run();
        }
    }
}
