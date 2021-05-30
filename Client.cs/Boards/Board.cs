using System.Collections.Generic;
using Entities.Elements;

namespace Entities.Boards
{
    public class Board : IBoard
    {
        public Board()
        {
            rows = 5;
            cols = 5;
            structures = new Dictionary<string, Structure>();
        }

        public Board(int r, int c)
        {
            rows = r;
            cols = c;
            structures = new Dictionary<string, Structure>() {
                { "5_0",new Ladder(new int[] {5,0}, new int[] {4,4}) },
                { "7_1",new Snake(new int[] {7,1}, new int[]{2,7}) }
            };
        }

        public Board(int r, int c, Dictionary<string,Structure> sts)
        {
            rows = r;
            cols = c;
            structures = sts;
        }

        public override void GenerateBoard()
        {
            rows = 10;
            cols = 10;
        }

    }
}
