using NUnit.Framework;
using Snake_Ladder;

namespace Test
{
    class GameActionsTest
    {
        [Test]
        public void OddRowsGameOver()
        {
            Player player = new Player(3, 4);
            Game game = new Two_dimensional();
            game.Actions(1, player);

            Assert.AreEqual(4, player.position.X);
            Assert.AreEqual(4, player.position.Y);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }



        [Test]
        public void EvenRowsGameOver()
        {
            Player player = new Player(1, 9);
            Game game = new Two_dimensional(10, 10);
            game.Actions(1, player);

            Assert.AreEqual(0, player.position.X);
            Assert.AreEqual(9, player.position.Y);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }
    }
}
