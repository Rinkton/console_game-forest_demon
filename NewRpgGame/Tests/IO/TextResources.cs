using Xunit;

namespace Tests.IO
{
    public class TextResources
    {
        [Theory]
        [InlineData("test", "Тест")]
        [InlineData("not existing", null)]
        public void GetStringByResourceName(string given1, string expected)
        {
            string actual = null;
            try
            {
                actual = Game.IO.TextResources.GetStringByResourceName(given1);
            }
            catch
            {
                Assert.True(given1 == "not existing");
            }
            Assert.Equal(expected, actual);
        }

        [Theory]
        [InlineData("test", new string[] { "Тест0", "Тест1", "Тест2" })]
        [InlineData("not existing", null)]
        public void GetStringsByResourceGroupName(string given1, string[] expected)
        {
            string[] actual = null;
            try
            {
                actual = Game.IO.TextResources.GetStringsByResourceGroupName(given1);
            }
            catch
            {
                Assert.True(given1 == "not existing");
            }
            Assert.Equal(expected, actual);
        }
    }
}
