using Xunit;

namespace Tests.Player.HitTypes
{
    /// <summary>
    /// Использует для примера класc <see cref="Game.Player.HitTypes.Weak"/>
    /// </summary>
    public class HitType
    {
        [Theory]
        [InlineData(0, 0)]
        [InlineData((1 * 100) / 9, 0)]
        [InlineData((4 * 100) / 9, 0.5f)]
        [InlineData((6 * 100) / 9, 1)]
        [InlineData((8 * 100) / 9, 1.5f)]
        public void GetHitResult(int given1, float expected)
        {
            float actual = new Game.Player.HitTypes.Weak().GetHitResult(given1).DamageMultiplier;
            Assert.Equal(expected, actual);
        }
    }
}
