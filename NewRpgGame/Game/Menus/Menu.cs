using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class Menu
    {
        //TODO: GetMenu должен возвращать Str-ы а не стринг, ЦВЕТА, не забывай(и удалить тест придётся...)
        //TODO: Разделить бы всё на engine и game и Game переименовать
        public string GetMenu(Components.Choice[] choices, string description=null,
        Components.Section[] sections=null, 
        Components.Arrangement arrangement=Components.Arrangement.InList, int startNumber=1)
        {
            StringBuilder menuText = new StringBuilder();

            #region description
            if (description != null)
            {
                menuText.Append(description + "\n" + "\n");
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
                                        menuText.Append("\n");
                                        break;
                                    case Components.Arrangement.InLine:
                                        menuText.Append("\n\n");
                                        break;
                                }
                            }
                            menuText.Append(section.Str.Text);
                            menuText.Append("\n");
                        }
                    }
                }
                #endregion

                #region choices
                menuText.Append(i + ") " + choice.Str.Text);
                #endregion

                #region arrangement
                if (choices.Length != i)
                {
                    switch (arrangement)
                    {
                        case Components.Arrangement.InList:
                            menuText.Append("\n");
                            break;
                        case Components.Arrangement.InLine:
                            menuText.Append("    ");
                            break;
                    }
                }
                #endregion
                i++;
            }

            return menuText.ToString();
        }
    }
}
