using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventureQuestRPG
{
    public class BattleSystem
    {
        public static void Attack(dynamic attacker, dynamic target)
        {
            int damage = Math.Max(0, attacker.AttackPower - target.Defense);
            target.Health = Math.Max(0, target.Health - damage);

            Console.WriteLine($"================={attacker.Name} turn Start=================");
            Console.WriteLine($"{attacker.Name} attacks {target.Name} for {damage} damage!");
            Console.WriteLine($"{target.Name}'s health is now {target.Health}.");
            Console.WriteLine($"================={attacker.Name} turn Finish==================");
            Console.WriteLine($"***************************************************");


        }

        public static void StartBattle(Player player, Monster enemy)
        {
            while (player.Health > 0 && enemy.Health > 0)
            {

                //Console.WriteLine("Player's turn!");
                Attack(player, enemy);

                if (enemy.Health <= 0)
                {
                    Console.WriteLine("Victory! The monster has been defeated.");
                    return;
                }

                //Console.WriteLine("Enemy's turn!");
                Attack(enemy, player);

                if (player.Health <= 0)
                {
                    Console.WriteLine("Defeat! The player has been slain.");
                    return;
                }
            }
        }
    }
}
