using System;

namespace DecoratorExample
{
    public class Account : IAccount
    {
        public string Number { get; set; }
        public decimal Amount { get; set; } = 0;


        public Account(string number)
        {
            Number = number;
        }

        public void Deposit(decimal amount)
        {
            var bonus = GetBonus(amount);
            Amount += amount + bonus;
            Console.WriteLine($"Depisited {amount }{(bonus > 0 ? $" (with {bonus} bonus)" : "")}. Total {Amount}");
        }

        public void Withdraw(decimal amount)
        {
            Amount -= amount;
            Console.WriteLine($"Withdrawn {amount}. Remaining {Amount}");
        }

        public decimal GetBonus(decimal amount)
        {
            return 0;
        }
    }
}
