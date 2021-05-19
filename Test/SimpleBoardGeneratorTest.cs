using NUnit.Framework;
using Snake_Ladder;
using Entities.Game;
using Entities.Player;
using BoardGenerator;
using System.Collections.Generic;
using Entities.Structures;

namespace Test
{
    public class SimpleBoardGeneratorTest : SimpleBoardGenerator
    {
        [Test]
        public void TestSnakeGenerator()
        {
            HashSet<int> points = new HashSet<int>();
            Structure snake = SnakeGenerator(ref points);
            Assert.Greater(snake.Start[1], snake.End[1]);
        }

        [Test]
        public void TestLadderGenerator()
        {
            HashSet<int> points = new HashSet<int>();
            Structure snake = LadderGenerator(ref points);
            Assert.Greater(snake.End[1], snake.Start[1]);
        }

        [Test]
        public void TestStartPointUniqueness()
        {
            HashSet<int> points = new HashSet<int>() { 2, 4, 5, 7 };
            int actual = StartPointGenerator(ref points);
            List<int> expected = new List<int>(){ 0,1,3,6,8};
            Assert.Contains(actual, expected);
        }

        [Test]
        public void TestEndPointUniqueness()
        {
            HashSet<int> points = new HashSet<int>() { 2, 4, 5, 7 };
            int actual = EndPointGenerator(points, 2);
            List<int> expected = new List<int>() { 3, 6, 8, 9 };
            Assert.Contains(actual, expected);
        }

        [Test]
        public void TestEndPointGreaterThanStartPoint()
        {
            HashSet<int> points = new HashSet<int>() { 2, 4, 5, 7 };
            int actual = EndPointGenerator(points, 8);
            List<int> expected = new List<int>() { 8, 9 };
            Assert.Contains(actual, expected);
        }
    }
}
