using System;
using System.Collections.Generic;

namespace Mediator
{
    internal class Program
    {
        abstract class Mediator
        {
            public abstract void Send(string msg, Person colleague);
        }

        abstract class Person
        {
            protected Mediator mediator;

            protected string name;

            protected int money;

            public Person(Mediator mediator) => this.mediator = mediator;

            public void Send(string message) => mediator.Send(message, this);

            public void Notify(string message) => Console.WriteLine($"{name} отправил вам сообщение: {message}");
        }

        class TaxiDriver : Person
        {
            public TaxiDriver(Mediator mediator) : base(mediator) { }

            public void GetMoney(int count) => money += count;
        }

        class Client : Person
        {
            public Client(Mediator mediator, int money) : base(mediator) 
            {
                this.money = money;
            }

            public void PayMoney(int count)
            {
                if (money > count) money -= count;
            }

        }

        class Dispatcher : Mediator
        {
            public TaxiDriver Taxist { get; set; }
            public Client Client { get; set; }
            public override void Send(string msg, Person person)
            {
                if (Taxist == person) Client.Notify(msg);
                else Taxist.Notify(msg);
            }
        }

        static void Main(string[] args)
        {
            Dispatcher dispatcher = new Dispatcher();

            TaxiDriver taxist = new TaxiDriver(dispatcher);
            Client client = new Client(dispatcher, 100);

            dispatcher.Taxist = taxist;
            dispatcher.Client = client;

            taxist.Send("Ало, я на месте, где вы");
            client.Send("Выходим");

            taxist.GetMoney(10);
            client.PayMoney(10);

            Console.Read();
        }
    }
}
