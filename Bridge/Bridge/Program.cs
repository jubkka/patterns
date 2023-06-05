using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bridge
{
    internal class Program
    {
        abstract class Color 
        {
            internal string color;
        }

        class Red : Color 
        {
            public Red() => color = "Красный";
        }

        class Blue : Color
        {
            public Blue() => color = "Синий";
        }

        abstract class Figure 
        {
            protected string name;
            protected int countAngle = 0;
            internal Color color;

            public Figure(Color color) => this.color = color;
            public Figure() { }

            public void Draw()
            {
                if (color == null) { Console.WriteLine($"{name} появилась, но у него отсутствует цвет"); return; }

                Console.WriteLine($"{color.color} {name} нарисован");
            }

            public void FillColor(Color color)
            {
                this.color = color;
                Console.WriteLine($"Красим {name} в {color.color}");
            }
        }

        class Square: Figure 
        {
            public Square(Color color) : base(color) 
            {
                name = "Квадрат";
                countAngle = 4;
            }
            public Square() => name = "Квадратный";
        }

        class Circle : Figure
        {
            public Circle(Color color) : base(color) => name = "Круг";
            public Circle() => name = "Круг";
        }

        static void Main(string[] args)
        {
            Figure square = new Square(new Red());
            Figure circle = new Circle();

            square.Draw();
            circle.Draw();

            circle.FillColor(new Blue());
            circle.Draw();

            Console.ReadLine();
        }
    }
}
