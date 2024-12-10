using Application.Domain.Model;

namespace Application.Port.In
{
    internal interface IGetAccountBalanceUseCase
    {
        Money getAccountBalance(GetAccountBalanceQuery query);

        record GetAccountBalanceQuery(Account.AccountId accountId)
        {
        }
    }
}
