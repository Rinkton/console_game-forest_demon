using Xunit;

namespace Tests.Player.HitTypes
{
    public class HitType
    {
        /// <summary>
        /// Использует для примера класc <see cref="Game.Player.HitTypes.Weak"/>
        /// </summary>
        /// <param name="given1"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData((1 * 100) / 9, 0.25f)]
        [InlineData((4 * 100) / 9, 0.75f)]
        [InlineData((6 * 100) / 9, 1.25f)]
        [InlineData((8 * 100) / 9, 1.25f)]
        public void GetHitResultWeak(int given1, float expected)
        {
            float actual = new Game.Player.HitTypes.Weak().GetHitResult(given1).DamageMultiplier;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Использует для примера класc <see cref="Game.Player.HitTypes.Normal"/>
        /// </summary>
        /// <param name="given1"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData((2 * 100) / 9, 0.5f)]
        [InlineData((3 * 100) / 9, 1)]
        [InlineData((6 * 100) / 9, 1.5f)]
        [InlineData((8 * 100) / 9, 1.5f)]
        public void GetHitResultNormal(int given1, float expected)
        {
            float actual = new Game.Player.HitTypes.Normal().GetHitResult(given1).DamageMultiplier;
            Assert.Equal(expected, actual);
        }

        /// <summary>
        /// Использует для примера класc <see cref="Game.Player.HitTypes.Strong"/>
        /// </summary>
        /// <param name="given1"></param>
        /// <param name="expected"></param>
        [Theory]
        [InlineData(0, 0)]
        [InlineData((1 * 100) / 9, 0)]
        [InlineData((4 * 100) / 9, 0)]
        [InlineData((5 * 100) / 9, 2)]
        [InlineData((8 * 100) / 9, 2)]
        public void GetHitResultStrong(int given1, float expected)
        {
            float actual = new Game.Player.HitTypes.Strong().GetHitResult(given1).DamageMultiplier;
            Assert.Equal(expected, actual);
        }
    }
}
