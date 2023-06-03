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
            public bool protectedCold = false; //защита от холода
            public bool protectedRain = false; // защита от дождя

            public int speed = 100;
            public int weight = 0; 
            public int energy = 100;

            public Person(string name) => this.name = name;

            public abstract string WalkInRainDay();
            public abstract string WalkInColdDay();

            public abstract string Run();

            public abstract int Speed(int a);
        }

        class Human : Person
        {
            public Human(string name) : base(name) { }

            public override string WalkInRainDay() { return "Я не могу гулять под дождем, я промокну"; }
            public override string WalkInColdDay() { return "Я не могу гулять, там холодно"; }

            public override string Run() 
            {
                return $"Бежим со скоростью {Speed()}";
            }
            public override int Speed(int a = 1) 
            {
                return speed = (weight + a) * energy;
            } 
        }

        abstract class HumanDecorator : Person
        {
            protected Person person;
            public HumanDecorator(string n, Person person) : base(n) => this.person = person;
        }

        class HumanWithSweater : HumanDecorator
        {
            public HumanWithSweater(Person p) : base(p.name + ", в свитаре", p) { protectedCold = true;  weight -= 20; }

            public override string WalkInColdDay() { return "Я могу гулять в холод"; }

            public override string WalkInRainDay() { return person.WalkInRainDay(); }

            public override string Run() { return $"Я могу бежать со скростью {speed}"; }

            public override int Speed(int a) { return person.Speed(10); }

        }

        class HumanWithRaincoat : HumanDecorator
        {
            public HumanWithRaincoat(Person p) : base(p.name + ", и в дождивике", p) { protectedRain = true; weight -= 20; }

            public override string WalkInRainDay() { return "Я могу гулять под дождем"; }
            public override string WalkInColdDay() { return person.WalkInColdDay(); }

            public override string Run() { return $"Я могу бежать со скростью {speed}"; }

            public override int Speed(int a) { return person.Speed(20); }
        }


        static void Main()
        {
            Person human = new Human("Алеша");

            Console.WriteLine(human.name);
            Console.WriteLine(human.WalkInColdDay());
            Console.WriteLine(human.WalkInColdDay());

            human = new HumanWithSweater(human);
            human = new HumanWithRaincoat(human);

            Console.WriteLine(human.name);
            Console.WriteLine(human.WalkInRainDay());
            Console.WriteLine(human.WalkInColdDay());

            Console.Read();
        }
    }
}
