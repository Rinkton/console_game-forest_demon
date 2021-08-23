using Xunit;
using Game;

namespace Tests
{
    public class Class1
    {
        [Fact]
        public void Test()
        {
            Tested tested = new Tested();
            Assert.Equal(5, tested.GetFive());
        }
    }
}
