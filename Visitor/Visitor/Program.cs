using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visitor
{
    internal class Program
    {
        interface Person
        {
            void VisitClerking(Clearking clearking);
            void VisitDevelopmentRoom(DevelopmentRoom developmentRoom);
            void VisitRestroom(Restroom restroom);
        }

        class Programmer : Person
        {
            public void VisitClerking(Clearking clearking) => Console.WriteLine("Почини компьютер, ты же программист");
            public void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Console.WriteLine("Сиди и пиши программу");
            public void VisitRestroom(Restroom restroom) => Console.WriteLine("Программист отдыхает");
        }
        class Electrician : Person
        {
            public void VisitClerking(Clearking clearking) => Console.WriteLine("Почини компьютер, ты же электрик");
            public void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Console.WriteLine("Если лампа не горит, то чините, до тех пор пока не заработает");
            public void VisitRestroom(Restroom restroom) => Console.WriteLine("Электрик отдыхает");
        }
        class Cleaner : Person
        {
            public void VisitClerking(Clearking clearking) => Console.WriteLine($"Убирается в {clearking.name}");
            public void VisitDevelopmentRoom(DevelopmentRoom developmentRoom) => Console.WriteLine($"Убирается в {developmentRoom.name}");
            public void VisitRestroom(Restroom restroom) => Console.WriteLine($"Убирается в {restroom.name}");
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


        static void Main(string[] args)
        {
        }
    }
}
