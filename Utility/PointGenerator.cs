using System;
using System.Collections.Generic;
using System.Linq;

namespace Utility
{
    public class PointGenerator
    {
        protected int rows;
        protected int cols;

        public PointGenerator()
        {
            rows = 10;
            cols = 10;
        }

        public PointGenerator(int r, int c)
        {
            rows = r;
            cols = c;
        }
        public int StartPointGenerator(ref HashSet<int> points)
        {
            HashSet<int> p = points;
            List<int> range = Enumerable.Range(0, cols - 1).Where(j => !p.Contains(j)).ToList<int>();
            Random r = new Random();
            int index = r.Next(0, (cols - 1) - points.Count);
            int point = range.ElementAt(index);
            points.Add(point);
            return point;
        }

        public int EndPointGenerator(HashSet<int> points, int startPoint)
        {
            Random r = new Random();
            List<int> range = Enumerable.Range(startPoint + 1, cols - startPoint - 1).Where(j => !points.Contains(j)).ToList<int>();
            int index = r.Next(0, range.Count);
            return range.ElementAt(index);
        }
    }
}
