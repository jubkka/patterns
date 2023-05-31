using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using System.Xml.Linq;

namespace prototype
{
    internal class Program
    {
        abstract class Creep
        {
            public abstract string Name { get; set; }
            public abstract int HP { get; set; }
            public abstract int Armor { get; set; }
            public abstract int MS { get; set; }
            public abstract int Damage { get; set; }
            public abstract Creep Clone();
            public abstract void Attack();
            public void GetInfo() 
            {
                Console.WriteLine($"{Name} \n ХП:{HP} \n Броня:{Armor} \n скорость:{MS} \n Урон:{Damage} \n");
            }
            public void RunToTheTower() 
            {
                Console.WriteLine($"{Name} бежит к башне");
            }
        }

        class Flagbearer_Creep : Creep
        {
            private string name = "Крип-знаменосец";
            private int hp = 550;
            private int armor = 2;
            private int ms = 325;
            private int damage = 21;

            public override string Name { get => name; set => Name = name; }
            public override int HP { get => hp; set => HP = hp; }
            public override int Armor { get => armor; set => Armor = armor; }
            public override int MS { get => ms; set => MS = ms; }
            public override int Damage { get => damage; set => Damage = damage; }

            public override Creep Clone()
            {
                return new Flagbearer_Creep();
            }

            public override void Attack()
            {
                Console.WriteLine($"{Name} атакует вблизи");
            }
        }

        class Ranged_Creep : Creep
        {
            private string name = "Крип-маг";
            private int hp = 300;
            private int armor = 0;
            private int ms = 325;
            private int damage = 24;
            public override string Name { get => name; set => Name = name; }
            public override int HP { get => hp; set => HP = hp; }
            public override int Armor { get => armor; set => Armor = armor; }
            public override int MS { get => ms; set => MS = ms; }
            public override int Damage { get => damage; set => Damage = damage; }

            public override Creep Clone()
            {
                return new Ranged_Creep();
            }

            public override void Attack()
            {
                Console.WriteLine($"{Name} атакует из далека своей палкой");
            }
        }


        static void Main(string[] args)
        {
            Creep creep = new Flagbearer_Creep();
            creep.GetInfo();

            Creep newCreep = creep.Clone();
            newCreep.GetInfo();

            Console.WriteLine("//-----------------------------------//");

            Creep creepMage = new Ranged_Creep();
            creepMage.GetInfo();

            Creep newCreepMage = creepMage.Clone();
            newCreepMage.GetInfo();

            Console.ReadLine();
        }
    }
}
