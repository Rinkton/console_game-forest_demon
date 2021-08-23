using Xunit;
using Game;

namespace Tests
{
    public class Text
    {
        [Theory]
        [InlineData("test", "Тест")]
        public void Test(string given1, string expected)
        {
            var actual = Game.Text.GetStringByResourceName(given1);
            Assert.Equal(actual, expected);
        }
    }
}
