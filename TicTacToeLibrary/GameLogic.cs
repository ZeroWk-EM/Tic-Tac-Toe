using System.Diagnostics.Metrics;
using TicTacToeLibrary.Enum;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary
{
    public class GameLogic
    {

        readonly Player player1 = new();
        readonly Player player2 = new();

        private string _gameMode = "";
        private Player[] _turnOrder = new Player[2];

        readonly Grid grid = new();

        public const int MaxGridSize = Grid.MaxGridSize;

        public string GameMode
        {
            get { return _gameMode; }
            set { _gameMode = value; }
        }

        public Player[] TurnOrder
        {
            get { return _turnOrder; }
            private set { _turnOrder = value; }
        }

        public Grid Grid { get { return grid; } }

        // For select the symbol OK
        public static bool SelectSymbol(string choicePG, Player pg1, Player pg2)
        {
            if (int.TryParse(choicePG, out int resultPG))
            {
                switch (resultPG)
                {
                    case 1:
                        pg1.Symbol = Symbol.X;
                        pg2.Symbol = Symbol.O;
                        return false;
                    case 2:
                        pg1.Symbol = Symbol.O;
                        pg2.Symbol = Symbol.X;
                        return false;
                    default:
                        return true;
                }

            }
            return true;

        }

        // For choice the game mode OK
        public bool SelectGameMode(string choice)
        {
            if (int.TryParse(choice, out int result))
            {
                switch (result)
                {
                    case 1:
                        GameMode = "P1 vs P2";
                        return false;
                    case 2:
                        GameMode = "P1 vs CPU";
                        return false;
                    default:
                        return true;
                }
            }
            return true;
        }

        // For set the turnOrder and assign symbol to player OK
        public (bool condition, Player? first, Player? second) LoadPlayer(string choice)
        {
            if (int.TryParse(choice, out int result))
            {
                switch (result)
                {
                    case 1:
                        TurnOrder[0] = this.player1;
                        TurnOrder[1] = this.player2;
                        Console.Clear();
                        return (false, this.player1, this.player2);
                    case 2:

                        TurnOrder[0] = this.player2;
                        TurnOrder[1] = this.player1;
                        Console.Clear();
                        return (false, this.player2, this.player1);
                    default:
                        return (true, null, null);
                }

            }
            return (true, null, null);
        }

        public bool CheckWinner(Player pg)
        {
            Symbol?[,] matrix = grid.GetGrid();
            //RIGHE COLONNE DIAGONALI
            if (
             (matrix[0, 0] == pg.Symbol && matrix[0, 1] == pg.Symbol && matrix[0, 2] == pg.Symbol) ||
             (matrix[1, 0] == pg.Symbol && matrix[1, 1] == pg.Symbol && matrix[1, 2] == pg.Symbol) ||
             (matrix[2, 0] == pg.Symbol && matrix[2, 1] == pg.Symbol && matrix[2, 2] == pg.Symbol) ||

             (matrix[0, 0] == pg.Symbol && matrix[1, 0] == pg.Symbol && matrix[2, 0] == pg.Symbol) ||
             (matrix[0, 1] == pg.Symbol && matrix[1, 1] == pg.Symbol && matrix[2, 1] == pg.Symbol) ||
             (matrix[0, 2] == pg.Symbol && matrix[1, 2] == pg.Symbol && matrix[2, 2] == pg.Symbol) ||

             (matrix[0, 0] == pg.Symbol && matrix[1, 1] == pg.Symbol && matrix[2, 2] == pg.Symbol) ||
             (matrix[0, 2] == pg.Symbol && matrix[1, 1] == pg.Symbol && matrix[2, 0] == pg.Symbol))
            {
                return true;
            }
            return false;
        }

        public bool IterativeCheckWinner(Player pg)
        {
            Symbol?[,] matrix = grid.GetGrid();

            // ROW OK 
            for (int i = 0; i < MaxGridSize; i++)
            {
                int counter = 0;
                for (int j = 0; j < MaxGridSize; j++)
                {
                    if (matrix[i, j] == pg.Symbol)
                    {
                        counter++;
                    }
                }
                if (counter == MaxGridSize)
                {
                    return true;
                }
            }

            //COLUMN DA OTTIMIZZARE
            int columnCounter = 0;
            int column = 0;
            int turn = 0;
            int winnerCount = 0;
            for (int i = 0; i < MaxGridSize; i++)
            {
                if (turn < (MaxGridSize * MaxGridSize) && columnCounter == MaxGridSize)
                {
                    i = 0;
                    columnCounter = 0;

                }
                if (matrix[i, column] == pg.Symbol)
                {
                    winnerCount++;
                }
                columnCounter++;
                turn++;
                if (winnerCount == MaxGridSize)
                {
                    return true;
                }
                if (turn < (MaxGridSize * MaxGridSize) && columnCounter == MaxGridSize)
                {
                    column++;
                    i = 0;
                    winnerCount = 0;
                }

            }

            //MAIN DIAG OK
            int mainDiagCounter = 0;
            for (int i = 0; i < MaxGridSize; i++)
            {

                if (matrix[i, i] == pg.Symbol)
                {
                    mainDiagCounter++;
                }
                if (mainDiagCounter == MaxGridSize)
                {
                    return true;
                }
            }

            //ANTI-DIAG OK
            int antiDiagCounter = 0;
            for (int i = 0; i < MaxGridSize; i++)
            {

                if (matrix[i, MaxGridSize - i - 1] == pg.Symbol)
                {
                    antiDiagCounter++;
                }
                if (antiDiagCounter == MaxGridSize)
                {
                    return true;
                }
            }

            return false;
        }
    }
}