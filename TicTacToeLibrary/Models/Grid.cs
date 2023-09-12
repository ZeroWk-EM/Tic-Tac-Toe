using TicTacToeLibrary.Enum;


namespace TicTacToeLibrary.Models
{
    public class Grid
    {
        public const int MaxGridSize = 3;
        private readonly Symbol?[,] _gameGrid = new Symbol?[MaxGridSize, MaxGridSize];

        public Grid()
        {

        }


        public Symbol?[,] GetGrid()
        {
            Symbol?[,] matrix = new Symbol?[MaxGridSize, MaxGridSize];
            for (int i = 0; i < MaxGridSize; i++)
            {
                for (int j = 0; j < MaxGridSize; j++)
                {
                    matrix[i, j] = _gameGrid[i, j];
                }
            }
            return matrix;
        }

        public void ResetGrid()
        {
            Array.Clear(_gameGrid, 0, _gameGrid.Length);
        }

        public bool IsFilled(int row, int column)
        {
            return (!IsOut(row, column)) && (_gameGrid[row, column] != null);
        }

        public static bool IsOut(int row, int column)
        {
            return row >= MaxGridSize || column >= MaxGridSize;
        }

        public void InsertSymbol(Symbol? symbol, int row, int column)
        {
            if (IsOut(row, column))
            {
                throw new ArgumentException("Exceed matrix bounds");
            }

            if (IsFilled(row, column))
            {
                throw new ArgumentException("Cell already filled");
            }
            _gameGrid[row, column] = symbol;
        }
    }
}
