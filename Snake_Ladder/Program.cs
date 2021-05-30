using System;
using BoardGenerator;
using Entities.Dice;
using Entities.Boards;
using Entities.Player;
using System.Collections.Generic;

namespace Snake_Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            IBoard board = new BoardWithSnakes(new BoardWithLadders(new Board()));
            board.GenerateBoard();

            IList<Player> players = new List<Player> { new Player(), new Player() };

            IDice dice = new SingleRandomizedDice();

            Game game = new Two_dimensional(board, players, dice);

            do
            {
                Player p = game.GetPlayerWhoseTurn();
                game.Actions(p);
                Console.WriteLine(string.Format("Player {0} at: {1},{2}", p.Id, p.position.X, p.position.Y));
                if (p.status == PlayerStatus.WON)
                    Console.WriteLine(string.Format("Player {0} won", p.Id));

            } while (game.status!= GameStatus.EXPIRED && game.status!= GameStatus.OVER);

            Console.Read();
        }
    }
}
