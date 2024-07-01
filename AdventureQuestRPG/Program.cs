using System.Numerics;
using System.Threading;

namespace AdventureQuestRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 100, 20, 10);
            Monster monster = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.StartBattle(player, monster);

            Console.WriteLine("Adventure complete!");
        }
    }
}
