using Entities.Elements;
using Entities.Boards;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace BoardGenerator
{
    public class BoardWithSnakes : BasicBoard
    {
        private int numberOfSnakes;
        private PointGenerator pointGenerator;

        public BoardWithSnakes(IBoard g) : base (g)
        {
            SetGameProperties();
            numberOfSnakes = new Random().Next(2, 5);
            pointGenerator = new PointGenerator(game.rows, game.cols);
        }
        protected Structure SnakeGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int endPoint = pointGenerator.StartPointGenerator(ref points);
            int startPoint = pointGenerator.EndPointGenerator(points, endPoint);
            return new Snake(new int[] { r.Next(0, game.rows - 1), startPoint }, new int[] { r.Next(0, game.rows - 1), endPoint });
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
        public override void GenerateBoard()
        {
            base.GenerateBoard();
            AddSnakes();
        }


    }
}
