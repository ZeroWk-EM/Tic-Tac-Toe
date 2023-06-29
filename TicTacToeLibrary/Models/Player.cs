using TicTacToeLibrary.Enum;

namespace TicTacToeLibrary.Models
{

    public class Player
    {
        private Symbol? _symbol;
        private int _counterWin;
        private bool _isWinner;

        public Player(Symbol? symbol = null, int counterWin = 0, bool isWinner = false)
        {
            this.Symbol = symbol;
            this.CounterWin = counterWin;
            this.IsWinner = isWinner;
        }

        public Symbol? Symbol
        {
            get { return _symbol; }
            set
            {
                _symbol = value;
            }
        }

        public int CounterWin
        {
            get { return _counterWin; }
            set { _counterWin = value++; }
        }

        public bool IsWinner
        {
            get { return _isWinner; }
            set { _isWinner = value; }
        }


        // Reset all data if you want to continue the game
        public void ResetData()
        {

        }

        public override string ToString()
        {
            return String.Format("Choosen Symbol [{0}]\nWinner Player Count [{1}]", Symbol.ToString(), CounterWin);
        }
    }
}
