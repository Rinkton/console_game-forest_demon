using Xunit;

namespace Tests
{
    public class FractionToPercentConverter
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData(3, 33)]
        [InlineData(6, 66)]
        [InlineData(9, 100)]
        public void GetPercent(int given1, int expected)
        {
            int actual = Game.FractionToPercentConverter.GetPercent(given1);
            Assert.Equal(expected, actual);
        }
    }
}
