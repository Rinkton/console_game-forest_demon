using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Player.HitTypes
{
    public class Weak : HitType
    {
        public Weak()
        {
            string className = "weak";
            Miss = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} miss"), 0), FractionToPercentConverter.GetPercent(1));
            Weak = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} weak"), 0.25f), FractionToPercentConverter.GetPercent(3));
            Normal = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} normal"), 0.75f), FractionToPercentConverter.GetPercent(2));
            Strong = new Hit(new HitResult(IO.TextResources.GetStringByResourceName($"{className} strong"), 1.25f), FractionToPercentConverter.GetPercent(3));
        }
    }
}
