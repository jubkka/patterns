using System;
using System.Text;

namespace builder
{
    abstract class Armor 
    {
        internal abstract string Name { get; set; }
        internal abstract string Description { get; set; }
        internal abstract int Price { get; set; }
        internal abstract int Quality { get; set; } 
        internal abstract string SlotArmor { get; set; }
    }

    abstract class Breastplate : Armor
    {
        private string slotArmor = "Body";
        internal override string SlotArmor
        { 
            set => SlotArmor = slotArmor;
            get => slotArmor;
        }
    }
    abstract class Greaves : Armor
    {
        private string slotArmor = "Hands";
        internal override string SlotArmor
        {
            set => SlotArmor = slotArmor;
            get => slotArmor;
        }
    }
    abstract class Helmet : Armor
    {
        private string slotArmor = "Head";
        internal override string SlotArmor
        {
            set => SlotArmor = slotArmor;
            get => slotArmor;
        }
    }

    abstract class Boots : Armor
    {
        private string slotArmor = "Legs";
        internal override string SlotArmor
        {
            set => SlotArmor = slotArmor;
            get => slotArmor;
        }
    }

    class RustMetalBreastPlate : Breastplate
    {
        private string name = "Ржавый железный нагрудник";
        private string description = "Железный нагрудник, только ржавый";
        private int price = 25;
        private int quality = 0;

        internal override string Name 
        { 
            set => Name = name;
            get => name;
        }
        internal override string Description 
        {
            set => Description = description;
            get => description;
        }
        internal override int Price 
        {
            set => Price = price;
            get => price;
        }
        internal override int Quality 
        { 
            set => Quality = quality; 
            get => quality; 
        }
    }

    class RustMetalGreaves : Greaves
    {
        private string name = "Ржавые железные рукавицы";
        private string description = "Железные рукавицы, только ржавые";
        private int price = 15;
        private int quality = 0;

        internal override string Name
        {
            set => Name = name;
            get => name;
        }
        internal override string Description
        {
            set => Description = description;
            get => description;
        }
        internal override int Price
        {
            set => Price = price;
            get => price;
        }
        internal override int Quality
        {
            set => Quality = quality;
            get => quality;
        }
    }
    class RustMetalHelmet : Helmet
    {
        private string name = "Ржавый железный шлем";
        private string description = "Железный шлем, только ржавый";
        private int price = 20;
        private int quality = 0;

        internal override string Name
        {
            set => Name = name;
            get => name;
        }
        internal override string Description
        {
            set => Description = description;
            get => description;
        }
        internal override int Price
        {
            set => Price = price;
            get => price;
        }
        internal override int Quality
        {
            set => Quality = quality;
            get => quality;
        }
    }

    class RustMetalBoots : Boots
    {
        private string name = "Ржавые железные ботинки";
        private string description = "Железные ботинки, только ржавые";
        private int price = 15;
        private int quality = 0;

        internal override string Name
        {
            set => Name = name;
            get => name;
        }
        internal override string Description
        {
            set => Description = description;
            get => description;
        }
        internal override int Price
        {
            set => Price = price;
            get => price;
        }
        internal override int Quality
        {
            set => Quality = quality;
            get => quality;
        }
    }

    abstract class Weapon
    {
        public abstract string Name { get; set; }
        public abstract int Damage { get; set; }
        public abstract int Price { get; set; }
        public abstract bool TwoHand { get; set;}
    }

    abstract class ShortSword : Weapon 
    {
        private bool twohand = false;
        public override bool TwoHand
        { 
            get => twohand;
            set => TwoHand = twohand; 
        }
    }
    class RustShortSword : ShortSword
    {
        private string name = "Ржавый короткий меч";
        private int damage = 5;
        private int price = 10;
        public override string Name 
        { 
            get => name; 
            set => Name = name; 
        }
        public override int Damage 
        { 
            get => damage; 
            set => Damage = damage; 
        }
        public override int Price 
        { 
            get => price; 
            set => Price = price; 
        }
    }

