using Game.IO;

namespace Game.Player.HitTypes
{
    public class Strong : HitType
    {
        public Strong()
        {
            string className = "strong";
            Miss = new Hit(new HitResult(TextResources.GetStringByResourceName($"{className} miss"), 0), FractionToPercentConverter.GetPercent(5));
            Strong = new Hit(new HitResult(TextResources.GetStringByResourceName($"{className} strong"), 2), FractionToPercentConverter.GetPercent(4));
        }
    }
}
