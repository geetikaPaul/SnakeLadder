using NUnit.Framework;
using Snake_Ladder;
using Entities.Boards;
using Entities.Player;
using System.Collections.Generic;
using Entities.Dice;

namespace Test
{
    public class TwoDimensionalTests
    {
        private Game sys;

        [SetUp]
        public void Setup()
        {
            sys = new Two_dimensional(new Board(), new List<Player>() { new Player(), new Player() }, new SingleRandomizedDice());
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
        public void OddRowsboardOver()
        {
            Player player = new Player(4, 4);
            sys.UpdateStatus(player);
            
            Assert.AreEqual(GameStatus.OVER, sys.status);
        }
        
        [Test]
        public void TestStatusUpdateOddRows()
        {
            Player player = new Player(4, 4);
            sys.UpdateStatus(player);
            Assert.AreEqual(PlayerStatus.WON, player.status);
            Assert.AreEqual(GameStatus.OVER, sys.status);
        }

        [Test]
        public void TestPlayerCountValidationWhenPlayerCountLess()
        {
            sys = new Two_dimensional(new Board(), new List<Player>(), new SingleRandomizedDice());
            Assert.AreEqual(null, sys.board);
        }

        [Test]
        public void TestPlayerCountValidationWhenPlayerCountMore()
        {
            sys = new Two_dimensional(new Board(), 
                new List<Player>() { new Player(), new Player(), new Player(), new Player(), new Player() },
                new SingleRandomizedDice());
            Assert.AreEqual(null, sys.board);
        }

        [Test]
        public void TestPlayerCountValidationWhenPlayerCountCorrect()
        {
            sys = new Two_dimensional(new Board(),
                new List<Player>() { new Player(), new Player() },
                new SingleRandomizedDice());
            Assert.AreNotEqual(null, sys.board);
        }

        [Test]
        public void TestPlayerTurn()
        {
            sys = new Two_dimensional(new Board(), new List<Player>() { new Player(), new Player() }, new SingleRandomizedDice());
            Assert.AreEqual(sys.players[0], sys.GetPlayerWhoseTurn());
            Assert.AreEqual(sys.players[1], sys.GetPlayerWhoseTurn());
            Assert.AreEqual(sys.players[0], sys.GetPlayerWhoseTurn());
        }
    }
}