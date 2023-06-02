using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facade
{
    internal class Program
    {
        //Мультитул

        class Knife //нож
        {
            public void Cut() => Console.WriteLine("Режим...");
        }
        class Screwdriver //отвертка 
        {
            public void Unscrew() => Console.WriteLine("Откручиваем болты...");
        }
        class Opener //открывашка
        {
            public void Open() => Console.WriteLine("Открываем банку...");
        }

        class Multitool
        {
            Knife knife;
            Screwdriver screwdriver;
            Opener opener;

            public Multitool(Knife knife, Screwdriver screwdriver, Opener opener)
            {
                this.knife = knife;
                this.screwdriver = screwdriver;
                this.opener = opener;
            }

            public void Cut() => knife.Cut();
            public void Unscrew() => screwdriver.Unscrew();
            public void Open() => opener.Open();
        }


        static void Main(string[] args)
        {
            Multitool multitool = new Multitool(new Knife(), new Screwdriver(), new Opener());

            multitool.Cut();
            multitool.Unscrew();
            multitool.Open();
        }
    }
}
