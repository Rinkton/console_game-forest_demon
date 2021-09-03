using System;
using System.Collections.Generic;
using Game.Menus.Components;

namespace Game.Menus
{
    public class Menu
    {
        protected void Visualize(Choice[] choices, string description=null,
        Section[] sections=null, 
        Arrangement arrangement=Arrangement.InList, Tabulation tabulation=Tabulation.Default, int startNumber=1)
        {
            List<Str> strList = new List<Str>();

            #region description
            if (description != null)
            {
                strList.Add(new Str(description + "\n" + "\n"));
            }
            #endregion

            int i = startNumber;
            foreach(Choice choice in choices)
            {
                #region sections
                if(sections != null)
                {
                    foreach (Section section in sections)
                    {
                        if (section.Number == i)
                        {
                            if(i != startNumber)
                            {
                                switch (arrangement)
                                {
                                    case Arrangement.InList:
                                        strList.Add(new Str("\n"));
                                        break;
                                    case Arrangement.InLine:
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
                switch(tabulation)
                {
                    case Tabulation.FourSpace:
                        strList.Add(new Str("    "));
                        break;
                }
                strList.Add(new Str(i + ") "));
                strList.Add(choice.Str);
                #endregion

                #region arrangement
                if (choices.Length != i)
                {
                    switch (arrangement)
                    {
                        case Arrangement.InLine:
                            strList.Add(new Str("    "));
                            break;
                        case Arrangement.InList:
                            strList.Add(new Str("\n"));
                            break;
                    }
                }
                #endregion

                i++;
            }
            strList.Add(new Str("\n"));

            ConsoleWriter.WriteStrs(strList.ToArray());
        }
    }
}
