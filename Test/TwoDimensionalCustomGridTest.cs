using NUnit.Framework;
using Snake_Ladder;
using Entities.Games;
using Entities.Player;

namespace Test
{
    class TwoDimensionalCustomGridTest
    {
        private IGame game;
        private Machine sys;

        [SetUp]
        public void Setup()
        {
            game = new Game(10,10);
            sys = new Two_dimensional(game);
        }


        [Test]
        public void EvenRowsGameOver()
        {
            Player player = new Player(1, 9);
            sys.Actions(1, player);

            Assert.AreEqual(0, player.position.X);
            Assert.AreEqual(9, player.position.Y);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }


        [Test]
        public void TestStatusUpdateEvenRows()
        {
            Player player = new Player(0, 9);
            sys.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }

        [Test]
        public void TestLadderClimbing()
        {
            Player player = new Player(5, 0);
            sys.MoveAlongTheStructure(player);
            Assert.AreEqual(4, player.position.X);
            Assert.AreEqual(4, player.position.Y);
        }

        [Test]
        public void TestSnakeReceding()
        {
            Player player = new Player(7, 1);
            sys.MoveAlongTheStructure(player);
            Assert.AreEqual(2, player.position.X);
            Assert.AreEqual(7, player.position.Y);
        }

        [Test]
        public void TestNostructureToMoveAlong()
        {
            Player player = new Player(3, 3);
            sys.MoveAlongTheStructure(player);
            Assert.AreEqual(3, player.position.X);
            Assert.AreEqual(3, player.position.Y);
        }
    }
}
