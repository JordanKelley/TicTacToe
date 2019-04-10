using GameRunner.Shared;
using System;

namespace GameRunner
{
    class Program
    {
        static void Main(string[] args)
        {
            DisplayWelcome();
            TicTacToe ticTacToe = new TicTacToe();

            bool hasWinner = false;

            while (!hasWinner)
            {
                GenerateTicTacToeBoard(ticTacToe);
                int position = GatherInputPosition();

                hasWinner = ticTacToe.Play(position);
            }
            DisplayWinner(ticTacToe);
        }

        private static void GenerateTicTacToeBoard(TicTacToe ticTacToe)
        {
            Console.WriteLine();

            Console.WriteLine("{0} | {1} | {2}", ticTacToe[6] ?? "7", ticTacToe[7] ?? "8", ticTacToe[8] ?? "9");
            Console.WriteLine("{0} | {1} | {2}", ticTacToe[3] ?? "4", ticTacToe[4] ?? "5", ticTacToe[5] ?? "6");
            Console.WriteLine("{0} | {1} | {2}", ticTacToe[0] ?? "1", ticTacToe[1] ?? "2", ticTacToe[2] ?? "3");

            Console.WriteLine();
        }

        private static int GatherInputPosition()
        {
            Console.WriteLine("Please input a number for the spot you want: ");
            string inputPosition = Console.ReadLine();

            return SanitizeInputPosition(inputPosition);
        }

        private static int SanitizeInputPosition(string inputPosition)
        {
            // 3 tries for user to input valid input
            int count = 1;
            bool inputSanitized = false;
            int inputPositionSanitized = 0;

            while (count < 3 && !inputSanitized)
            {
                bool conversionHappened = Int32.TryParse(inputPosition, out inputPositionSanitized);

                inputSanitized = conversionHappened && inputPositionSanitized <= 9 && inputPositionSanitized > 0;

                if (!inputSanitized)
                {
                    inputPosition = DisplayErrorWithInput();
                }

                count++;
            }

            if (inputSanitized)
            {
                return inputPositionSanitized;
            }
            else
            {
                throw new Exception("User did not put in valid input");
            }
        }

        private static string DisplayErrorWithInput()
        {
            Console.WriteLine("The value you entered was not an integer 1-9. Please enter a valid integer: ");
            return Console.ReadLine();
        }

        private static void DisplayWelcome()
        {
            Console.WriteLine("Welcome to Tic-Tac-Toe! Player 1 is X and Player 2 is O. Player 1, you are up!");
        }

        private static void DisplayWinner(TicTacToe ticTacToe)
        {
            Console.WriteLine();
            Console.WriteLine(ticTacToe.Winner);
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
