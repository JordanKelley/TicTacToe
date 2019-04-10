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
                int position = GatherInputPosition(ticTacToe);

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
        /// Gathers input from player and ensures that the input is sanitized and the position is available.
        /// </summary>
        /// <param name="ticTacToe"></param>
        /// <returns>Returns input from user that has been sanitized.</returns>
        private static int GatherInputPosition(TicTacToe ticTacToe)
        {
            Console.WriteLine("Please input a number for the spot you want: ");
            string inputPosition = Console.ReadLine();

            return ValidateInput(inputPosition, ticTacToe);
        }

        private static int ValidateInput(string inputPosition, TicTacToe ticTacToe)
        {
            int inputPositionSanitized = SanitizeInputPosition(inputPosition);

            bool positionIsAvailable = PositionIsAvailable(inputPositionSanitized, ticTacToe);

            while (!positionIsAvailable)
            {
                inputPosition = DisplayPositionAlreadyTakenErrorWithInput();
                inputPositionSanitized = SanitizeInputPosition(inputPosition);
                positionIsAvailable = PositionIsAvailable(inputPositionSanitized, ticTacToe);
            }

            return inputPositionSanitized;
        }

        #region Helper Functions For Validating Input
        /// <summary>
        /// Receives input from user and ensures that it is an integer 1-9. Gives user 3 chances. 
        /// </summary>
        /// <param name="inputPosition"></param>
        /// <returns>Returns sanitized valid integer 1-9 enterred by user.</returns>
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
                    inputPosition = DisplayNotValidIntegerErrorWithInput();
                }

                count++;
            }

            if (inputSanitized)
            {
                return inputPositionSanitized;
            }
            else
            {
                throw new Exception("Tried 3 times and user did not put in valid integer");
            }
        }

        private static string DisplayNotValidIntegerErrorWithInput()
        {
            Console.WriteLine("The value you entered was not an integer 1-9. Please enter a valid integer: ");
            return Console.ReadLine();
        }

        private static string DisplayPositionAlreadyTakenErrorWithInput()
        {
            Console.WriteLine("The position you entered has already been taken by a player. Please try again: ");
            return Console.ReadLine();
        }

        private static bool PositionIsAvailable(int position, TicTacToe ticTacToe)
        {
            return ticTacToe[position - 1] == null;
        }

        #endregion

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
