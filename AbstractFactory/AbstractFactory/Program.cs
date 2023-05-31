using System;

namespace AbstractFactory
{
    //Общий класс для юнитов
    abstract class Unit 
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int Damage { get; set; }
        public int Speed { get; set; }
        public int Cost { get; set; }

        public abstract void Attack();
        public abstract void Move();
    }

    //Виды юнитов
    abstract class Infantryman : Unit
    {
        public abstract void ShieldWall();
    }

    abstract class Archer : Unit
    {
        public abstract void GradStrell();
    }

    abstract class Horseman : Unit
    {
        public abstract void Natisk();
    }

    //Чайные мужики
    class England_Infantryman : Infantryman 
    {
        public England_Infantryman() 
        {
            Name = "Английский крестьянин с копьем";
            Hp = 10;
            Damage = 5;
            Speed = 100;
            Cost = 50; 
        }
        public override void Attack() => Console.WriteLine("Атака в лоб");
        public override void Move() => Console.WriteLine("Войска двигаются пешим строем");
        public override void ShieldWall() => Console.WriteLine("Английские крестьяне сформировали стену щитов");
    }

    class England_Archer : Archer 
    {
        public England_Archer()
        {
            Name = "Английский меткий лучник";
            Hp = 8;
            Damage = 15;
            Speed = 110;
            Cost = 40;
        }
        public override void Attack() => Console.WriteLine("Атака из далека");
        public override void Move() => Console.WriteLine("Войска двигаются пешим строем");
        public override void GradStrell() => Console.WriteLine("Английские лучники выпустили град стрел");
    }
    class England_Horseman : Horseman 
    {
        public England_Horseman()
        {
            Name = "Английская кавалерия";
            Hp = 15;
            Damage = 8;
            Speed = 130;
            Cost = 70;
        }
        public override void Attack() => Console.WriteLine("Атака во фланги");
        public override void Move() => Console.WriteLine("Войска двигаются верхом");
        public override void Natisk() => Console.WriteLine("Английская кавалерия стремительно движется к противнику");
    }

    //Багетные войска
    class French_Infantryman : Infantryman 
    {
        public French_Infantryman()
        {
            Name = "Французский крестьянин с вилами";
            Hp = 10;
            Damage = 5;
            Speed = 100;
            Cost = 50;
        }

        public override void Attack() => Console.WriteLine("Атака в лоб");
        public override void Move() => Console.WriteLine("Войска двигаются пешим строем");
        public override void ShieldWall() => Console.WriteLine("Французские крестьяне подняли щиты");
    }

    class French_Archer : Archer
    {
        public French_Archer()
        {
            Name = "Французский лучник";
            Hp = 5;
            Damage = 7;
            Speed = 95;
            Cost = 55;
        }

        public override void Attack() => Console.WriteLine("Атака из далека");
        public override void Move() => Console.WriteLine("Войска двигаются пешим строем");
        public override void GradStrell() => Console.WriteLine("Французские лучники пытаются понять как стрелять");
    }

    class French_Horseman : Horseman
    {
        public French_Horseman()
        {
            Name = "Французская кавалерия";
            Hp = 17;
            Damage = 13;
            Speed = 140;
            Cost = 55;
        }

        public override void Attack() => Console.WriteLine("Атака во фланги");
        public override void Move() => Console.WriteLine("Войска двигаются верхом");
        public override void Natisk() => Console.WriteLine("Французская тяжелая кавалерия стремительно движется к противнику");
    }

    abstract class ArmyFactory 
    {
        public abstract Infantryman CreateInfantryman();
        public abstract Archer CreateArcher();
        public abstract Horseman CreateHorseman();
    }
    //Английская фабрика
    class England_ArmyFactory : ArmyFactory
    {
        public override Infantryman CreateInfantryman()
        {
            return new England_Infantryman();
        }
        public override Archer CreateArcher() 
        {
            return new England_Archer();
        }

        public override Horseman CreateHorseman()
        {
            return new England_Horseman();
        }
    }

    //Французская фабрика
    class French_ArmyFactory : ArmyFactory 
    {
        public override Infantryman CreateInfantryman()
        {
            return new French_Infantryman();
        }
        public override Archer CreateArcher()
        {
            return new French_Archer();
        }

        public override Horseman CreateHorseman()
        {
            return new French_Horseman();
        }
    }


    internal class Program
    {
        static void Main()
        {
        }
    }
}
