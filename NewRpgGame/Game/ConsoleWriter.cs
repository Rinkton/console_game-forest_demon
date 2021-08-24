using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    static class ConsoleWriter
    {
        public static void Write(string text, ConsoleColor color = ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.Write(text);
        }
        public static void Write(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.Write(str.Text);
        }

        public static void WriteLine(string text, ConsoleColor color=ConsoleColor.Gray)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(text);
        }
        public static void WriteLine(Str str)
        {
            Console.ForegroundColor = str.Color;
            Console.WriteLine(str.Text);
        }
    }
}
