using Application.Domain.Model;


namespace Application.Port.In
{
    public sealed class SendMoneyCommand
    {
        public SendMoneyCommand(
            Account.AccountId sourceAccountId,
            Account.AccountId targetAccountId,
            Money money) 
        {
            SourceAccountId = sourceAccountId;
            TargetAccountId = targetAccountId;
            Money = money;
            validate(this);

        }

        public Account.AccountId SourceAccountId { get; }
        public Account.AccountId TargetAccountId { get; }
        public Money Money { get; }

        private void validate(SendMoneyCommand sendMoney)
        {
            if (SourceAccountId is null)
            {
                throw new InvalidDataException("sourceAccountId has a not null constraint");
            }
            if (TargetAccountId is null)
            {
                throw new InvalidDataException("targetAccountId has a not null constraint");
            }
            if (sendMoney.Money.Amount < 0)
            {
                throw new InvalidDataException("amount of send money must be a positive number");
            }
        }
    }
}
