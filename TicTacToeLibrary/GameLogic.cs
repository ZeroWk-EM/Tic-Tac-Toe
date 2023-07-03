
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

        // TODO: RE-WRITE CONDITION
        private bool CheckWinner()
        {
            Symbol?[,] matrix = grid.GetGrid();

            //RIGHE COLONNE DIAGONALI

            if (
             (matrix[0, 0] == Symbol.X && matrix[0, 1] == Symbol.X && matrix[0, 2] == Symbol.X) ||
             (matrix[1, 0] == Symbol.X && matrix[1, 1] == Symbol.X && matrix[1, 2] == Symbol.X) ||
             (matrix[2, 0] == Symbol.X && matrix[2, 1] == Symbol.X && matrix[2, 2] == Symbol.X) ||

             (matrix[0, 0] == Symbol.X && matrix[1, 0] == Symbol.X && matrix[2, 0] == Symbol.X) ||
             (matrix[0, 1] == Symbol.X && matrix[1, 1] == Symbol.X && matrix[2, 1] == Symbol.X) ||
             (matrix[0, 2] == Symbol.X && matrix[1, 2] == Symbol.X && matrix[2, 2] == Symbol.X) ||

             (matrix[0, 0] == Symbol.X && matrix[1, 1] == Symbol.X && matrix[2, 2] == Symbol.X) ||
             (matrix[0, 2] == Symbol.X && matrix[1, 1] == Symbol.X && matrix[2, 0] == Symbol.X))
            {
                return true;
            }
            else if (
             (matrix[0, 0] == Symbol.O && matrix[0, 1] == Symbol.O && matrix[0, 2] == Symbol.O) ||
             (matrix[1, 0] == Symbol.O && matrix[1, 1] == Symbol.O && matrix[1, 2] == Symbol.O) ||

             (matrix[2, 0] == Symbol.O && matrix[2, 1] == Symbol.O && matrix[2, 2] == Symbol.O) ||

             (matrix[0, 0] == Symbol.O && matrix[1, 0] == Symbol.O && matrix[2, 0] == Symbol.O) ||
             (matrix[0, 1] == Symbol.O && matrix[1, 1] == Symbol.O && matrix[2, 1] == Symbol.O) ||
             (matrix[0, 2] == Symbol.O && matrix[1, 2] == Symbol.O && matrix[2, 2] == Symbol.O) ||

             (matrix[0, 0] == Symbol.O && matrix[1, 1] == Symbol.O && matrix[2, 2] == Symbol.O) ||
             (matrix[0, 2] == Symbol.O && matrix[1, 1] == Symbol.O && matrix[2, 0] == Symbol.O))
            {
                return true;
            }
            return false;
        }

        // TODO: RE-WRITE METHOD
        public void StartGame(Player o1, Player o2)
        {
            Player firstPlayer = o1;
            Player secondPlayer = o2;

            do
            {

                Console.Write(String.Format("PG 1 [{0}]", player1.Symbol));
                Console.WriteLine(String.Format(" PG 2 [{0}]", player2.Symbol));
                Console.WriteLine(String.Format("Selected Game Mode [{0}]\n", _gameMode));
                Console.WriteLine("===========");
                Console.WriteLine("7 - [0,0]");
                Console.WriteLine("8 - [0,1]");
                Console.WriteLine("9 - [0,2]");
                Console.WriteLine("4 - [1,0]");
                Console.WriteLine("5 - [1,1]");
                Console.WriteLine("6 - [1,2]");
                Console.WriteLine("1 - [2,0]");
                Console.WriteLine("2 - [2,1]");
                Console.WriteLine("3 - [2,2]");
                Console.WriteLine("===========");

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
                            Console.WriteLine(grid.IsFilled(resultRow, resultColumn));
                            Console.WriteLine(Grid.IsOut(resultRow, resultColumn));

                            grid.InsertSymbol(firstPlayer.Symbol, resultRow, resultColumn);
                            grid.PrintGrid();

                            if (CheckWinner())
                            {
                                Console.WriteLine("WIN");
                                Environment.Exit(0);
                            }
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }

            } while (!(firstPlayer.IsWinner || secondPlayer.IsWinner));
        }
    }
}
