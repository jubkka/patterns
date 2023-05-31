using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace memento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CharacterHistory characters = new CharacterHistory();

            Character character = new Character(5, "Elf", "Равандил");

            characters.History.Push(character.Save());

            character.Death();
            character.RestoreState(characters.History.Pop());

            character.InfoHero();
            characters.History.Push(character.Save());

            character.LvlUP();
            character.InfoHero();

            character.RestoreState(characters.History.Pop());
            character.InfoHero();

            Console.Read();
        }
    }

    class Character // Originator
    {
        private int hp { get; set; }
        private int mp { get; set; }
        private int ms { get; set; }
        private int lvl { get; set; }
        private string race { get; set; }
        private string nameCharacter { get; set; }

        public Character(int lvl, string race, string nameCharacter)
        {
            this.lvl = lvl;
            hp = 10 + (2 * lvl);
            mp = hp;
            ms = 100 + lvl;
            this.race = race;
            this.nameCharacter = nameCharacter;
        }

        public HeroMemento Save()
        {
            return new HeroMemento(hp, mp, ms, lvl, race, nameCharacter);
        }

        public void RestoreState(HeroMemento memento)
        {
            Console.WriteLine("Загрузка последнего сохранения...");
            hp = memento.HP;
            mp = memento.MP;
            ms = memento.MS;
            lvl = memento.LVL;
            race = memento.Race;
            nameCharacter = memento.NameCharacter;
        }
        public void LvlUP()
        {
            Console.WriteLine("Уровень вашего персонажа повышен...");
            lvl = lvl + 1;
            hp = 10 + (2 * lvl);
            mp = hp;
            ms = 100 + lvl;
        }
        public void Death()
        {
            hp = 0;
            Console.WriteLine("Персонаж мертв, загрузите последнее сохранение...");
        }
        public void InfoHero()
        {
            Console.WriteLine($"Хитпоинты: {hp}");
            Console.WriteLine($"Манапоинты: {mp}");
            Console.WriteLine($"Спид: {ms}");
            Console.WriteLine($"ЛВЛ: {lvl}");
            Console.WriteLine($"Раса: {race}");
            Console.WriteLine($"Имя персонажа: {nameCharacter}");
        }
    }
    class HeroMemento //Memento
    {
        public int HP { get; private set; }
        public int MP { get; private set; }
        public int MS { get; private set; }
        public int LVL { get; private set; }
        public string Race { get; private set; }
        public string NameCharacter { get; private set; }

        public HeroMemento(int hp, int mp, int ms, int lvl, string race, string nameCharacter)
        {
            HP = hp;
            MP = mp;
            MS = ms;
            LVL = lvl;
            Race = race;
            NameCharacter = nameCharacter;
        }
    }

    class CharacterHistory //CareTaker
    {
        public Stack<HeroMemento> History { get; private set; }
        public CharacterHistory() => History = new Stack<HeroMemento>();
    }
}
