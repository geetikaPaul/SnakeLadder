using Entities.Games;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGenerator
{
    public class BasicBoard : IGame
    {
        protected IGame game;
        public BasicBoard(IGame g)
        {
            game = g;
        }
        public override void GenerateBoard()
        {
            game.GenerateBoard();
            SetGameProperties();
        }
        protected void SetGameProperties()
        {
            rows = game.rows;
            cols = game.cols;
            status = game.status;
            structures = game.structures;
        }
    }
}
