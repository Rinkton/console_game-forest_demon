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
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void WriteLine(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.WriteLine(str.Text);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Работает как и <see cref="WriteLine(Str)"/>, но добавляет дополнительный перенос строки
        /// </summary>
        /// <param name="str"></param>
        public static void WriteLineWithLineBreak(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.WriteLine(str.Text + "\n");
            Console.ForegroundColor = ConsoleColor.Gray;
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

        /// <summary>
        /// Пишет в консоль все Str-s с переносом строки с помощью здешнего метода <see cref="WriteLine(Str)"/>
        /// </summary>
        /// <param name="strs"></param>
        public static void WriteLineStrs(Str[] strs)
        {
            foreach (Str str in strs)
            {
                WriteLine(str);
            }
        }
    }
}
