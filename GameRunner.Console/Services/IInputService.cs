using GameRunner.Shared;

namespace GameRunner.ConsoleApp.Services
{
    public interface IInputService
    {
        int GatherPlayerInput(TicTacToe ticTacToe);
    }
}
