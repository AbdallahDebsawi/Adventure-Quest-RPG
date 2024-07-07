using System.Numerics;
using System.Threading;

namespace AdventureQuestRPG
{
    public class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player("Hero", 150, 20, 10);
            Adventure adventure = new Adventure(player);

            adventure.Start();

            Console.WriteLine("Adventure complete!");
        }
    }
}
