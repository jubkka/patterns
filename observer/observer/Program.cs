using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using static observer.Program;

namespace observer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Group group = new Group();

            User user1 = new User("Кирилл Кириллович", group);

            User user2 = new User("Данил Данилович", group);

            User user3 = new User("Максим Максимович", group);

            Console.Read();
        }
    }

    interface IObserver
    {
        void Update(object ob);
    }

    interface IObservable
    {
        void RegisterObserver(IObserver o);
        void RemoveObserver(IObserver o);
        void NotifyObservers(IObserver o);
    }

    class Group : IObservable
    {
        List<IObserver> observers;
        public Group() => observers = new List<IObserver>();
        public void RegisterObserver(IObserver o) => observers.Add(o);
        public void RemoveObserver(IObserver o) => observers.Remove(o);

        public void NotifyObservers(IObserver ob)
        {
            foreach (IObserver o in observers)
            {
                o.Update(ob);
            }
        }
    }

    class User : IObserver
    {
        public string Name { get; set; }
        IObservable group;
        public User(string name, IObservable obs)
        {
            Name = name;
            group = obs;
            group.RegisterObserver(this);
            group.NotifyObservers(this);
        }
        public void Update(object ob)
        {
            User user = (User)ob;

            Console.WriteLine("К нам присоединился " + $"{user.Name}");
        }

        public void LeaveTheGroup()
        {
            group.RemoveObserver(this);
            group = null;
        }
    }
}
