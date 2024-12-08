using Application.Domain.Model;
using static Application.Domain.Model.Account;

namespace Application.Test.Domain.Model
{
    internal class AccountTestData
    {

        public static AccountBuilder DefaultAccount()
        {
            return new AccountBuilder()
                .WithAccountId(new AccountId(42))
                .WithBaselineBalance(Money.Of(999))
                .WithActivityWindow(new ActivityWindow(
                    ActivityTestData.DefaultActivity().Build(), ActivityTestData.DefaultActivity().Build()));
        }

        public class AccountBuilder
        {
            private AccountId? accountId = null;
            private Money? baselineBalance = null;
            private ActivityWindow? activityWindow = null;

            public AccountBuilder WithAccountId(AccountId accountId)
            {
                this.accountId = accountId;
                return this;
            }

            public AccountBuilder WithBaselineBalance(Money baselineBalance)
            {
                this.baselineBalance = baselineBalance;
                return this;
            }

            public AccountBuilder WithActivityWindow(ActivityWindow activityWindow)
            {
                this.activityWindow = activityWindow;
                return this;
            }

            public Account Build()
            {
                return Account.WithId(accountId!, baselineBalance!, activityWindow!);
            }
        }
    }

    internal class ActivityTestData
    {
        public static ActivityBuilder DefaultActivity()
        {
            return new ActivityBuilder()
                .WithOwnerAccount(new AccountId(42))
                .WithSourceAccount(new AccountId(42))
                .WithTargetAccount(new AccountId(41))
                .WithTimestamp(DateTime.Now)
                .WithMoney(Money.Of(999));
        }

        public class ActivityBuilder
        {
            private ActivityId? id = null;
            private AccountId? ownerAccountId = null;
            private AccountId? sourceAccountId = null;
            private AccountId? targetAccountId = null;
            private DateTime? timestamp = null;
            private Money? money = null;

            public ActivityBuilder WithId(ActivityId? id)
            {
                this.id = id;
                return this;
            }

            public ActivityBuilder WithOwnerAccount(AccountId accountId)
            {
                ownerAccountId = accountId;
                return this;
            }

            public ActivityBuilder WithSourceAccount(AccountId accountId)
            {
                sourceAccountId = accountId;
                return this;
            }

            public ActivityBuilder WithTargetAccount(AccountId accountId)
            {
                targetAccountId = accountId;
                return this;
            }

            public ActivityBuilder WithTimestamp(DateTime timestamp)
            {
                this.timestamp = timestamp;
                return this;
            }

            public ActivityBuilder WithMoney(Money money)
            {
                this.money = money;
                return this;
            }

            public Activity Build()
            {
                return new Activity(id, ownerAccountId!, sourceAccountId!,
                    targetAccountId!, (DateTime)timestamp!, money!);
            }
        }
    }
}
