using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        abstract class Person
        {
            public string name;
            public int money = 0;
            public int cash = 0; // деньги в бухгалтерии
            public int salary;
            public int energy = 100;

            public abstract void Work();
            public abstract void Chill();
            public abstract void GetMoney();
            public abstract void VisitClerking(Clearking clearking);
            public abstract void VisitDevelopmentRoom(DevelopmentRoom developmentRoom);
            public abstract void VisitRestroom(Restroom restroom);
        }

        class Programmer : Person
        {
            public Programmer(string name, int salary) { this.name = name; this.salary = salary; }
            public override void VisitClerking(Clearking clearking) => GetMoney();
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Chill();
            public override void VisitRestroom(Restroom restroom) => Chill();

            public override void Chill() 
            {
                Console.WriteLine("Делаем деньги лежа на диване");
                cash += salary;
                energy++; //копим чакру
            }

            public override void GetMoney()
            {
                Console.WriteLine($"Ваша зарплата {name} в размере {cash}");
                money = cash;
                cash = 0;
            }

            public override void Work() => Chill();
        }
        class Electrician : Person
        {
            public Electrician(string name) { this.name = name; }
            public override void VisitClerking(Clearking clearking) => GetMoney();
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Work();
            public override void VisitRestroom(Restroom restroom) => Chill();

            public override void Chill()
            {
                energy++;
                Console.WriteLine($"{name} присел отдохнуть");
            }

            public override void GetMoney()
            {
                Console.WriteLine($"Ваша зарплата {name} в размере {cash}");
                money = cash / 2;
                cash = 0;
            }

            public override void Work()
            {
                energy--;
                Console.WriteLine($"{name} чиним, чиним");
            }
        }
        class Cleaner : Person
        {
            public Cleaner(string name) { this.name = name; }
            public override void VisitClerking(Clearking clearking) => Console.WriteLine($"Убирается в {clearking.name}");
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Console.WriteLine($"Убирается в {developmentRoom.name}");
            public override void VisitRestroom(Restroom restroom) => Chill();

            public override void Chill()
            {
                energy -= 5;
                Console.WriteLine($"{name} убирает комнату отдыха, смотря как другие отдыхают");
                Work();
            }

            public override void GetMoney()
            {
                Console.WriteLine($"Ваша зарплата {name} в размере {cash}");
                money = cash / 10;
                cash = -100;

                Work();
            }

            public override void Work()
            {
                energy -= 3;
                Console.WriteLine($"{name} моем, моем");
            }

        }


        interface Client 
        {
            void Accept(Person person);
        }

        class Clearking : Client // бухгалтерия
        {
            public string name;
            public Clearking(string name) => this.name = name;

            public void Accept(Person person) => person.VisitClerking(this);
        }
        class DevelopmentRoom : Client // отдел разработки
        {
            public string name;
            public DevelopmentRoom(string name) => this.name = name;

            public void Accept(Person person) => person.VisitDevelopmentRoom(this);
        }
        class Restroom : Client // комната отдыха
        {
            public string name;

            public Restroom(string name) => this.name = name;

            public void Accept(Person person) => person.VisitRestroom(this);
        }
    }
}
