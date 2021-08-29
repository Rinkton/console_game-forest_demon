using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player.HitTypes
{
    public class Normal : HitType
    {
        public Normal()
        {
            string className = "normal";
            Miss = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} miss"), 0), FractionToPercentConverter.GetPercent(2));
            Weak = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} weak"), 0.5f), FractionToPercentConverter.GetPercent(1));
            Normal = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} normal"), 1), FractionToPercentConverter.GetPercent(3));
            Strong = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} strong"), 1.5f), FractionToPercentConverter.GetPercent(3));
        }
    }
}
