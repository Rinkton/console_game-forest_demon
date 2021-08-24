using System.Collections.Generic;
using Xunit;

namespace Tests.Menus
{
    public class Menu
    {
        [Theory]
        [MemberData(nameof(getMenuMember0))]
        [MemberData(nameof(getMenuMember1))]
        [MemberData(nameof(getMenuMember2))]
        [MemberData(nameof(getMenuMember3))]
        [MemberData(nameof(getMenuMember4))]
        [MemberData(nameof(getMenuMember5))]
        [MemberData(nameof(getMenuMember6))]
        public void GetMenu
        (string expected, Game.Menus.Components.Choice[] given1,
        string given2 = null, Game.Menus.Components.Delimeter[] given3 = null,
        Game.Menus.Components.Arrangement given4 = Game.Menus.Components.Arrangement.InList)
        {
            var actual = new Game.Menus.Menu().GetMenu(given1, given2, given3, given4);
            Assert.Equal(actual, expected);
        }

        public static IEnumerable<object[]> getMenuMember0()
        {
            yield return new object[]
            {
                new object[]
                {
                    "1) first",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("first"), new Game.GameEvents.GameEvent()),
                    }
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember1()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "1) a\n" +
                    "2) b\n" +
                    "3) c",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description"
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember2()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "1) a\n" +
                    "\n" +
                    "section\n" +
                    "2) b\n" +
                    "3) c",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Delimeter[]
                    {
                        new Game.Menus.Components.Delimeter(new Game.Str("section"), 2)
                    }
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember3()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "1) a\n" +
                    "2) b\n" +
                    "3) c\n" +
                    "section",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Delimeter[]
                    {
                        new Game.Menus.Components.Delimeter(new Game.Str("section"), 2)
                    }
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember4()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "section\n" +
                    "1) a\n" +
                    "2) b\n" +
                    "3) c\n",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Delimeter[]
                    {
                        new Game.Menus.Components.Delimeter(new Game.Str("section"), 1)
                    }
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember5()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "section\n" +
                    "1) a" + "    " + "2) b" + "    " + "3) c" + "    ",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Delimeter[]
                    {
                        new Game.Menus.Components.Delimeter(new Game.Str("section"), 1)
                    },
                    Game.Menus.Components.Arrangement.InLine
                }
            };
        }
        public static IEnumerable<object[]> getMenuMember6()
        {
            yield return new object[]
            {
                new object[]
                {
                    "description\n\n" +
                    "1) a" + "    " +
                    "\n\n" + "section" + "\n" +
                    "2) b" + "    " + "3) c" + "    ",
                    new Game.Menus.Components.Choice[]
                    {
                        new Game.Menus.Components.Choice(new Game.Str("a"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("b"), new Game.GameEvents.GameEvent()),
                        new Game.Menus.Components.Choice(new Game.Str("c"), new Game.GameEvents.GameEvent()),
                    },
                    "description",
                    new Game.Menus.Components.Delimeter[]
                    {
                        new Game.Menus.Components.Delimeter(new Game.Str("section"), 2)
                    },
                    Game.Menus.Components.Arrangement.InLine
                }
            };
        }

        private void checkAndOutputTestResult(string actual, string expected)
        {
            if(actual == expected)
            {
                System.Diagnostics.Debug.WriteLine("GetMenu passed");
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("GetMenu failed");
            }
        }
    }
}
