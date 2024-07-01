using AdventureQuestRPG;

namespace AdventureQuestRPGTests
{
    public class UnitTest1
    {
        [Fact]
        public void PlayerAttackReducesMonsterHealth()
        {
            Player player = new Player("Hero", 100, 20, 10);
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.Attack(player, enemy);

            Assert.True(enemy.Health < 50);
        }

        [Fact]
        public void MonsterAttackReducesPlayerHealth()
        {
            Player player = new Player("Hero", 100, 20, 10);
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.Attack(enemy, player);

            Assert.True(player.Health < 100);
        }

        [Fact]
        public void WinnerHealthIsGreaterThanZero()
        {
            Player player = new Player("Hero", 100, 20, 10);
            Monster enemy = new Dragon("Dragon", 50, 15, 5);

            BattleSystem.StartBattle(player, enemy);

            Assert.True(player.Health > 0 || enemy.Health > 0);
        }
    }
}