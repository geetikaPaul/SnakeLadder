using System;
using System.Collections.Generic;
using System.Text;

namespace Entities
{
    public class Position
    {
        public int X { get; internal set; }
        public int Y { get; internal set; }

        public Position(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
