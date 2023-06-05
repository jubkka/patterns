using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proxy
{
    internal class Program
    {

        abstract class Person 
        {
            public string name;

            public Person(string name) => this.name = name;
        }

        class Seller : Person
        {
            public Seller(string name) : base(name) { }
        }
        
        class Buyer : Person
        {
            internal int money;

            public Buyer(string name, int money) : base(name) => this.money = money;
        }


        interface IPay
        {
            void Pay(Seller seller, Buyer buyer, int amount);
        }

        class Cash : IPay // наличные
        {
            public void Pay(Seller seller, Buyer buyer, int amount)
            {
                if (buyer.money >= amount) 
                {
                    buyer.money -= amount;

                    Console.WriteLine($"{seller.name} берет деньги {buyer.name} в кол-ве {amount}");
                }
               else Console.WriteLine($"У {buyer.name} недостаточно деньжат, чтобы заплатить {seller.name}");
            }
        }
        class Card : IPay
        {
            Cash cash;
            public double amountMoney = 1000;
            public void Pay(Seller seller, Buyer buyer, int amount)
            {
                if (cash == null)
                    cash = new Cash();

                cash.Pay(seller, buyer, amount);
            }

            public void Withdraw(int amount) // снять деньги с банкомата
            {
                double commission = 0.01;

                amountMoney -= amount * commission;

                Console.WriteLine("Тртртртр...");
                Console.WriteLine("Вы сняли деньги с банкомата");
            }
        }
    }
}
