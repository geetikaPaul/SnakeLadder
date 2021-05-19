using System.Collections.Generic;
using Entities.Structures;

namespace Entities.Game
{
    public enum GameStatus
    {
        STARTED, NEW, PENDING, OVER, EXPIRED, RUNNING
    }
    public class Game
    {
        public int rows { get; private set; }
        public int cols { get; private set; }
        public GameStatus status { get; private set; }
        public Dictionary<string, Structure> structures { get; private set; }

        public Game()
        {
            status = GameStatus.NEW;
            rows = 5;
            cols = 5;
            structures = new Dictionary<string, Structure>();
        }

        public Game(int r, int c)
        {
            status = GameStatus.NEW;
            rows = r;
            cols = c;
            structures = new Dictionary<string, Structure>() {
                { "5_0",new Ladder(new int[] {5,0}, new int[] {4,4}) },
                { "7_1",new Snake(new int[] {7,1}, new int[]{2,7}) }
            };
        }

        public void UpdateStatus(GameStatus stat)
        {
            status = stat;
        }

    }
}
