using Application.Domain.Model;
using System.Numerics;

namespace Application.Test.Domain.Model
{
    public class MoneyTest
    {
        [Fact]
        public void Of()
        {
            var money = Money.Of(42);
            Assert.Equal(new BigInteger(42), money.Amount);
        }

        [Fact]
        public void Add()
        {
            var actual = Money.Of(1).Add(Money.Of(2));
            var expected = Money.Of(3);
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Subtract()
        {
            var actual = Money.Of(7).Subtract(Money.Of(3));
            var expected = Money.Of(4);
            Assert.Equal(expected, actual);
        }
    }
}
