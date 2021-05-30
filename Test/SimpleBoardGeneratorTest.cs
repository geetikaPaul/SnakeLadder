using NUnit.Framework;
using Snake_Ladder;
using Entities.Boards;
using Entities.Player;
using BoardGenerator;
using System.Collections.Generic;
using Entities.Elements;

namespace Test
{
    public class SimpleBoardGeneratorTest : SimpleBoardGenerator
    {
        [Test]
        [Ignore("Obsolete method of creating game")]
        public void TestSnakeGenerator()
        {
            HashSet<int> points = new HashSet<int>();
            Structure snake = SnakeGenerator(ref points);
            Assert.Greater(snake.Start[1], snake.End[1]);
        }

        [Test]
        [Ignore("Obsolete method of creating game")]
        public void TestLadderGenerator()
        {
            HashSet<int> points = new HashSet<int>();
            Structure snake = LadderGenerator(ref points);
            Assert.Greater(snake.End[1], snake.Start[1]);
        }
    }
}
