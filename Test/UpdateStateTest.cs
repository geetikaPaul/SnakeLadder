using NUnit.Framework;
using Snake_Ladder;

namespace Test
{
    public class UpdateStateTest
    {

        [Test]
        public void OddRowsGameOver()
        {
            Player player = new Player(4, 4);
            Game game = new Two_dimensional();
            game.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }



        [Test]
        public void EvenRowsGameOver()
        {
            Player player = new Player(0, 9);
            Game game = new Two_dimensional(10, 10);
            game.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, game.status);
        }
    }
}
