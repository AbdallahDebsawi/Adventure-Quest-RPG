using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public static void Attack(IBattleStates attacker, IBattleStates target)
        {
            int damage = Math.Max(0, attacker.AttackPower - target.Defense);
            target.Health = Math.Max(0, target.Health - damage);

            Console.WriteLine($"================={attacker.Name} turn Start=================");
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage. {target.Name} has {target.Health} health remaining.");
            Console.WriteLine($"================={attacker.Name} turn Finish==================");
            Console.WriteLine(" ");
        }

        public static void StartBattle(Player player, Monster monster)
        {
            while (player.Health > 0 && monster.Health > 0)
            {
                //Console.WriteLine("Player's turn:");
                Attack(player, monster);

                if (monster.Health <= 0)
                {
                    Console.WriteLine($"You defeated the {monster.Name}!");
                    HandleItemDrop(player);
                    return;
                }

                //Console.WriteLine("Monster's turn:");
                Attack(monster, player);

                if (player.Health <= 0)
                {
                    Console.WriteLine("You have been defeated!");
                    return;
                }
            }
        }

        private static void HandleItemDrop(Player player)
        {
            Random rand = new Random();
            int dropChance = rand.Next(1, 101);

            if (dropChance <= 30) // 30% chance to drop an item
            {
                Item droppedItem = null;
                int itemType = rand.Next(1, 4);

                switch (itemType)
                {
                    case 1:
                        droppedItem = new Weapon("Sword", "A sharp blade.", 10);
                        break;
                    case 2:
                        droppedItem = new Armor("Shield", "A sturdy shield.", 5);
                        break;
                    case 3:
                        droppedItem = new Potion("Health Potion", "Restores health.", 20);
                        break;
                }

                if (droppedItem != null)
                {
                    player.Inventory.AddItem(droppedItem);
                }
            }
        }
    }
}
