using Game.IO;

namespace Game.Items.Necklets
{
    class NullNecklet : Necklet
    {
        public NullNecklet()
        {
            Name = TextResources.GetStringByResourceName("not exist");
        }
    }
}
