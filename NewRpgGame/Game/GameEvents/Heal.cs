using System;
using Game.IO;

namespace Game.GameEvents
{
    class Heal : GameMenu
    {
        public override void Run()
        {
            if(ImportantObjectsKeeper.Player.CurrentHealth < ImportantObjectsKeeper.Player.MaxHealth)
            {
                if(ImportantObjectsKeeper.Healer.HealCost <= ImportantObjectsKeeper.Player.Money)
                {
                    ImportantObjectsKeeper.Player.Money -= ImportantObjectsKeeper.Healer.HealCost;
                    ImportantObjectsKeeper.Player.CurrentHealth = ImportantObjectsKeeper.Player.MaxHealth;
                    ConsoleWriter.WriteLineWithLineBreak(new Str(TextResources.GetStringByResourceName("pankrat about healing"), ConsoleColor.Red));
                    ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("your health is fully restored"), ConsoleColor.Green));
                }
                else
                {
                    ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("pankrat too low money to heal").Replace("*", ImportantObjectsKeeper.Healer.HealCost.ToString()), ConsoleColor.Red));
                }
            }
            else
            {
                ConsoleWriter.WriteLine(new Str(TextResources.GetStringByResourceName("pankrat player already healthy"), ConsoleColor.Red));
            }

            InputHandler.WaitKey();
            new Healer().Run();
        }
    }
}
