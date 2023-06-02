using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Decorator
{
    internal class Program
    {
        abstract class Person
        {
            public string name;
            public bool protectedCold; //защита от холода
            public bool protectedRain; // защита от дождя

            public Person(string name) => this.name = name;
        }

        class Human : Person
        {
            public Human() : base("Павел")
            {
                protectedCold = false;
                protectedRain = false;
            }
        }

        abstract class HumanDecorator : Person
        {
            protected Person person;
            public HumanDecorator(string n, Person person) : base(n) => this.person = person;
        }

        class HumanWithSweater : HumanDecorator
        {
            public HumanWithSweater(Person p)
                : base(p.name + ", в свитаре", p)
            {
                protectedCold = true;
            }
        }

        class HumanWithRaincoat : HumanDecorator
        {
            public HumanWithRaincoat(Person p)
                : base(p.name + ", и в дождивике", p)
            {
                protectedRain = true;
            }
        }


        static void Main()
        {
            Person human = new Human();
            human = new HumanWithSweater(human);

            Console.WriteLine("Имя: {0}", human.name);
            Console.WriteLine("Защита от холода: {0}", human.protectedCold);
            Console.WriteLine("Защита от дождя: {0}", human.protectedRain);

            Console.Read();
        }
    }
}
