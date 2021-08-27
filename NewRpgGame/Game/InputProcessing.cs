using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game
{
    /// <summary>
    /// Обрабатывает пользовательский ввод и также после корректной обработки очищает консоль
    /// </summary>
    static class InputProcessing
    {
        public static void WaitKey()
        {
            Console.ReadKey();
            Console.Clear();
        }

        //TODO: RunChoice gotta have a better name
        public static void RunChoice(Menus.Components.Choice[] choices, int startNumber)
        {
            string input = Console.ReadLine();
            bool isNotEmpty = input != "";
            bool isNumber = input.Length == input.Where(c => char.IsDigit(c)).Count();
            bool inRange = false;
            if (isNotEmpty && isNumber)
            {
                int choiceNumber = Convert.ToInt32(input) - startNumber;
                inRange = choiceNumber >= 0 && choiceNumber < choices.Length;
                if (inRange)
                {
                    Console.Clear();
                    choices[choiceNumber].GameEvent.Run();
                }
            }
            if(!(isNotEmpty && isNumber && inRange))
            {
                RunChoice(choices, startNumber);
            }
        }
    }
}
