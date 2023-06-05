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
            public abstract void VisitClerking(Clearking clearking);
            public abstract void VisitDevelopmentRoom(DevelopmentRoom developmentRoom);
            public abstract void VisitRestroom(Restroom restroom);

            public void GetMoney() => Console.WriteLine($"{name} получает {salary}");
        }

        class Programmer : Person
        {
            public Programmer(string name, int salary) { this.name = name; this.salary = salary; }
            public override void VisitClerking(Clearking clearking) => GetMoney();
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Coding();
            public override void VisitRestroom(Restroom restroom) => Chill();

            public void Coding() => Console.WriteLine($"{name} программирует...");
            public void Chill()
            {
                energy += 5;
                Console.WriteLine($"{name} отдыхает...");
            }
        }
        class Electrician : Person
        {
            public Electrician(string name) { this.name = name; }
            public override void VisitClerking(Clearking clearking) => GetMoney();
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Repair();
            public override void VisitRestroom(Restroom restroom) => Rest();

            public void Repair() => Console.WriteLine($"{name} чинит...");
            public void Rest()
            {
                energy += 2;
                Console.WriteLine($"{name} отдыхает...");
            }
        }
        class Cleaner : Person
        {
            public Cleaner(string name) { this.name = name; }
            public override void VisitClerking(Clearking clearking) => Clean();
            public override void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Clean();
            public override void VisitRestroom(Restroom restroom) => Clean();

            public void Clean() => Console.WriteLine($"{name} убирается...");
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