    class SkeletBomj
    {
        public string nameMob { get; set; }
        public int lvlMob { get; set; }
        public int hpMob { get; set; }
        public int dropGold { get; set; }
        public RustMetalBreastPlate breastplate { get; set; }
        public RustMetalGreaves greaves { get; set; }
        public RustMetalHelmet helmet { get; set; }
        public RustMetalBoots boots { get; set; }
        public RustShortSword weapon { get; set; }

        private void Death()
        {
            Console.WriteLine("Скелет развалился");
            Console.WriteLine("Золото со скелета" + $"{dropGold}");
        }
        private void LostItem() 
        {
            Random random = new Random();

            int item  = random.Next(1, 5);

            switch (item) 
            {
                case 1:
                    breastplate = null;
                    break;
                case 2:
                    greaves= null;
                    break;
                case 3:
                    helmet = null;
                    break;
                case 4: 
                    boots = null;
                    break; 
                case 5: 
                    weapon = null;
                    break;
            }
        }

        private void Talk() => Console.WriteLine($"{nameMob}" + "...");
        
    }

    class Program
    {
        static void Main(string[] args)
        {
            Spawner spawner = new Spawner();

            SkeletBuilder builder = new Skelet_Warrior();

            SkeletBomj skeletWarrior = spawner.Spawn(builder);
            InfoSkelet(skeletWarrior);

            Console.ReadLine();
        }

        private static void InfoSkelet(SkeletBomj skelet)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("Название монстра: " + skelet.nameMob + "\n");
            sb.Append("Уровень: " + skelet.lvlMob + "\n");
            sb.Append("ХП: " + skelet.hpMob + "\n");

            if (skelet.breastplate != null)
                sb.Append("Нагрудник: " + skelet.breastplate.Name + "\n");
            if (skelet.greaves != null)
                sb.Append("Наручи: " + skelet.greaves.Name + "\n");
            if (skelet.helmet != null)
                sb.Append("Шлем: " + skelet.helmet.Name + "\n");
            if (skelet.boots != null)
                sb.Append("Ботинки: " + skelet.boots.Name + "\n");
            if (skelet.weapon != null)
                sb.Append("Оружие: " + skelet.weapon.Name + "\n");
            
            Console.WriteLine(sb.ToString());
        }
    }

    abstract class SkeletBuilder
    {
        public SkeletBomj Skelet { get; private set; }
        public void SpawnSkelet()
        {
            Skelet = new SkeletBomj();
        }
        public abstract void GiveName();
        public abstract void HowMuchHP();
        public abstract void HowMuchDropGold();
        public abstract void Level();
        public abstract void EquipHelmet();
        public abstract void EquipBreastPlate();
        public abstract void EquipGreaves();
        public abstract void EquipBoots();
        public abstract void EquipWeapon();
    }
    class Spawner
    {
        public SkeletBomj Spawn(SkeletBuilder skeletBuilder)
        {
            skeletBuilder.SpawnSkelet();
            skeletBuilder.GiveName();
            skeletBuilder.Level();
            skeletBuilder.HowMuchHP();
            skeletBuilder.HowMuchDropGold();
            skeletBuilder.EquipHelmet();
            skeletBuilder.EquipBreastPlate();
            skeletBuilder.EquipGreaves();
            skeletBuilder.EquipBoots();
            skeletBuilder.EquipWeapon();

            return skeletBuilder.Skelet;
        }
    }

    class Skelet_Warrior : SkeletBuilder
    {
        public override void GiveName()
        {
            Skelet.nameMob = "Скелет воин";
        }
        public override void Level()
        {
            Skelet.lvlMob = 8;
        }
        public override void HowMuchHP()
        {
            Skelet.hpMob = 10;
        }
        public override void HowMuchDropGold()
        {
            Skelet.dropGold = 100;
        }
        public override void EquipHelmet()
        {
            Skelet.helmet = new RustMetalHelmet();
        }

        public override void EquipBreastPlate()
        {
            Skelet.breastplate = new RustMetalBreastPlate();
        }

        public override void EquipGreaves()
        {
            Skelet.greaves = new RustMetalGreaves();
        }
        public override void EquipBoots()
        {
            Skelet.boots = new RustMetalBoots();
        }
        public override void EquipWeapon()
        {
            Skelet.weapon = new RustShortSword();
        }

    }
}
