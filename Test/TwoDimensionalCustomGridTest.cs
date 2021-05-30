using NUnit.Framework;
using Snake_Ladder;
using Entities.Boards;
using Entities.Player;
using System.Collections.Generic;
using Entities.Dice;

namespace Test
{
    class TwoDimensionalCustomGridTest
    {
        private Game sys;

        [SetUp]
        public void Setup()
        {
            sys = new Two_dimensional(new Board(10, 10), new List<Player>() { new Player(), new Player() }, new SingleRandomizedDice());
        }

        
        [Test]
        public void EvenRowsboardOver()
        {
            Player player = new Player(0, 9);
            sys.UpdateStatus(player);
            
            Assert.AreEqual(GameStatus.OVER, sys.status);
        }


        [Test]
        public void TestStatusUpdateEvenRows()
        {
            Player player = new Player(0, 9);
            sys.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, sys.status);
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
