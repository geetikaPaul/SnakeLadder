using NUnit.Framework;
using Snake_Ladder;

namespace Tests
{
    public class MoveThePawnTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void MoveTwoStepsRight()
        {
            Player player = new Player(2,0);
            Game game = new Two_dimensional();
            game.MoveThePawn(2, player);

            Assert.AreEqual(4, player.position.X);
            Assert.AreEqual(0, player.position.Y);
        }

        [Test]
        public void MoveTwoStepsLeft()
        {
            Player player = new Player(4,1);
            Game game = new Two_dimensional();
            game.MoveThePawn(2, player);

            Assert.AreEqual(2, player.position.X);
            Assert.AreEqual(1, player.position.Y);
        }

        [Test]
        public void MoveUpFromRightExtreme()
        {
            Player player = new Player(2, 0);
            Game game = new Two_dimensional();
            game.MoveThePawn(4, player);

            Assert.AreEqual(3, player.position.X);
            Assert.AreEqual(1, player.position.Y);
        }

        [Test]
        public void MoveUpFromLeftExtreme()
        {
            Player player = new Player(3, 1);
            Game game = new Two_dimensional();
            game.MoveThePawn(5, player);

            Assert.AreEqual(1, player.position.X);
            Assert.AreEqual(2, player.position.Y);
        }

        [Test]
        public void DontMove()
        {
            Player player = new Player(3, 4);
            Game game = new Two_dimensional();
            game.MoveThePawn(2, player);

            Assert.AreEqual(3, player.position.X);
            Assert.AreEqual(4, player.position.Y);
        }

    }
}