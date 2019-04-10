using GameRunner.ConsoleApp.Services;
using GameRunner.Shared;
using System;

namespace GameRunner.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();
            TicTacToe ticTacToe = new TicTacToe();

            IInputService inputService = new TicTacToeInputService();

            bool hasWinner = false;

            while (!hasWinner)
            {
                GenerateTicTacToeBoard(ticTacToe);
                int position = inputService.GatherPlayerInput(ticTacToe);

                hasWinner = ticTacToe.Play(position);
            }

            DisplayWinner(ticTacToe);
        }

        /// <summary>
        /// Generates tic-tac-toe board based on the current state of the game.
        /// </summary>
        /// <param name="ticTacToe"></param>
        private static void GenerateTicTacToeBoard(TicTacToe ticTacToe)
        {
            Console.WriteLine();

            Console.WriteLine("{0} | {1} | {2}", ticTacToe[6] ?? "7", ticTacToe[7] ?? "8", ticTacToe[8] ?? "9");
            Console.WriteLine("{0} | {1} | {2}", ticTacToe[3] ?? "4", ticTacToe[4] ?? "5", ticTacToe[5] ?? "6");
            Console.WriteLine("{0} | {1} | {2}", ticTacToe[0] ?? "1", ticTacToe[1] ?? "2", ticTacToe[2] ?? "3");

            Console.WriteLine();
        }

        /// <summary>
        /// Displays a welcome to the user with basic instructions.
        /// </summary>
        private static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe! Player 1 is X and Player 2 is O. Player 1, you are up!");
        }

        /// <summary>
        /// Displays who the winner was.
        /// </summary>
        /// <param name="ticTacToe"></param>
        private static void DisplayWinner(TicTacToe ticTacToe)
        {
            Console.WriteLine();
            Console.WriteLine(ticTacToe.Winner);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
