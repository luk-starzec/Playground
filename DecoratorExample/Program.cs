using System;
using System.Collections.Generic;

namespace DecoratorExample
{
    class Program
    {
        static void Main(string[] args)
        {
            var std = new Account("s-01");

            var gold = new GoldDecorator(new Account("g-01"));

            var plat = new PlatiniumDecorator(new Account("p-01"));

            var goldTemp = new GoldDecorator(new Account("gp-01"));
            var goldplat = new PlatiniumDecorator(goldTemp);

            var aa = new List<IAccount>()
            {
                std, gold, plat, goldplat,
            };

            foreach (var a in aa)
            {
                Console.WriteLine("--------------------------");
                DoStuff(a);
                Console.WriteLine("--------------------------");
            }
        }

        static void DoStuff(IAccount account)
        {
            Console.WriteLine(account.Number);
            account.Deposit(500);
            account.Withdraw(100);
            account.Deposit(1100);
        }

    }
}
