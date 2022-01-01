using System;

namespace DecoratorExample
{
    /// <summary>
    /// Bonus 10$ with every deposit
    /// </summary>
    public class PlatiniumDecorator : IAccount
    {
        private readonly IAccount account;

        public PlatiniumDecorator(IAccount account)
        {
            this.account = account;
        }

        public decimal Amount { get => account.Amount; set => account.Amount = value; }
        public string Number { get => account.Number; }

        public void Deposit(decimal amount)
        {
            var bonus = GetBonus(amount);
            Amount += amount + bonus;
            Console.WriteLine($"Depisited {amount }{(bonus > 0 ? $" (with {bonus} bonus)" : "")}. Total {Amount}");
        }

        private decimal GetBonus(decimal amount)
        {
            var bonus = 10m;
            return bonus;
        }

        public void Withdraw(decimal amount)
        {
            account.Withdraw(amount);
        }
    }
}
