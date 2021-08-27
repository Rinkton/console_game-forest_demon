using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.Menus
{
    class GameMenu : Menu
    {
        public void Run()
        {
            Components.Choice[] choices =
                new Components.Choice[]
                {
                    /*
                     * what do you want to do in this village for now;Чем желаете сейчас заняться в этой деревне?
                        walk in forest;Погулять по лесу
                        go to Stepan's shop;Зайти в лавку Степана
                        check Ivan's statistics;Посмотреть статистику Ивана
                        go to Pankrat the healer;Сходить к лекарю Панкрату
                        save game;Сохранить игру
                     */
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("walk in forest")), new GameEvents.Fight()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("go to stepan shop")), new GameEvents.Shop()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("check ivan statistics")), new GameEvents.Statistics()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("go to pankrat the healer")), new GameEvents.Healer()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("save game")), new GameEvents.SaveGame()),
                    new Components.Choice(new Str(IO.TextResources.GetStringByResourceName("exit game")), new GameEvents.ExitGame()),
                };
            int startNumber = 1;

            base.Visualize(
                choices,
                IO.TextResources.GetStringByResourceName("what do you want to do in this village for now"),
                startNumber: startNumber
                );
            InputHandler.HandleChoice(choices, startNumber);
        }
    }
}
