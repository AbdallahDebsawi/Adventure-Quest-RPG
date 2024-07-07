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

        public Player(string name, int health, int attackPower, int defense)
        {
            Name = name;
            Health = health;
            AttackPower = attackPower;
            Defense = defense;
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
    public class BossMonster : Monster
    {
        public BossMonster(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }
    public class Goblin : Monster
    {
        public Goblin(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }

    public class Zombie : Monster
    {
        public Zombie(string name, int health, int attackPower, int defense)
            : base(name, health, attackPower, defense) { }
    }
}
