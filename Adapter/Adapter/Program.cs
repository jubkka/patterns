using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    internal class Program
    {

        //аналогия со стандартами розеток. Европейские розетки не подходят в Америке, поэтому надо использовать адаптер
        interface IСhargerEU
        {
            void ChargeEU(); // заряжаем по европейским стандартам
        }

        class ChargerEU : IСhargerEU
        {
            public void ChargeEU()
            {
                Console.WriteLine("Зарядка с европейской вилкой");
            }
        }
        

        interface IChargerUSA
        {
            void ChargeUSA(); // заряжаем по американским стандартам
        }

        class ChargerUSA : IChargerUSA
        {
            public void ChargeUSA()
            {
                Console.WriteLine("Зарядка с американской вилкой");
            }
        }

        class EuToUsaAdapter : IСhargerEU
        {
            ChargerUSA chargerUSA;
            public EuToUsaAdapter(ChargerUSA chargerUSA) => this.chargerUSA = chargerUSA;

            public void ChargeEU()
            {
                chargerUSA.ChargeUSA();
            }
        }

        class Driver
        {
            public void Charge(IСhargerEU charge)
            {
                charge.ChargeEU();
            }
        }


        static void Main(string[] args)
        {
            Driver driver = new Driver();
            ChargerEU chargerEU = new ChargerEU();

            driver.Charge(chargerEU);

            ChargerUSA chargerUSA = new ChargerUSA();
            IСhargerEU charger = new EuToUsaAdapter(chargerUSA);

            driver.Charge(charger);

            Console.Read();
        }
    }
}
