using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace singleton
{
    internal class Program
    {
        class QuestItem
        {
            internal static QuestItem instance;

            internal string name;
            internal string description;
            internal int idQuestItem;

            internal QuestItem(string name, string description, int idQuestItem) 
            {
                this.name = name;
                this.description = description;
                this.idQuestItem = idQuestItem;
            }

            public static QuestItem getInstance(string name, string description, int idQuestItem)
            {
                if (instance == null)
                    instance = new QuestItem(name, description, idQuestItem);
                return instance;
            }
        }

        static void Main(string[] args)
        {
            QuestItem ring = QuestItem.getInstance("Excalibur", "Cool sword", 0);

            Console.WriteLine(ring.name);
            Console.WriteLine(ring.description);
            Console.WriteLine(ring.idQuestItem);
            Console.ReadLine();
        }
    }
}
