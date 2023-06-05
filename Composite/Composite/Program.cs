using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Composite
{

    class Program
    {
        static void Main(string[] args)
        {
            Component armyMars = new Army("Марса");

            Component vzvodMarsa1 = new Vzvod("Красной дюны");
            Component vzvodMarsa2 = new Vzvod("Гора Олимп");

            Component soldat1 = new Soldiers("Пупа");
            Component soldat2 = new Soldiers("Лупа");

            Component soldat3 = new Soldiers("XXX");
            Component soldat4 = new Soldiers("ZZZ");

            armyMars.Add(vzvodMarsa1);
            armyMars.Add(vzvodMarsa2);

            vzvodMarsa1.Add(soldat1);
            vzvodMarsa1.Add(soldat2);

            vzvodMarsa2.Add(soldat3);
            vzvodMarsa2.Add(soldat4);

            armyMars.Print();

            Console.Read();
        }
    }

    abstract class Component
    {
        protected string name;
        
        public string Name { get { return name; } }

        public Component(string name)
        {
            this.name = name;
        }

        public virtual void Add(Component component) { }

        public virtual void Remove(Component component) { }

        public virtual void Print() { }

        public virtual void Attack() { }
    }
    class Army : Component
    {
        private List<Component> components = new List<Component>();
        internal int provision;

        public Army(string name) : base(name) { }

        public override void Add(Component component) => components.Add(component);

        public override void Remove(Component component) => component.Remove(component);

        public override void Print()
        {
            Console.WriteLine("Армия " + name);
            Console.Write("Взводы: ");

            for (int i = 0; i < components.Count; i++) components[i].Print();
        }

        public void HoldFront() => Console.WriteLine($"Армия {name} удерживает фронт");

        public override void Attack()
        {
            for (int i = 0; i < components.Count; i++) components[i].Attack();
            Console.WriteLine($"Атакуем всей армией {name}");
        }
    }

    class Vzvod : Component
    {
        private List<Component> components = new List<Component>();

        public Vzvod(string name) : base(name) { }

        public override void Add(Component component) => components.Add(component);

        public override void Remove(Component component) => component.Remove(component);

        public override void Print()
        {
            Console.Write("\nВзвод " + name);
            Console.Write("\nСолдаты:");
            for (int i = 0; i < components.Count; i++) Console.Write($"{components[i].Name} ");
        }

        public void Escort() => Console.WriteLine("Сопровождение конвоя...");
        public override void Attack()
        {

            Console.WriteLine($"Атакуем взводом {name}...");
            for(int i = 0; i < components.Count; i++) components[i].Attack();
        }
    }

    class Soldiers : Component
    {
        protected int morale;

        public Soldiers(string name) : base(name) { }

        public void PaintTheGrass() 
        { 
            Console.WriteLine("Трава покрашена, комбат доволен, солдат устал");
            morale -= 5;
        }

        public void March() 
        {
            Random random= new Random();

            int result = random.Next(0, 1);

            if (result == 1) Console.WriteLine($"Солдат {name} cпоткнулся и упал");
            else Console.WriteLine($"Солдат {name} гордо марширует");
        }

        public override void Attack() 
        {
            Console.WriteLine($"Атакакует солдат {name}");
        }
    }

}

