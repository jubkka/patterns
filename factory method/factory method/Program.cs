using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace factory_method
{
    internal class Program
    {
        abstract class Unit
        {
            //creation parametrs
            public string name;

            //main parametrs
            public int hp;
            public float speed;
            public bool canSwim;

            //attack parametrs
            public bool canAttack;
            public bool canAirAttack;
            public float attackRange;
            public int groundDamage;
            public int airDamage;
            public float speedAttack;

            //conditions
            public bool stuned;
            public bool move;
            public bool swim;

            //immunities
            public bool immunityStun;

            // coordinates unit'a
            public float x;
            public float y;

            public virtual void Attack(Unit enemyUnit)
            {
                //animation
                enemyUnit.hp -= groundDamage;
                Console.WriteLine($"{name} launched an attaсk {enemyUnit.name}");
            }

            public void Move(float x, float y)
            {
                //animation
                move = true;
                Console.WriteLine($"{name} moved to destination");

                //float[] massivePoints = PathFinder(this.x, this.y, x, y, canSwim, canFly);

                while (this.x != x && this.y != y)
                {
                    this.x += speed;
                    this.y += speed;
                }

                //animation
                move = false;
            }
        }

        class WarBear : Unit
        {
            public WarBear()
            {
                name = "War Bear";
                hp = 150;
                speed = 85f;

                canSwim = true;
                canAttack = true;
                canAirAttack = false;
                attackRange = 1f;
                groundDamage = 100;
                airDamage = 0;
                speedAttack = 1.5f;

                stuned = false;
                move = false;
                swim = false;

                immunityStun = false;
                x = 0; y = 0;
            }
            //Abilities
            public void AmplifiedRoar(Unit enemyUnit) //stuns enemy units
            {
                bool coolDownAbility = false;
                int rangeAbility = 5;
                double distanceBetweenUnits = Math.Sqrt(Math.Pow(enemyUnit.x - x, 2) + Math.Pow(enemyUnit.y - y, 2));

                if (!coolDownAbility)
                {
                    coolDownAbility = true;
                    if (!enemyUnit.immunityStun && rangeAbility >= distanceBetweenUnits)
                    {
                        enemyUnit.stuned = true;
                        Console.WriteLine($"War bear stuned {enemyUnit.name}!");
                    }
                }
            }

        }

        class Bullfrog : Unit
        {
            int busySlots;
            public Bullfrog()
            {
                name = "Bullfrog";
                hp = 300;
                speed = 100f;
                busySlots = 0;

                canSwim = true;
                canAttack = false;
                canAirAttack = true;
                attackRange = 300f;
                groundDamage = 100;
                airDamage = 15;
                speedAttack = 1.5f;

                move = false;
                swim = false;

                immunityStun = true;
                x = 0; y = 0;
            }

            public override void Attack(Unit enemyUnit)
            {
                enemyUnit.hp -= airDamage;
                Console.WriteLine($"{name} launched an attaсk {enemyUnit.name}");
            }

            //ability
            public void ManCannon(int busySlots)
            {
                //animation
                Console.WriteLine($"{name} launch units into the sky!");
                busySlots = 0;
            }
        }

        abstract class Creator
        {
            public string name;
            public string description;
            public int cost;
            public float buildTime;

            public abstract Unit Create();
        }

        class SlotWarBear : Creator
        {
            public override Unit Create() 
            { 
                return new WarBear();
            }
        }

        class SlotBullfrog : Creator
        {
            public override Unit Create()
            { 
                return new Bullfrog();
            }
        }

        static void Main(string[] args)
        {


            Console.ReadLine();
        }
    }
}
