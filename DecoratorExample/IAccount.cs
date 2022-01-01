namespace DecoratorExample
{
    public interface IAccount
    {
        decimal Amount { get; set; }
        string Number { get; }

        void Deposit(decimal amount);
        void Withdraw(decimal amount);

    }
}
