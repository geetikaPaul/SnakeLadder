using Entities.Games;
using Entities.Player;
using System;

namespace Snake_Ladder
{
    public class Two_dimensional : Machine
    {
        private IGame game;
        public Two_dimensional(IGame g)
        {
            game = g;
        }
        public override void Actions(int numberOfSteps, Player player)
        {
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
                if ((player.position.X == game.cols - 1 && player.position.Y < game.rows - 1 && player.position.Y % 2 == 0)
                    || (player.position.X == 0 && player.position.Y % 2 == 1))
                    player.position.Y++;

                else if (player.position.Y % 2 == 1)
                    player.position.X--;

                else
                    player.position.X++;


                if (player.position.X >= game.rows || player.position.Y >= game.cols)
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
            if ((game.rows % 2 == 1 && player.position.X == game.rows - 1 && player.position.Y == game.cols - 1) ||
                (game.rows % 2 == 0 && player.position.X == 0 && player.position.Y == game.cols - 1))
            {
                game.UpdateStatus(GameStatus.OVER);
                player.UpdateStatus(PlayerStatus.WON);
            }                
        }

        public override void MoveAlongTheStructure(Player player)
        {
            string key = string.Concat(player.position.X, "_", player.position.Y);
            if (game.structures.ContainsKey(key))
            {
                Console.WriteLine((game.structures[key]).GetType().Name + " encountered");
                player.position.X = game.structures[key].End[0];
                player.position.Y = game.structures[key].End[1];
            }
        }
    }
}
