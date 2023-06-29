using TicTacToeLibrary.Enum;


namespace TicTacToeLibrary.Models
{
    public class Grid
    {
        private string[,] _gameGrid = new string[3, 3];

        public Grid()
        {

        }

        public string[,] GameGrid
        {
            get { return _gameGrid; }
        }

        public void PrintGrid()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {

                    Console.Write(String.Format("[{0}]", _gameGrid[i, j]));
                }
                Console.WriteLine();
            }
        }

        public bool FilledMatrix()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (_gameGrid[i, j] != null)
                    {
                        count++;
                    }
                }
            }

            if (count == 9)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void InsertSymbol(Symbol? symbol, int row, int column)
        {
#pragma warning disable CS0162 // Unreachable code detected
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (GameGrid[row, column] == null)
                    {
                        GameGrid[row, column] = symbol.ToString();
                        break;
                    }
                    else if (GameGrid[row, column] == "X" || GameGrid[row, column] == "O")
                    {
                        Console.WriteLine("This box already filled");
                        Console.ReadKey();
                        break;
                    }
                }
                break;
            }
#pragma warning restore CS0162 // Unreachable code detected

        }
    }
}
