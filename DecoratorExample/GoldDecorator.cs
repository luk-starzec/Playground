using System;

namespace DecoratorExample
{
    /// <summary>
    /// Bonus 10% for deposits over 1000$
    /// </summary>
    public class GoldDecorator : IAccount
    {
        private readonly string bonusDescription = "Gold, 10% for deposits over 1000$";

        private readonly IAccount account;

        public GoldDecorator(IAccount account)
        {
            this.account = account;
        }

        public decimal Amount { get => account.Amount; set => account.Amount = value; }
        public string Number { get => account.Number; }

        public void Deposit(decimal amount)
        {
            account.Deposit(amount);

            var bonus = GetBonus(amount);
            if (bonus == 0)
                return;

            Amount += bonus;
            Console.WriteLine($"Added bonus {bonus} ({bonusDescription})");
        }

        public void Withdraw(decimal amount)
        {
            account.Withdraw(amount);
        }

        private decimal GetBonus(decimal amount)
        {
            var bonus = 0m;
            if (amount > 1000)
                bonus = amount * 0.1m;
            return bonus;
        }

    }
}
