using NUnit.Framework;
using Snake_Ladder;
using Entities.Games;
using Entities.Player;

namespace Tests
{
    public class TwoDimensionalTests
    {
        private IGame game;
        private Machine sys;

        [SetUp]
        public void Setup()
        {
            game = new Game();
            sys = new Two_dimensional(game);
        }

        [Test]
        public void MoveTwoStepsRight()
        {
            Player player = new Player(2,0);
            sys.MoveThePawn(2, player);

            Assert.AreEqual(4, player.position.X);
            Assert.AreEqual(0, player.position.Y);
        }

        [Test]
        public void MoveTwoStepsLeft()
        {
            Player player = new Player(4,1);
            sys.MoveThePawn(2, player);

            Assert.AreEqual(2, player.position.X);
            Assert.AreEqual(1, player.position.Y);
        }

        [Test]
        public void MoveUpFromRightExtreme()
        {
            Player player = new Player(2, 0);
            sys.MoveThePawn(4, player);

            Assert.AreEqual(3, player.position.X);
            Assert.AreEqual(1, player.position.Y);
        }

        [Test]
        public void MoveUpFromLeftExtreme()
        {
            Player player = new Player(3, 1);
            sys.MoveThePawn(5, player);

            Assert.AreEqual(1, player.position.X);
            Assert.AreEqual(2, player.position.Y);
        }

        [Test]
        public void DontMove()
        {
            Player player = new Player(3, 4);
            sys.MoveThePawn(2, player);

            Assert.AreEqual(3, player.position.X);
            Assert.AreEqual(4, player.position.Y);
        }

        [Test]
        public void OddRowsGameOver()
        {
            Player player = new Player(3, 4);
            sys.Actions(1, player);

            Assert.AreEqual(4, player.position.X);
            Assert.AreEqual(4, player.position.Y);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }
        
        [Test]
        public void TestStatusUpdateOddRows()
        {
            Player player = new Player(4, 4);
            sys.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }
    }
}