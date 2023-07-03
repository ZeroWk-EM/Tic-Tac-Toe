
using TicTacToeLibrary.Enum;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary
{
    public class GameLogic
    {
        public const int MaxGridSize = 3;

        readonly Player player1 = new();
        readonly Player player2 = new();

        private string _gameMode = "";
        private Player[] _turnOrder = new Player[2];

        readonly Grid grid = new();

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


        private bool CheckWinner(Player pg)
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

        // TODO: FIX IterativeCheckWinner CONDITION

        private bool IterativeCheckWinner(Player pg)
        {
            Symbol?[,] matrix = grid.GetGrid();

            for (int i = 0; i < MaxGridSize; i++)
            {
                for (int j = 0; j < MaxGridSize; j++)
                {
                    // ROW

                    // COLUMN

                    //DIAG
                }
            }

      
            return false;
        }

        // TODO: RE-WRITE StartGame METHOD
        public void StartGame(Player o1, Player o2)
        {
            Player firstPlayer = o1;
            Player secondPlayer = o2;
            do
            {
                Console.Write("Player Do wanna put the symbol: ");

                Console.Write("\nEnter row: ");
                string? rowChoice = Console.ReadLine();

                if (int.TryParse(rowChoice, out int resultRow))
                {
                    Console.Write("\nEnter column: ");
                    string? columnChoice = Console.ReadLine();

                    if (int.TryParse(columnChoice, out int resultColumn))
                    {
                        try
                        {
                            // DEBUG
                            grid.InsertSymbol(firstPlayer.Symbol, resultRow, resultColumn);
                            grid.PrintGrid();

                            if (CheckWinner(firstPlayer))
                            {
                                Console.WriteLine("WIN");
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                        catch (IndexOutOfRangeException)
                        {
                            Console.WriteLine("Exceed matrix bounds");
                        }
                    }
                }

            } while (!(firstPlayer.IsWinner || secondPlayer.IsWinner));
        }
    }
}
