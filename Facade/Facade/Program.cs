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

        abstract class Instrument
        {
            public string name;
            public int durabillity;
        }

        class Knife : Instrument //нож
        {
            public int cutLevel;

            public Knife(string name, int durabillity,int cutLevel)
            {
                this.name = name;
                this.durabillity = durabillity;
                this.cutLevel = cutLevel;
            }

            public void Cut(Corpse corpse)
            {
                if (corpse.needCutLevel > cutLevel) { Console.WriteLine($"{name} не хватает качества для разделки"); return; }
                if (durabillity <= 0) { Console.WriteLine($"{name} сломан, все, приехали"); return; }

                Console.WriteLine($"{corpse} разделан");
                durabillity -= 5;
            }
        }
        class Screwdriver : Instrument //отвертка 
        {
            public int unscrewLevel;
            public Screwdriver(string name, int durabillity, int unscrewLevel)
            {
                this.name = name;
                this.durabillity = durabillity;
                this.unscrewLevel = unscrewLevel;
            }

            public void Unscrew(Radio radio)
            {
                if (radio.needUnscrewLevel > unscrewLevel) { Console.WriteLine($"{name} не хватает качества для разборки"); return; }
                if (durabillity <= 0) { Console.WriteLine($"{name} сломан, все, приехали"); return; }

                Console.WriteLine($"{radio.name} разобран");
                durabillity -= 5;
            }
        }
        class Opener : Instrument //открывашка
        {
            public int openLevel;

            public Opener(string name, int durabillity, int openLevel)
            {
                this.name = name;
                this.durabillity = durabillity;
                this.openLevel = openLevel;
            }

            public void Open(Can can)
            {
                if (can.needOpenLevel > openLevel) { Console.WriteLine($"{name} не хватает качества для открытия банки"); return; }
                if (durabillity <= 0) { Console.WriteLine($"{name} сломан, все, приехали"); return; }

                Console.WriteLine($"{can.name} открыта");
                durabillity -= 5;
            }
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

            public void Cut(Corpse corpse) => knife.Cut(corpse);
            public void Unscrew(Radio radio) => screwdriver.Unscrew(radio);
            public void Open(Can can) => opener.Open(can);
        }

        class Corpse //труп для разделки
        {
            public string name;
            public int needCutLevel;

            public Corpse(string name, int needCutLevel)
            {
                this.name = name;
                this.needCutLevel = needCutLevel;
            }
        }

        class Can // банка для открывашки
        {
            public string name;
            public int needOpenLevel;

            public Can(string name,int needOpenLevel) 
            { 
                this.name = name; 
                this.needOpenLevel = needOpenLevel; 
            }
        }

        class Radio // радио, чтобы разобрать
        {
            public string name;
            public int needUnscrewLevel;

            public Radio(string name, int needUnscrewLevel)
            {
                this.name = name;
                this.needUnscrewLevel = needUnscrewLevel;
            }
        }

        static void Main(string[] args)
        {
            Multitool multitool = new Multitool(new Knife("Кухонный нож", 100, 3), new Screwdriver("Отвертка", 100, 3), new Opener("Открывашка", 100, 2));

            Can can = new Can("Бобы", 2);
            Corpse corpse = new Corpse("Кабанчик", 5);
            Radio radio = new Radio("Обыкновенное радио", 3);

            multitool.Cut(corpse);
            multitool.Unscrew(radio);
            multitool.Open(can);

            Console.Read();
        }
    }
}
