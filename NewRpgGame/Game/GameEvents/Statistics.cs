using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.GameEvents
{
    class Statistics : GameEvent
    {
        public void Run()
        {
            ConsoleWriter.WriteLineStrs(
                new Str[]
                {
                    new Str($"{IO.TextResources.GetStringByResourceName("max health")}: {ImportantObjectsKeeper.Player.MaxHealth}", ConsoleColor.DarkGreen),
                    new Str($"{IO.TextResources.GetStringByResourceName("current health")}: {ImportantObjectsKeeper.Player.CurrentHealth}", ConsoleColor.Green),
                    new Str($"{IO.TextResources.GetStringByResourceName("defense")}: {ImportantObjectsKeeper.Player.Armor.Defense} ({ImportantObjectsKeeper.Player.Armor.Name})", ConsoleColor.Gray),
                    new Str($"{IO.TextResources.GetStringByResourceName("damage")}: {ImportantObjectsKeeper.Player.Weapon.Damage} ({ImportantObjectsKeeper.Player.Weapon.Name})", ConsoleColor.Red),
                    new Str($"{IO.TextResources.GetStringByResourceName("necklet")}: {ImportantObjectsKeeper.Player.Necklet.Name}", ConsoleColor.DarkMagenta),
                    new Str($"{IO.TextResources.GetStringByResourceName("punishment")}: {ImportantObjectsKeeper.Player.PunishmentPercent}%", ConsoleColor.DarkCyan),
                    new Str($"{IO.TextResources.GetStringByResourceName("money")}: {ImportantObjectsKeeper.Player.Money}", ConsoleColor.Yellow),
                    new Str($"{IO.TextResources.GetStringByResourceName("healing potion count")}: {ImportantObjectsKeeper.Player.HealingPotionCount}", ConsoleColor.Magenta),
                }
                );
            InputProcessing.WaitKey();
            new GameMenu().Run();
        }
    }
}
