using Entities.Elements;
using Entities.Games;
using System;
using System.Collections.Generic;
using System.Text;
using Utility;

namespace BoardGenerator
{
    public class BoardWithLadders : BasicBoard
    {
        private int numberOfLadders;
        private PointGenerator pointGenerator;

        public BoardWithLadders(IGame g) : base (g)
        {
            SetGameProperties();
            numberOfLadders = new Random().Next(2, 5);
            pointGenerator = new PointGenerator(game.rows, game.cols);
        }
        protected Structure LadderGenerator(ref HashSet<int> points)
        {
            Random r = new Random();
            int startPoint = pointGenerator.StartPointGenerator(ref points);
            int endPoint = pointGenerator.EndPointGenerator(points, startPoint);
            return new Ladder(new int[] { r.Next(0, game.rows - 1), startPoint }, new int[] { r.Next(0, game.rows - 1), endPoint });
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
        public override void GenerateBoard()
        {
            base.GenerateBoard();
            AddLadders();
        }
    }
}
