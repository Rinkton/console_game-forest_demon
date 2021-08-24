using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Просто класс с string, но ещё и обладающий полем для определения цвета
    /// </summary>
    public class Str
    {
        public readonly string Text;

        public readonly ConsoleColor Color;

        public Str(string text, ConsoleColor color=ConsoleColor.Gray)
        {
            Text = text;
            Color = color;
        }
    }
}
