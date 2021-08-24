using System.Collections.Generic;
using Xunit;

namespace Tests.Menus
{
    public class Menu
    {
        [Fact]
        public void getMenuMember0()
        {
            string expected = "1) first";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("first"), new Game.GameEvents.GameEvent()),
                    });
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getMenuMember1()
        {
            string expected = "description\n\n" +
                    "1) a\n" +
                    "2) b\n" +
                    "3) c";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description");
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getMenuMember2()
        {
            string expected = "description\n\n" +
                    "1) a\n" +
                    "\n" +
                    "section\n" +
                    "2) b\n" +
                    "3) c";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent())
                    },
                "description",
                new Game.Menus.Components.Section[]
                {
                    new Game.Menus.Components.Section(new Game.Str("section"), 2)
                });
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getMenuMember3()
        {
            string expected = "description\n\n" +
                    "section\n" +
                    "1) a\n" +
                    "2) b\n" +
                    "3) c";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Section[]
                    {
                        new Game.Menus.Components.Section(new Game.Str("section"), 1)
                    });
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getMenuMember4()
        {
            string expected = "description\n\n" +
                    "section\n" +
                    "1) a" + "    " + "2) b" + "    " + "3) c";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Section[]
                    {
                        new Game.Menus.Components.Section(new Game.Str("section"), 1)
                    },
                    Game.Menus.Components.Arrangement.InLine);
            Assert.Equal(expected, actual);
        }
        [Fact]
        public void getMenuMember5()
        {
            string expected = "description\n\n" +
                    "1) a" + "    " +
                    "\n\n" + "section" + "\n" +
                    "2) b" + "    " + "3) c";
            string actual = new Game.Menus.Menu().GetMenu(
                new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Section[]
                    {
                        new Game.Menus.Components.Section(new Game.Str("section"), 2)
                    },
                    Game.Menus.Components.Arrangement.InLine);
            Assert.Equal(expected, actual);
        }
    }
}
