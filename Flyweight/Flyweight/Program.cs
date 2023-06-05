using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flyweight
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int x = 0;
            int y = 0;

            ParticlesFactory particlesFactory = new ParticlesFactory();

            for (int i = 0; i < 5; i++)
            {
                Particle particle = particlesFactory.GetParticle("Fire");
                if (particle != null)
                    particle.Spawn(x, y, 100);
                x += 1;
                y += 1;
            }

            Console.Read();
        }

        abstract class Particle
        {
            protected string color;
            protected string sprite;
            
            protected int coords_X;
            protected int coords_Y;
            protected int speed;
            protected string name;

            public virtual void Spawn(int coords_X, int coords_Y, int speed)
            {
                this.coords_X = coords_X;
                this.coords_Y = coords_Y;
                this.speed = speed;

                Console.WriteLine($"{name} заспавнены в координатах X:{this.coords_X} Y:{this.coords_Y} со скоростью {this.speed}");
            }
        }

        class Fire : Particle
        {
            public Fire()
            {
                color = "Оранжевый";
                sprite = "*Представим что здесь спрайт огня*";
                name = "Частицы огня";
            }
        }
        class Water : Particle
        {
            public Water()
            {
                color = "Голубой";
                sprite = "*Представим что здесь спрайт воды*";
                name = "Частицы воды";
            }
        }

        class ParticlesFactory
        {
            Dictionary<string, Particle> particls = new Dictionary<string, Particle>();

            public ParticlesFactory()
            {
                particls.Add("Fire", new Fire());
                particls.Add("Water", new Water());
            }

            public Particle GetParticle(string key)
            {
                if (particls.ContainsKey(key))
                    return particls[key];
                else
                    return null;
            }
        }
    }
}
