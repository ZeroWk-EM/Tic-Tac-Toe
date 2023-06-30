
using TicTacToeLibrary.Enum;
using TicTacToeLibrary.Models;

namespace TicTacToeLibrary
{
    public class GameLogic
    {
        Player player1 = new();
        Player player2 = new();

        private string _gameMode = "";
        private Player[] _turnOrder = new Player[2];
        private int _turnCount = 1;

        Grid grid = new();

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
        public static bool SelectSymbol(string choicePG,Player pg1, Player pg2)
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
            string[,] matrix = grid.GameGrid;

            //RIGHE COLONNE DIAGONALI

            if (
             (matrix[0, 0] == "X" && matrix[0, 1] == "X" && matrix[0, 2] == "X") ||
             (matrix[1, 0] == "X" && matrix[1, 1] == "X" && matrix[1, 2] == "X") ||
             (matrix[2, 0] == "X" && matrix[2, 1] == "X" && matrix[2, 2] == "X") ||

             (matrix[0, 0] == "X" && matrix[1, 0] == "X" && matrix[2, 0] == "X") ||
             (matrix[0, 1] == "X" && matrix[1, 1] == "X" && matrix[2, 1] == "X") ||
             (matrix[0, 2] == "X" && matrix[1, 2] == "X" && matrix[2, 2] == "X") ||

             (matrix[0, 0] == "X" && matrix[1, 1] == "X" && matrix[2, 2] == "X") ||
             (matrix[0, 2] == "X" && matrix[1, 1] == "X" && matrix[2, 0] == "X"))
            {
                return true;
            }
            else if (
             (matrix[0, 0] == "O" && matrix[0, 1] == "O" && matrix[0, 2] == "O") ||
             (matrix[1, 0] == "O" && matrix[1, 1] == "O" && matrix[1, 2] == "O") ||
          
             (matrix[2, 0] == "O" && matrix[2, 1] == "O" && matrix[2, 2] == "O") ||

             (matrix[0, 0] == "O" && matrix[1, 0] == "O" && matrix[2, 0] == "O") ||
             (matrix[0, 1] == "O" && matrix[1, 1] == "O" && matrix[2, 1] == "O") ||
             (matrix[0, 2] == "O" && matrix[1, 2] == "O" && matrix[2, 2] == "O") ||

             (matrix[0, 0] == "O" && matrix[1, 1] == "O" && matrix[2, 2] == "O") ||
             (matrix[0, 2] == "O" && matrix[1, 1] == "O" && matrix[2, 0] == "O"))
            {
                return true;
            }
            return false;
        }

        public void StartGame(Player o1,Player o2)
        {
            Player firstPlayer = o1;
            Player secondPlayer = o2;

            do
            {

                Console.Write(String.Format("PG 1 [{0}]", player1.Symbol));
                Console.WriteLine(String.Format(" PG 2 [{0}]", player2.Symbol));
                Console.WriteLine(String.Format("Selected Game Mode [{0}]\n", _gameMode));
                grid.PrintGrid();
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

                if (_turnCount == 1)
                {
                    Console.Write("Player Do wanna put the symbol: ");
                    string? choice = Console.ReadLine();
                    if (int.TryParse(choice, out int result))
                    {

                        switch (result)
                        {
                            case 1:
                                grid.InsertSymbol(firstPlayer.Symbol, 2, 0);
                                break;
                            case 2:
                                grid.InsertSymbol(firstPlayer.Symbol, 2, 1);
                                break;
                            case 3:
                                grid.InsertSymbol(firstPlayer.Symbol, 2, 2);
                                break;
                            case 4:
                                grid.InsertSymbol(firstPlayer.Symbol, 1, 0);
                                break;
                            case 5:
                                grid.InsertSymbol(firstPlayer.Symbol, 1, 1);
                                break;
                            case 6:
                                grid.InsertSymbol(firstPlayer.Symbol, 1, 2);
                                break;
                            case 7:
                                grid.InsertSymbol(firstPlayer.Symbol, 0, 0);
                                break;
                            case 8:
                                grid.InsertSymbol(firstPlayer.Symbol, 0, 1);
                                break;
                            case 9:
                                grid.InsertSymbol(firstPlayer.Symbol, 0, 2);
                                break;
                            default:
                                Console.WriteLine("ERROR enter a value 1-9");
                                _turnCount = 0;
                                Console.ReadKey();
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Not valid char");
                        _turnCount = 0;
                        Console.ReadKey();
                    }
                    if (CheckWinner())
                    {
                        Console.Clear();
                        Console.Write(String.Format("PG 1 [{0}]", player1.Symbol));
                        Console.WriteLine(String.Format(" PG 2 [{0}]\n", player2.Symbol));
                        grid.PrintGrid();
                        Console.WriteLine(String.Format("\n[{0}] Win", firstPlayer.Symbol));
                        firstPlayer.IsWinner = true;
                        Console.ReadKey();
                    }
                    if (grid.FilledMatrix())
                    {
                        Console.WriteLine("Draw!!");
                        Console.ReadKey();
                    }
                    _turnCount++;
                }
                else
                {
                    Console.Write("Player Do wanna put the symbol: ");
                    string? choice = Console.ReadLine();
                    if (int.TryParse(choice, out int result))
                    {
                        switch (result)
                        {
                            case 1:
                                grid.InsertSymbol(secondPlayer.Symbol, 2, 0);
                                break;
                            case 2:
                                grid.InsertSymbol(secondPlayer.Symbol, 2, 1);
                                break;
                            case 3:
                                grid.InsertSymbol(secondPlayer.Symbol, 2, 2);
                                break;
                            case 4:
                                grid.InsertSymbol(secondPlayer.Symbol, 1, 0);
                                break;
                            case 5:
                                grid.InsertSymbol(secondPlayer.Symbol, 1, 1);
                                break;
                            case 6:
                                grid.InsertSymbol(secondPlayer.Symbol, 1, 2);
                                break;
                            case 7:
                                grid.InsertSymbol(secondPlayer.Symbol, 0, 0);
                                break;
                            case 8:
                                grid.InsertSymbol(secondPlayer.Symbol, 0, 1);
                                break;
                            case 9:
                                grid.InsertSymbol(secondPlayer.Symbol, 0, 2);
                                break;
                            default:
                                Console.WriteLine("ERROR enter a value 1-9");
                                _turnCount = 3;
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not valid char");
                        _turnCount = 3;
                        Console.ReadKey();
                    }
                    if (CheckWinner())
                    {
                        Console.Clear();
                        Console.Write(String.Format("PG 1 [{0}]", player1.Symbol));
                        Console.WriteLine(String.Format(" PG 2 [{0}]\n", player2.Symbol));
                        grid.PrintGrid();
                        Console.WriteLine(String.Format("\n[{0}] Win", secondPlayer.Symbol));
                        firstPlayer.IsWinner = true;
                        Console.ReadKey();
                    }
                    if (grid.FilledMatrix())
                    {
                        Console.WriteLine("Draw!!");
                        Console.ReadKey();

                    }
                    _turnCount--;
                }

                Console.Clear();
            } while (!(firstPlayer.IsWinner || secondPlayer.IsWinner || grid.FilledMatrix()));

            Console.WriteLine("Do you wanna play again?");
            Console.WriteLine("Y - Yes\nN - No");
            Console.Write("Make Your choice: ");
            string? replayChoice = Console.ReadLine();
            if (replayChoice?.ToUpper() == "Y")
            {
                Console.Clear();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
