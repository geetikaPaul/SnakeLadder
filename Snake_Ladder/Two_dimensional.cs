using System;
using System.Collections.Generic;
using System.Text;

namespace Snake_Ladder
{
    public class Two_dimensional : Game
    {
        public Two_dimensional() { }
        public Two_dimensional(int r, int c) : base(r, c) { }
        public override void Actions(int numberOfSteps, Player player)
        {
            MoveThePawn(numberOfSteps, player);
            UpdateStatus(player);
        }
        public override void MoveThePawn(int numberOfSteps, Player player)
        {
            int originalX = player.position.X;
            int originalY = player.position.Y;

            while (numberOfSteps != 0)
            {
                if ((player.position.X == cols - 1 && player.position.Y < rows - 1 && player.position.Y % 2 == 0) || (player.position.X == 0 && player.position.Y % 2 == 1))
                    player.position.Y++;

                else if (player.position.Y % 2 == 1)
                    player.position.X--;

                else
                    player.position.X++;


                if (player.position.X >= rows || player.position.Y >= cols)
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
            if ((rows % 2 == 1 && player.position.X == rows - 1 && player.position.Y == cols - 1) ||
                (rows % 2 == 0 && player.position.X == 0 && player.position.Y == cols - 1))
            {
                UpdateGameStatus(GameStatus.OVER);
                player.UpdateStatus(PlayerStatus.WON);
            }                
        }

    }
}
