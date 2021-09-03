using System;
using Game.IO;

namespace Game.GameEvents
{
    class Statistics : GameEvent
    {
        public void Run()
        {
            ConsoleWriter.WriteLineStrs(
                new Str[]
                {
                    new Str($"{TextResources.GetStringByResourceName("max health")}: {ImportantObjectsKeeper.Player.MaxHealth}", ConsoleColor.DarkGreen),
                    new Str($"{TextResources.GetStringByResourceName("current health")}: {ImportantObjectsKeeper.Player.CurrentHealth}", ConsoleColor.Green),
                    new Str($"{TextResources.GetStringByResourceName("defense")}: {ImportantObjectsKeeper.Player.Armor.Defense} ({ImportantObjectsKeeper.Player.Armor.Name})", ConsoleColor.Gray),
                    new Str($"{TextResources.GetStringByResourceName("damage")}: {ImportantObjectsKeeper.Player.Weapon.Damage} ({ImportantObjectsKeeper.Player.Weapon.Name})", ConsoleColor.Red),
                    new Str($"{TextResources.GetStringByResourceName("necklet")}: {ImportantObjectsKeeper.Player.Necklet.Name}", ConsoleColor.DarkMagenta),
                    new Str($"{TextResources.GetStringByResourceName("punishment")}: {ImportantObjectsKeeper.Player.PunishmentPercent}%", ConsoleColor.DarkCyan),
                    new Str($"{TextResources.GetStringByResourceName("money")}: {ImportantObjectsKeeper.Player.Money}", ConsoleColor.Yellow),
                    new Str($"{TextResources.GetStringByResourceName("healing potion count")}: {ImportantObjectsKeeper.Player.HealingPotionCount}", ConsoleColor.Magenta),
                }
                );
            InputHandler.WaitKey();
            new GameMenu().Run();
        }
    }
}
