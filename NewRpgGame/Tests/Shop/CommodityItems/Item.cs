using System;
using System.Collections.Generic;
using Xunit;
using Game.Shop.CommodityItems;
using Newtonsoft.Json;

namespace Tests.Shop.CommodityItems
{
    public class Item : Game.Shop.CommodityItems.Item
    {
        [Theory]
        [MemberData(nameof(TestData), MemberType = typeof(TestDataProvider))]
        public void GetStrNominationUnit(MemberDataSerializer<TestData> testCase)
        {
            _Item = new TestItem(testCase.Object.Name);
            Properties = testCase.Object.Properties;
            Cost = testCase.Object.Cost;
            State = testCase.Object.State;
            Game.Str actual = GetStrNomination();
            var expectedJson = JsonConvert.SerializeObject(testCase.Object.Expected);
            var actualJson = JsonConvert.SerializeObject(actual);
            Assert.Equal(expectedJson, actualJson);
        }
    }

    public class TestData
    {
        public string Name { get; set; }
        public string Properties { get; set; }
        public int Cost { get; set; }
        public State State { get; set; }

        public Game.Str Expected { get; set; }

        public TestData(string name, int cost, State state, Game.Str expected, string properties = null)
        {
            Name = name;
            Properties = properties;
            Cost = cost;
            State = state;

            Expected = expected;
        }
    }

    class TestItem : Game.Items.Item
    {
        public TestItem(string name)
        {
            Name = name;
        }
    }

    class TestDataProvider
    {
        public static IEnumerable<object[]> TestData()
        {
            yield return new object[] { new MemberDataSerializer<TestData>(new TestData("a", 10, State.InStock, new Game.Str("a - 10 монет", ConsoleColor.Gray))) };
            yield return new object[] { new MemberDataSerializer<TestData>(new TestData("b", 15, State.Bought, new Game.Str("b", ConsoleColor.DarkYellow))) };
            yield return new object[] { new MemberDataSerializer<TestData>(new TestData("c", 20, State.Equiped, new Game.Str("c", ConsoleColor.Yellow))) };
            yield return new object[] { new MemberDataSerializer<TestData>(new TestData("aa", 10, State.InStock, new Game.Str("aa (It's aa) - 10 монет", ConsoleColor.Gray), "It's aa")) };
        }
    }
}
