using System;

namespace Snake_Ladder
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Two_dimensional(10,10);
            Player player1 = new Player();
            Player player2 = new Player();

            IDice dice = new SingleRandomizedDice();

            int turn = 0;

            do
            {
                int diceNumber = dice.RollDice();
                Console.WriteLine(diceNumber);

                if (turn%2==0)
                {
                    game.Actions(diceNumber, player1);
                    Console.WriteLine("Player 1 at: " + player1.position.X + "," + player1.position.Y);
                    if (player1.status == PlayerStatus.WON)
                    {
                        Console.WriteLine("Player 1 won");
                        break;
                    }
                }
                else
                {
                    game.Actions(diceNumber, player2);
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
