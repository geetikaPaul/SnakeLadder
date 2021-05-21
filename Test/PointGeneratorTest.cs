using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace Test
{
    public class PointGeneratorTest : PointGenerator
    {
        [SetUp]
        public void SetUp()
        {
            rows = 10;
            cols = 10;
        }

        [Test]
        public void TestStartPointUniqueness()
        {
            HashSet<int> points = new HashSet<int>() { 2, 4, 5, 7 };
            int actual = StartPointGenerator(ref points);
            List<int> expected = new List<int>() { 0, 1, 3, 6, 8 };
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
