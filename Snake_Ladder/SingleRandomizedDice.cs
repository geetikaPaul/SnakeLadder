using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Ladder
{
    public class SingleRandomizedDice : IDice
    {
        public int RollDice()
        {
            return new Random().Next(1,7);
        }
    }
}
