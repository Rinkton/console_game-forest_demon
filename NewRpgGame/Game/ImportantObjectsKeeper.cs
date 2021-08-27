using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Хранит актуальные объекты, которые полезны другим для их корректной работы
    /// </summary>
    static class ImportantObjectsKeeper
    {
        public static Player Player = new Player();
    }
}
