using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class Player : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }
        public Inventory Inventory { get; set; }

        public Player(string name)
        {
            Name = name;
            Health = 150;
            AttackPower = 20;
            Defense = 10;
            Inventory = new Inventory();
        }

        public void UseItem(string itemName)
        {
            var item = Inventory.GetItem(itemName);
            if (item == null)
            {
                Console.WriteLine("Item not found in inventory.");
                return;
            }

            if (item is Potion potion)
            {
                Health += potion.HealthRestore;
                Console.WriteLine($"You used a {potion.Name} and restored {potion.HealthRestore} health.");
                Inventory.RemoveItem(potion);
            }
            else if (item is Weapon weapon)
            {
                AttackPower += weapon.AttackPower;
                Console.WriteLine($"You equipped a {weapon.Name} and gained {weapon.AttackPower} attack power.");
                Inventory.RemoveItem(weapon);
            }
            else if (item is Armor armor)
            {
                Defense += armor.Defense;
                Console.WriteLine($"You equipped an {armor.Name} and gained {armor.Defense} defense.");
                Inventory.RemoveItem(armor);
            }
        }
    }

    public abstract class Monster : IBattleStates
    {
        public string Name { get; set; }
        public int Health { get; set; }
        public int AttackPower { get; set; }
        public int Defense { get; set; }

        protected Monster(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
        }
    }

    public class Dragon : Monster
    {
        public Dragon(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }

    public class Goblin : Monster
    {
        public Goblin(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }

    public class Zombi : Monster
    {
        public Zombi(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }

    public class BossMonster : Monster
    {
        public BossMonster(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }
}
