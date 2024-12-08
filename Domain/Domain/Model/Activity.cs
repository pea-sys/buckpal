namespace Application.Domain.Model
{
    public record ActivityId(long Value);

    public record Activity(
        ActivityId? Id,
        Account.AccountId OwnerAccountId,
        Account.AccountId SourceAccountId,
        Account.AccountId TargetAccountId,
        DateTime Timestamp,
        Money Money
    )
    {


        public Activity(
            Account.AccountId OwnerAccountId,
            Account.AccountId SourceAccountId,
            Account.AccountId TargetAccountId,
            DateTime Timestamp,
            Money Money
        ) : this(
            null,
            OwnerAccountId,
            SourceAccountId,
            TargetAccountId,
            Timestamp,
            Money
        )
        { }
    }
}
