using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class Menu
    {
        protected void Run(Components.Choice[] choices, string description=null,
        Components.Section[] sections=null, 
        Components.Arrangement arrangement=Components.Arrangement.InList, int startNumber=1)
        {
            List<Str> strList = new List<Str>();

            #region description
            if (description != null)
            {
                strList.Add(new Str(description + "\n" + "\n"));
            }
            #endregion

            int i = startNumber;
            foreach(Components.Choice choice in choices)
            {
                #region sections
                if(sections != null)
                {
                    foreach (Components.Section section in sections)
                    {
                        if (section.Number == i)
                        {
                            if(i != startNumber)
                            {
                                switch (arrangement)
                                {
                                    case Components.Arrangement.InList:
                                        strList.Add(new Str("\n"));
                                        break;
                                    case Components.Arrangement.InLine:
                                        strList.Add(new Str("\n\n"));
                                        break;
                                }
                            }
                            strList.Add(section.Str);
                            strList.Add(new Str("\n"));
                        }
                    }
                }
                #endregion

                #region choices
                strList.Add(new Str(i + ") "));
                strList.Add(choice.Str);
                #endregion

                #region arrangement
                if (choices.Length != i)
                {
                    switch (arrangement)
                    {
                        case Components.Arrangement.InList:
                            strList.Add(new Str("\n"));
                            break;
                        case Components.Arrangement.InLine:
                            strList.Add(new Str("    "));
                            break;
                    }
                }
                #endregion

                i++;
            }
            strList.Add(new Str("\n"));

            Console.Clear();
            ConsoleWriter.WriteStrs(strList.ToArray());

            string input = Console.ReadLine();
            bool isNotEmpty = input != "";
            bool isNumber = input.Length == input.Where(c => char.IsDigit(c)).Count();
            bool inRange = false;
            if (isNotEmpty && isNumber)
            {
                int choiceNumber = Convert.ToInt32(input) - startNumber;
                inRange = choiceNumber >= 0 && choiceNumber < choices.Length;
                if(inRange)
                {
                    choices[choiceNumber].GameEvent.Run();
                }
            }
            //Если ввод некорректен, то перезапускаем меню.
            //Условие здесь для того, чтобы если игровое событие сделает return,
            //то всё бы не зацикливалось.
            if(!(isNotEmpty && isNumber && inRange))
            {
                Run(choices, description, sections, arrangement, startNumber);
            }
        }

        /// <summary>
        /// Запускает определённый <see cref="GameEvents.GameEvent"/> в зависимости от ввода пользователя
        /// </summary>
        private void executeChoice(int choiceNumber, Components.Choice[] choices, int startNumber)
        {
            
        }
    }
}
