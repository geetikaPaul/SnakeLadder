using System;
using System.Collections.Generic;
using System.Linq;
using Entities.Elements;
using Entities.Games;
using Utility;

namespace BoardGenerator
{
    public class SimpleBoardGenerator : IBoardGenerator
    {
        private const int rows = 10;
        private const int cols = 10;

        private int numberOfLadders;
        private int numberOfSnakes;

        private PointGenerator pointGenerator;

        private Dictionary<string, Structure> structures;

        public SimpleBoardGenerator()
        {
            numberOfLadders = new Random().Next(2, 5);
            numberOfSnakes = new Random().Next(2, 5);
            structures = new Dictionary<string, Structure>();
            pointGenerator = new PointGenerator(rows, cols);
        }
        protected Structure LadderGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int startPoint = pointGenerator.StartPointGenerator(ref points);
            int endPoint = pointGenerator.EndPointGenerator(points, startPoint);
            return new Ladder(new int[] { r.Next(0, rows - 1), startPoint }, new int[] { r.Next(0, rows - 1), endPoint });          
        }
        protected Structure SnakeGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int endPoint = pointGenerator.StartPointGenerator(ref points);
            int startPoint = pointGenerator.EndPointGenerator(points, endPoint);
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

        public IGame generateBoard()
        {
            AddLadders();
            AddSnakes();
            return new Game(rows, cols,structures);
        }
    }
}
