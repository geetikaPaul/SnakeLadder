using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Dice
{
    public class SingleRandomizedDice : IDice
    {
        public int RollDice()
        {
            return new Random().Next(1,7);
        }
    }
}
