using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class ConsoleWriter
    {
        public static void Write(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.Write(str.Text);
        }

        public static void WriteLine(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.WriteLine(str.Text);
        }

        /// <summary>
        /// Пишет в консоль все Str-s по порядку с помощью здешнего метода <see cref="Write(Str)"/>
        /// </summary>
        /// <param name="strs"></param>
        public static void WriteStrs(Str[] strs)
        {
            foreach(Str str in strs)
            {
                Write(str);
            }
        }
    }
}
