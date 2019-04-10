using System;
using System.Linq;

namespace GameRunner.Shared
{
    public class TicTacToe : IGame
    {
        private string _winner;
        private string[] _positionList = new string[9];
        private int _playersTurn = 1;

        public string this[int position]
        {
            get { return _positionList[position]; }
        }

        public string Winner
        {
            get { return _winner; }
        }

        public bool Play(int position)
        {
            // determine which players turn
            string player = _playersTurn % 2 == 0 ? "O" : "X";

            RecordTurn(position, player);

            bool hasMatch = HasMatch(player);
            bool allSpotsTaken = AllSpotsTaken();

            if (hasMatch)
            {
                SaveWinner(player);
            }
            else
            {
                if (allSpotsTaken)
                {
                    SaveDraw();
                }
            }

            IncrementPlayerTurn();

            return hasMatch == true || allSpotsTaken == true;
        }

        private bool HasMatch(string player)
        {
            return
                // 1-2-3 match
                (_positionList[0] == player && _positionList[1] == player && _positionList[2] == player) ||
                // 1-4-7 match
                (_positionList[0] == player && _positionList[3] == player && _positionList[6] == player) ||
                // 1-5-9 match
                (_positionList[0] == player && _positionList[4] == player && _positionList[8] == player) ||
                // 2-5-8 match
                (_positionList[1] == player && _positionList[4] == player && _positionList[7] == player) ||
                // 3-6-9 match
                (_positionList[2] == player && _positionList[5] == player && _positionList[8] == player) ||
                // 3-5-7 match
                (_positionList[2] == player && _positionList[4] == player && _positionList[6] == player) ||
                // 4-5-6 match
                (_positionList[3] == player && _positionList[4] == player && _positionList[5] == player) ||
                // 7-8-9 match
                (_positionList[6] == player && _positionList[7] == player && _positionList[8] == player);
        }

        private void RecordTurn(int position, string player)
        {
            _positionList[position - 1] = player;
        }

        private void IncrementPlayerTurn()
        {
            _playersTurn++;
        }

        private void SaveWinner(string player)
        {
            _winner = String.Format("Player {0} Won!", player);
        }

        private void SaveDraw()
        {
            _winner = "Cat's Game!";
        }

        private bool AllSpotsTaken()
        {
            return _positionList.All(x => x != null);
        }
    }
}
