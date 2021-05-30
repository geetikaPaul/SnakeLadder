using Entities.Boards;
using System;
using System.Collections.Generic;
using System.Text;

namespace BoardGenerator
{
    public class BasicBoard : IBoard
    {
        protected IBoard game;
        public BasicBoard(IBoard g)
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
            structures = game.structures;
        }
    }
}
