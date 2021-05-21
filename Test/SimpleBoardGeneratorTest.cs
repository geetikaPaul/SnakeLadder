using NUnit.Framework;
using Snake_Ladder;
using Entities.Games;
using Entities.Player;
using BoardGenerator;
using System.Collections.Generic;
using Entities.Elements;

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
    }
}
