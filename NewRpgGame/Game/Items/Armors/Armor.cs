using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Armors
{
    abstract class Armor : Item
    {
        public int Defense { get; protected set; }
    }
}
