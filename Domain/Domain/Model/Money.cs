using System.Numerics;

namespace Application.Domain.Model
{
    public record Money(BigInteger Amount)
    {
        public static Money ZERO = Money.Of(0);

        public Boolean IsPositiveOrZero() => this.Amount.CompareTo(BigInteger.Zero) >= 0;

        public Boolean IsNegative() => this.Amount.CompareTo(BigInteger.Zero) < 0;

        public Boolean IsPositive() => this.Amount.CompareTo(BigInteger.Zero) > 0;

        public Boolean IsGreaterThanOrEqualTo(Money money) => this.Amount.CompareTo(money.Amount) >= 0;

        public Boolean IsGreaterThan(Money money) => this.Amount.CompareTo(money.Amount) >= 1;

        public static Money Of(long value) => new(new BigInteger(value));

        public Money Add(Money money) => new(BigInteger.Add(this.Amount, money.Amount));

        public Money Subtract(Money money) => new(BigInteger.Subtract(this.Amount, money.Amount));

        public Money Negate() => new(BigInteger.Negate(this.Amount));

    }
}
