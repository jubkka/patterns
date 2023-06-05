using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Traveler driver = new Traveler();

            Auto auto = new Auto();
            Boat boat = new Boat();
            Plane plane = new Plane();

            driver.Travel(auto);

            IAuto adapter = new PlaneAdapter(plane);

            driver.Travel(adapter);

            adapter = new BoatAdapter(boat);

            driver.Travel(adapter);

            Console.Read();
        }
    }

    class Traveler
    {
        public void Travel(IAuto transport)
        {
            transport.Drive();
        }
    }

    interface IAuto
    {
        void Drive();
    }

    class Auto : IAuto
    {
        public void Drive() => Console.WriteLine("Путешествиник едет на машине");
    }

    interface IPlane
    {
        void Fly();
    }

    class Plane : IPlane
    {
        public void Fly() => Console.WriteLine("Путешествиник летит на самолете");
    }

    interface IBoat
    {
        void Trip();
    }

    class Boat : IBoat
    {
        public void Trip() => Console.WriteLine("Путешествиник плывет на лодке");
    }

    class PlaneAdapter : IAuto
    {
        Plane panel;
        public PlaneAdapter(Plane panel)
        {
            this.panel = panel;
        }

        public void Drive()
        {
            panel.Fly();
        }
    }

    class BoatAdapter : IAuto
    {
        Boat boat;
        public BoatAdapter(Boat boat)
        {
            this.boat = boat;
        }

        public void Drive()
        {
            boat.Trip();
        }
    }

}