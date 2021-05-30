using Entities.Boards;
using Entities.Dice;
using Entities.Player;
using System;
using System.Collections.Generic;

namespace Snake_Ladder
{
    public class Two_dimensional : Game
    {
        public Two_dimensional(IBoard b, IList<Player> p, IDice d) : base(b,p,d)
        {
        }
        public override void Actions(Player player)
        {
            int numberOfSteps = dice.RollDice();
            MoveThePawn(numberOfSteps, player);
            MoveAlongTheStructure(player);
            UpdateStatus(player);
        }
        public override void MoveThePawn(int numberOfSteps, Player player)
        {
            int originalX = player.position.X;
            int originalY = player.position.Y;

            while (numberOfSteps != 0)
            {
                if ((player.position.X == board.cols - 1 && player.position.Y < board.rows - 1 && player.position.Y % 2 == 0)
                    || (player.position.X == 0 && player.position.Y % 2 == 1))
                    player.position.Y++;

                else if (player.position.Y % 2 == 1)
                    player.position.X--;

                else
                    player.position.X++;


                if (player.position.X >= board.rows || player.position.Y >= board.cols)
                {
                    player.position.X = originalX;
                    player.position.Y = originalY;
                    return;
                }

                numberOfSteps--;
            }
        }

        public override void UpdateStatus(Player player)
        {
            if ((board.rows % 2 == 1 && player.position.X == board.rows - 1 && player.position.Y == board.cols - 1) ||
                (board.rows % 2 == 0 && player.position.X == 0 && player.position.Y == board.cols - 1))
            {
                UpdateStatus(GameStatus.OVER);
                player.UpdateStatus(PlayerStatus.WON);
            }                
        }

        public override void MoveAlongTheStructure(Player player)
        {
            string key = string.Concat(player.position.X, "_", player.position.Y);
            if (board.structures.ContainsKey(key))
            {
                Console.WriteLine((board.structures[key]).GetType().Name + " encountered");
                player.position.X = board.structures[key].End[0];
                player.position.Y = board.structures[key].End[1];
            }
        }
    }
}
