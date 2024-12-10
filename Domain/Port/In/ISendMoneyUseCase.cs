namespace Application.Port.In
{
    internal interface ISendMoneyUseCase
    {
        bool SendMoney(SendMoneyCommand command);
    }
}
