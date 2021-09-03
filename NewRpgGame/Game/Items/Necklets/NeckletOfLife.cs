using Game.IO;

namespace Game.Items.Necklets
{
    class NeckletOfLife : Necklet
    {
        public int MaxHealthAddition { get; protected set; }

        public NeckletOfLife()
        {
            Name = TextResources.GetStringByResourceName("necklet of life");
            MaxHealthAddition = 50;
        }
    }
}
