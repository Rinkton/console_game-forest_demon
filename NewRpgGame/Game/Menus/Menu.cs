using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    public class Menu
    {
        public string GetMenu(Components.Choice[] choices, string description=null,
        Components.Section[] delimeters=null, 
        Components.Arrangement arrangement=Components.Arrangement.InList, int number=1)
        {
            StringBuilder menuText = new StringBuilder();

            if(description != null)
            {
                menuText.Append(description + "\n" + "\n");
            }

            return "1) first";
        }
    }
}
