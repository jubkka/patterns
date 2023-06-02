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

            public Person(Mediator mediator) => this.mediator = mediator;
        }

        class TaxiDriver : Person
        {
            public TaxiDriver(Mediator mediator) : base(mediator) { }

            public void Send(string message) => mediator.Send(message, this);

            public void Notify(string message) => Console.WriteLine("Клиент отправил вам сообщение: " + $"{message}");
        }

        class Client : Person
        {
            public Client(Mediator mediator) : base(mediator) { }

            public void Send(string message) => mediator.Send(message, this);

            public void Notify(string message) => Console.WriteLine("Водитель отправил вам сообщеение: " + $"{message}");
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
            Client client = new Client(dispatcher);

            dispatcher.Taxist = taxist;
            dispatcher.Client = client;

            taxist.Send("Ало, я на месте, где вы");
            client.Send("Выходим");

            Console.Read();
        }
    }
}
