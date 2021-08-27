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
    static class InputHandler
    {
        public static void WaitKey()
        {
            Console.ReadKey();
            Console.Clear();
        }

        /// <summary>
        /// Принимает пользовательский ввод, валидирует его и если валидация успешна, то 
        /// он запускает <see cref="GameEvents.GameEvent"/> у <see cref="Menus.Components.Choice"/>
        /// </summary>
        /// <param name="choices"></param>
        /// <param name="startNumber"></param>
        public static void HandleChoice(Menus.Components.Choice[] choices, int startNumber)
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
                HandleChoice(choices, startNumber);
            }
        }
    }
}
