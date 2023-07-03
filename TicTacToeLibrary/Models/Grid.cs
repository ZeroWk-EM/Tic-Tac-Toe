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

        // Create a copy of game grid
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

        public void PrintGrid()
        {
            Symbol?[,] grid = GetGrid();
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write(String.Format("[{0}]", grid[i, j]));
                }
                Console.WriteLine();
            }
        }

        public bool IsFilled(int row, int column)
        {
            return _gameGrid[row, column] != null;
        }

        public void InsertSymbol(Symbol? symbol, int row, int column)
        {
            if (IsFilled(row, column))
            {
                throw new ArgumentException("Cell already filled");
            }
            _gameGrid[row, column] = symbol;
        }
    }
}
