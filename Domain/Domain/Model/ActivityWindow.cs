using System.Collections.Immutable;

namespace Application.Domain.Model
{
    public class ActivityWindow(IList<Activity> activities)
    {
        public ActivityWindow(params Activity[] activities) : this(activities.ToList()) { }

        public DateTime GetStartTimestamp() => activities.MinBy(a => a.Timestamp)!.Timestamp;

        public DateTime GetEndTimestamp() => activities.Max(a => a.Timestamp);

        public ImmutableList<Activity> GetActivities() => activities.ToImmutableList();

        public Money CalculateBalance(Account.AccountId accountId)
        {
            var depositBalance = activities
                .Where(a => a.TargetAccountId == accountId)
                .Select(a => a.Money)
                .Aggregate(Money.ZERO, (curr, next) => curr.Add(next));

            var withdrawalBalance =
                (from a in activities
                 where a.SourceAccountId == accountId
                 select a.Money)
                 .Aggregate(Money.ZERO, (curr, next) => curr.Add(next));
            
            return depositBalance.Add(withdrawalBalance.Negate());
        }

        public void AddActivity(Activity activity) => activities.Add(activity);
    }
}
