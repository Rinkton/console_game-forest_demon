using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Necklets
{
    class NullNecklet : Necklet
    {
        public NullNecklet()
        {
            Name = IO.TextResources.GetStringByResourceName("not exist");
        }
    }
}
