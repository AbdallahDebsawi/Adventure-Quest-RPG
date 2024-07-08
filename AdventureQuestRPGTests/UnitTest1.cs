using AdventureQuestRPG;

namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerAttackReducesMonsterHealth()
        {
            Player player = new Player("Hero");
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.Attack(player, enemy);

            Assert.True(enemy.Health < 50);
        }

        [Fact]
        public void MonsterAttackReducesPlayerHealth()
        {
            Player player = new Player("Hero");
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.Attack(enemy, player);

            Assert.True(player.Health < 100);
        }

        [Fact]
        public void WinnerHealthIsGreaterThanZero()
        {
            Player player = new Player("Hero");
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.StartBattle(player, enemy);

            Assert.True(player.Health > 0 || enemy.Health > 0);
        }
        [Fact]
        public void TestMovingToNewLocationCorrectly()
        {
            var player = new Player("TestPlayer");
            var adventure = new Adventure(player);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("1\n2\n"))
                {
                    Console.SetIn(sr);

                    adventure.Start();

                    var expectedOutput = "Current Location: Town\nChoose an action:\n1. Move to a new location\n2. Encounter a monster\n3. End the game\n4. View and use items from inventory\nAvailable locations:\n1. Town\n2. Forest\n3. Cave\nCurrent Location: Forest\nChoose an action:\n1. Move to a new location\n2. Encounter a monster\n3. End the game\n4. View and use items from inventory\n";
                    var output = sw.ToString();

                    Assert.Contains(expectedOutput, output);
                }
            }
        }

        [Fact]
        public void TestFindingAndEncounteringBossMonster()
        {
            var player = new Player("TestPlayer");
            var adventure = new Adventure(player);

            using (var sw = new StringWriter())
            {
                Console.SetOut(sw);
                using (var sr = new StringReader("2\n"))
                {
                    Console.SetIn(sr);

                    adventure.Start();

                    var expectedOutput = "A wild Boss Dragon appears!";
                    var output = sw.ToString();

                    Assert.Contains(expectedOutput, output);
                }
            }
        }
    }
}