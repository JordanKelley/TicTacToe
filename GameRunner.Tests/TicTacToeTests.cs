using System;
using System.Collections.Generic;
using System.Linq;
using Xunit;
using GameRunner.Shared;

namespace GameRunner.Tests
{
    public class TicTacToeTests
    {
        // I'm simply testing my tic-tac-toe class for the 3 different scenarios
        // through it's API entry point Play()

        [Theory]
        [MemberData(nameof(Get8DifferentMatchingLinesPlayer1), parameters:8)]
        public void TicTacToe_Player1Wins(int turn1, int turn2, int turn3, int turn4, int turn5)
        {
            // arrange
            TicTacToe sut = new TicTacToe();

            // act
            sut.Play(turn1);
            sut.Play(turn2);
            sut.Play(turn3);
            sut.Play(turn4);
            sut.Play(turn5);

            // assert
            Assert.Equal("Player X Won!", sut.Winner);
        }

        [Theory]
        [MemberData(nameof(Get8DifferentMatchingLinesPlayer2), parameters: 8)]
        public void TicTacToe_Player2Wins(int turn1, int turn2, int turn3, int turn4, int turn5, int turn6)
        {
            // arrange
            TicTacToe sut = new TicTacToe();

            // act
            sut.Play(turn1);
            sut.Play(turn2);
            sut.Play(turn3);
            sut.Play(turn4);
            sut.Play(turn5);
            sut.Play(turn6);

            // assert
            Assert.Equal("Player O Won!", sut.Winner);
        }

        //[Theory]
        //[InlineData(7, 0, 2, 0, )]
        //public void TicTacToe_Draw(int turn1, int turn2, int turn3, int turn4, int turn5, int turn6, int turn7, int turn8, int turn9)
        //{
        //    // arrange
        //    TicTacToe sut = new TicTacToe();

        //    // act
        //    sut.Play(turn1);
        //    sut.Play(turn2);
        //    sut.Play(turn3);
        //    sut.Play(turn4);
        //    sut.Play(turn5);
        //    sut.Play(turn6);
        //    sut.Play(turn7);
        //    sut.Play(turn8);
        //    sut.Play(turn9);

        //    // assert
        //    Assert.Equal("Cat's Game!", sut.Winner);
        //}

        public static IEnumerable<object[]> Get8DifferentMatchingLinesPlayer1(int numTests)
        {
            var allData = new List<object[]>
            {
                // 7-8-9 match 
                new object[] {7, 4, 8, 1, 9},
                // 4-5-6 match
                new object[] {4, 1, 5, 2, 6},
                // 1-2-3 match
                new object[] {1, 4, 2, 5, 3},
                // 7-4-1 match
                new object[] {7, 3, 4, 6, 1},
                // 8-5-2 match
                new object[] {8, 4, 5, 3, 2},
                // 9-6-3 match
                new object[] {9, 4, 6, 1, 3},
                // 7-5-3 match
                new object[] {7, 4, 5, 2, 3},
                // 9-5-1 match
                new object[] {9, 2, 5, 3, 1}
            };

            return allData.Take(numTests);
        }

        public static IEnumerable<object[]> Get8DifferentMatchingLinesPlayer2(int numTests)
        {
            var allData = new List<object[]>
            {
                // 7-8-9 match 
                new object[] {4, 7, 1, 8, 2, 9},
                // 4-5-6 match
                new object[] {1, 4, 7, 5, 2, 6},
                // 1-2-3 match
                new object[] {7, 1, 6, 2, 8, 3},
                // 7-4-1 match
                new object[] {2, 7, 3, 4, 9, 1},
                // 8-5-2 match
                new object[] {9, 8, 7, 5, 1, 2},
                // 9-6-3 match
                new object[] {1, 9, 5, 6, 2, 3},
                // 7-5-3 match
                new object[] {1, 7, 6, 5, 9, 3},
                // 9-5-1 match
                new object[] {2, 9, 3, 5, 7, 1}
            };

            return allData.Take(numTests);
        }
    }
}
