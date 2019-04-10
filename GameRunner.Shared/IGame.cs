using System;

namespace GameRunner.Shared
{
    internal interface IGame
    {
        String Winner { get; }

        Boolean Play(Int32 position);

        String this[Int32 position] { get; }
    }
}
