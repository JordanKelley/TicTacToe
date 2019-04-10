using GameRunner.Shared;
using System;

namespace GameRunner.ConsoleApp.Services
{
    public static class TicTacToeInputService
    {
        /// <summary>
        /// Gathers player input and returns validated input.
        /// </summary>
        /// <param name="ticTacToe"></param>
        /// <returns>Returns validated Tic-Tac-Toe friendly input</returns>
        public static int GatherPlayerInput(TicTacToe ticTacToe)
        {
            Console.WriteLine("Please input a number for the spot you want: ");
            string inputPosition = Console.ReadLine();

            return ValidateInput(inputPosition, ticTacToe);
        }

        /// <summary>
        /// Validates the input and returns the integer that the player submitted.
        /// </summary>
        /// <param name="inputPosition"></param>
        /// <param name="ticTacToe"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sanitizes user input to ensure that the input is an integer 1-9.
        /// </summary>
        /// <param name="inputPosition"></param>
        /// <returns>Returns a user entered integer 1-9.</returns>
        private static int SanitizeInputPosition(string inputPosition)
        {
            bool inputSanitized = false;
            int inputPositionSanitized = 0;

            while (!inputSanitized)
            {
                bool conversionHappened = Int32.TryParse(inputPosition, out inputPositionSanitized);

                inputSanitized = conversionHappened && inputPositionSanitized <= 9 && inputPositionSanitized > 0;

                if (!inputSanitized)
                {
                    inputPosition = DisplayNotValidIntegerErrorWithInput();
                }
            }

            return inputPositionSanitized;
        }

        #region Validate input helper functions
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
    }
}
