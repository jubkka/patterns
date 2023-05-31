using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection.Emit;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace state1
{
    internal class Program
    {
        static void Main()
        {
            Enemy enemy = new Enemy(new Aggression());
            enemy.Request();

            enemy.InfoCharacter();
            enemy.GetDamage(40);

            if (enemy.hp <= 60) enemy.Request();

            enemy.InfoCharacter();
            enemy.GetDamage(40);

            if (enemy.hp <= 20) enemy.Request();

            enemy.InfoCharacter();

            Console.ReadKey();
        }
    }

    abstract class State
    {
        public abstract void Handle(Enemy context);

        public abstract void Attack();
        public abstract void Dodge();
        public abstract void Run();
    }

    class Aggression : State
    {
        public override void Handle(Enemy enemy)
        {
            enemy.state = new Defence();
                
            enemy.def = 5;
            enemy.atc = 15;
            enemy.nameState = "Агрессия";
        }
        public override void Attack() => Console.WriteLine("Персонаж атакует");
        public override void Dodge() => Console.WriteLine("Персонаж будет хуже защищаться");
        public override void Run() { }
    }
    class Defence : State
    {
        public override void Handle(Enemy enemy)
        {
            enemy.state = new RunAway();

            enemy.def = 15;
            enemy.atc = 5;
            enemy.nameState = "Защита";
        }

        public override void Attack() => Console.WriteLine("Персонаж будет атаковать с помехой");
        public override void Dodge() => Console.WriteLine("Персонаж будет защищаться в полную силу");
        public override void Run() { }
    }
    class RunAway : State
    {
        public override void Handle(Enemy enemy)
        {
            enemy.state = new Aggression();

            enemy.def = 7;
            enemy.ms = 100;
            enemy.atc = 0;
            enemy.nameState = "Бегство";
        }
        public override void Attack() => Console.WriteLine("Персонаж не может атаковать, он убегает");
        public override void Dodge() => Console.WriteLine("Персонаж не может защищаться, он убегает");
        public override void Run() => Console.WriteLine("Персонаж убегает как может");
    }

    class Enemy
    {
        public State state;

        public int hp = 100;
        public int ms = 50;
        public int def = 10;
        public int atc = 10;
        public string nameState;

        public Enemy(State state) => this.state = state;
        public void Request() => state.Handle(this);

        public void Attack() => state.Attack();
        public void Dodge() => state.Dodge();
        public void RunAway() => state.Run();

        public void GetDamage(int damage) => hp -= damage;

        public void InfoCharacter()
        {
            Console.WriteLine($"Состояние: {nameState}");
            Console.WriteLine($"Хитпоинты: {hp}");
            Console.WriteLine($"Атака: {atc}");
            Console.WriteLine($"Защита: {def}");
            Console.WriteLine($"Скорость: {ms}");
        }
    }
}
