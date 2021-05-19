using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Structures;
using Entities.Game;

namespace BoardGenerator
{
    public class SimpleBoardGenerator : IBoardGenerator
    {
        private const int rows = 10;
        private const int cols = 10;

        private int numberOfLadders;
        private int numberOfSnakes;

        private Dictionary<string, Structure> structures;

        public SimpleBoardGenerator()
        {
            numberOfLadders = new Random().Next(2, 5);
            numberOfSnakes = new Random().Next(2, 5);
            structures = new Dictionary<string, Structure>();
        }
        protected Structure LadderGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int startPoint = StartPointGenerator(ref points);
            int endPoint = EndPointGenerator(points, startPoint);
            return new Ladder(new int[] { r.Next(0, rows - 1), startPoint }, new int[] { r.Next(0, rows - 1), endPoint });          
        }
        protected Structure SnakeGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int endPoint = StartPointGenerator(ref points);
            int startPoint = EndPointGenerator(points, endPoint);
            return new Snake(new int[] { r.Next(0, rows - 1), startPoint }, new int[] { r.Next(0, rows - 1), endPoint });
        }

        private void AddSnakes()
        {
            HashSet<int> points = new HashSet<int>();
            while (numberOfSnakes != 0)
            {
                Structure structure = SnakeGenerator(ref points);
                string key = string.Concat(structure.Start[0], "_", structure.Start[1]);
                if (!structures.ContainsKey(key))
                {
                    structures.Add(key, new Snake(structure.Start, structure.End));
                    numberOfSnakes--;
                }
            }
        }

        private void AddLadders()
        {
            HashSet<int> points = new HashSet<int>();
            while (numberOfLadders != 0)
            {
                Structure structure = LadderGenerator(ref points);
                string key = string.Concat(structure.Start[0], "_", structure.Start[1]);
                if (!structures.ContainsKey(key))
                {
                    structures.Add(key, new Ladder(structure.Start, structure.End));
                    numberOfLadders--;
                }
            }
        }

        protected int StartPointGenerator(ref HashSet<int> points)
        {
            HashSet<int> p = points;
            List<int> range = Enumerable.Range(0, cols-1).Where(j => !p.Contains(j)).ToList<int>();
            Random r = new Random();
            int index = r.Next(0, (cols - 1) - points.Count);
            int point = range.ElementAt(index);
            points.Add(point);
            return point;
        }

        protected int EndPointGenerator(HashSet<int> points, int startPoint)
        {
            Random r = new Random();
            List<int> range = Enumerable.Range(startPoint + 1, cols - startPoint - 1).Where(j => !points.Contains(j)).ToList<int>();
            int index = r.Next(0, range.Count);
            return range.ElementAt(index);
        }

        public Game BoardGenerator()
        {
            AddLadders();
            AddSnakes();
            return new Game(rows, cols,structures);
        }
    }
}
