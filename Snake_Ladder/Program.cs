using System;
using Entities.Dice;
using Entities.Game;
using Entities.Player;

namespace Snake_Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game(10,10);
            Player player1 = new Player();
            Player player2 = new Player();

            Machine sys = new Two_dimensional(game);

            IDice dice = new SingleRandomizedDice();

            int turn = 0;

            do
            {
                int diceNumber = dice.RollDice();
                Console.WriteLine(diceNumber);

                if (turn%2==0)
                {
                    sys.Actions(diceNumber, player1);
                    Console.WriteLine("Player 1 at: " + player1.position.X + "," + player1.position.Y);
                    if (player1.status == PlayerStatus.WON)
                    {
                        Console.WriteLine("Player 1 won");
                        break;
                    }
                }
                else
                {
                    sys.Actions(diceNumber, player2);
                    Console.WriteLine("Player 2 at: " + player2.position.X + "," + player2.position.Y);
                    if (player2.status == PlayerStatus.WON)
                    {
                        Console.WriteLine("Player 2 won");
                        break;
                    }
                }

                turn++;

            } while (game.status!= GameStatus.EXPIRED);

            Console.Read();
        }
    }
}
