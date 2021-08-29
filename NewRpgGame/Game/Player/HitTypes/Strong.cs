using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player.HitTypes
{
    public class Strong : HitType
    {
        public Strong()
        {
            string className = "strong";
            Miss = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} miss"), 0), FractionToPercentConverter.GetPercent(5));
            Strong = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} strong"), 2), FractionToPercentConverter.GetPercent(4));
        }
    }
}
