using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public abstract class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }

        protected Item(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }

    public class Weapon : Item
    {
        public int AttackPower { get; set; }

        public Weapon(string name, string description, int attackPower)
            : base(name, description)
        {
            AttackPower = attackPower;
        }
    }

    public class Armor : Item
    {
        public int Defense { get; set; }

        public Armor(string name, string description, int defense)
            : base(name, description)
        {
            Defense = defense;
        }
    }

    public class Potion : Item
    {
        public int HealthRestore { get; set; }

        public Potion(string name, string description, int healthRestore)
            : base(name, description)
        {
            HealthRestore = healthRestore;
        }
    }
}

