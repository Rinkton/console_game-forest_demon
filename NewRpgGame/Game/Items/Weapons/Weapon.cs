﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Items.Weapons
{
    abstract class Weapon : Item
    {
        public int Damage { get; protected set; }
    }
}
