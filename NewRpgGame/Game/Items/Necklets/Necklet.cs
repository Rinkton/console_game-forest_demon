using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Necklets
{
    class Necklet : Item
    {
        //Ну, от обычного предмета ожерелья ничем не отличаются, но ради красивой архитектуры...
        public Necklet(GameEvents.GameEvent wearing, GameEvents.GameEvent @using) : base(wearing, @using) { }
    }
}
