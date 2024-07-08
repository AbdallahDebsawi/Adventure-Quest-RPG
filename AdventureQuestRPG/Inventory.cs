using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Inventory
    {
        private List<Item> items;

        public Inventory()
        {
            items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            items.Add(item);
            Console.WriteLine($"You have obtained a {item.Name}!");
        }

        public void DisplayInventory()
        {
            Console.WriteLine("Inventory:");
            if (items.Count == 0)
            {
                Console.WriteLine("Your inventory is empty.");
            }
            else
            {
                foreach (var item in items)
                {
                    Console.WriteLine($"- {item.Name}: {item.Description}");
                }
            }
        }

        public Item GetItem(string itemName)
        {
            return items.Find(item => item.Name.Equals(itemName, StringComparison.OrdinalIgnoreCase));
        }

        public void RemoveItem(Item item)
        {
            items.Remove(item);
        }
    }
}
