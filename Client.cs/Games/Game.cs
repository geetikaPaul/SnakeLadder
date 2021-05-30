using Entities.Boards;
using Entities.Dice;
using Entities.Player;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Snake_Ladder
{    public enum GameStatus
    {
        STARTED, NEW, PENDING, OVER, EXPIRED, RUNNING
    }
    public abstract class Game
    {
        public IBoard board { get; private set; }
        public IList<Player> players { get; private set; }
        public GameStatus status { get; protected set; }
        public Player playerTurn { get; protected set; }
        public IDice dice { get; protected set; }

        private int playerCount;
        private int turnIndex;


        public Game(IBoard b, IList<Player> p, IDice d)
        {
            int cnt = p!=null ? p.ToList().Count : -1;

            if (PlayerCountValidation(cnt))
            {
                board = b;
                players = p;
                status = GameStatus.NEW;
                playerTurn = p[0];
                turnIndex = 0;
                playerCount = cnt;
                dice = d;
            }
            else
            {
                Console.WriteLine("Invalid game");
            }
        }
        protected bool PlayerCountValidation(int cnt)
        {
            if ( cnt < 2 || cnt > 4)
                return false;
            return true;
        }

        public Player GetPlayerWhoseTurn()
        {
            Player p = players[turnIndex];
            turnIndex= (turnIndex+1) % playerCount;
            return p;
        }

        public void UpdateStatus(GameStatus stat)
        {
            status = stat;
        }
        public abstract void Actions(Player player);
        public abstract void MoveThePawn(int numberOfSteps, Player player);
        public abstract void UpdateStatus(Player player);
        public abstract void MoveAlongTheStructure(Player player);
    }
}
