using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Ladder
{
    public enum GameStatus
    {
        STARTED, NEW, PENDING, OVER, EXPIRED, RUNNING
    }
    public abstract class Game
    {
        protected int rows;
        protected int cols;
        public GameStatus status { get; private set; }

        public Game()
        {
            status = GameStatus.NEW;
            rows = 5;
            cols = 5;
        }

        public Game(int r, int c)
        {
            status = GameStatus.NEW;
            rows = r;
            cols = c;
        }

        public abstract void MoveThePawn(int numberOfSteps, Player player);
        public abstract void Actions(int numberOfSteps, Player player);
        public abstract void UpdateStatus(Player player);

        public void UpdateGameStatus(GameStatus stat)
        {
            status = stat;
        }

    }
}
