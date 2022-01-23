using System;

namespace DecoratorExample
{
    /// <summary>
    /// Bonus 10$ with every deposit
    /// </summary>
    public class PlatiniumDecorator : IAccount
    {
        private readonly string bonusDescription = "Platinium, 10$ with every deposit";

        private readonly IAccount account;

        public PlatiniumDecorator(IAccount account)
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
