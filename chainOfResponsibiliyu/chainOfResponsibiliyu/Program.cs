using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChainOfResponsibiliyu
{
    internal class Program
    {
        static void Main()
        {
            Handler answerPhone = new AnswerPhone();
            Handler clerk = new Clerk();
            Handler engineer = new Enginner();

            answerPhone.Successor = clerk;
            clerk.Successor = engineer;

            answerPhone.HandleRequest(2);

            Console.ReadLine();
        }
    }

    abstract class Handler
    {
        public Handler Successor { get; set; }
        public abstract void HandleRequest(int condition);
    }

    class AnswerPhone : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 1)
            {
                Random random = new Random();

                int result = random.Next(0,1);

                if (result == 0) TotalIgnor("Мы закрылись");
                if (result == 1) TotalIgnor("Перезвоните позже");
            }
            else Successor?.HandleRequest(condition);
        }

        private void TotalIgnor(string message) => Console.WriteLine(message);
    }

    class Clerk : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 2) Console.WriteLine("Попробуйте выключить и включить");
            else Successor?.HandleRequest(condition);
        }
    }

    class Enginner : Handler
    {
        public override void HandleRequest(int condition)
        {
            if (condition == 3) Console.WriteLine("У вас сгорел роутер, купите у нас новый");
            else Successor?.HandleRequest(condition);
        }


    }
}
