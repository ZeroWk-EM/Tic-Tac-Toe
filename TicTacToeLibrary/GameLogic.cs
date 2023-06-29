
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
        private int _globalTurn = 1;


        Grid grid = new Grid();

        // For select the symbol
        private static void SelectSymbol(Player pg1, Player pg2)
        {
            bool loopPG = true;
            do
            {
                Console.Clear();
                Console.WriteLine("Choice Your Symbol");
                Console.WriteLine("1 - X\n2 - O");
                string? choicePG = Console.ReadLine();
                if (int.TryParse(choicePG, out int resultPG))
                {
                    switch (resultPG)
                    {
                        case 1:
                            pg1.Symbol = Symbol.X;
                            pg2.Symbol = Symbol.O;
                            loopPG = false;
                            break;
                        case 2:
                            pg1.Symbol = Symbol.O;
                            pg2.Symbol = Symbol.X;
                            loopPG = false;
                            break;
                        default:
                            Console.WriteLine("Not Valid Choice");
                            Console.ReadKey();
                            break;
                    }
                }
            } while (loopPG);
        }

        // For choice the game mode
        private void SelectGameMode()
        {
            bool loop = true;
            do
            {
                Console.WriteLine("Do yoy wanna play");
                Console.WriteLine("1 - Player 1 VS Player 2\n2 - Player 1 VS CPU");
                Console.Write("\nInsert Your choice: ");
                string? choice = Console.ReadLine();
                if (int.TryParse(choice, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            _gameMode = "P1 vs P2";
                            loop = false;
                            Console.Clear();
                            break;
                        case 2:
                            _gameMode = "P1 vs CPU";
                            loop = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Not Valid Choice...Try again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                }
            } while (loop);
        }

        // For set the turnOrder and assign symbol to player
        private void LoadPlayer()
        {
            bool loop = true;
            do
            {
                Console.WriteLine("Do you wanna start");
                Console.WriteLine("1 - Player 1\n2 - Player 2");
                Console.Write("\nInsert choice: ");
                string? choice = Console.ReadLine();
                if (int.TryParse(choice, out int result))
                {
                    switch (result)
                    {
                        case 1:
                            _turnOrder[0] = player1;
                            _turnOrder[1] = player2;
                            SelectSymbol(player1, player2);
                            loop = false;
                            Console.Clear();
                            break;
                        case 2:

                            _turnOrder[0] = player2;
                            _turnOrder[1] = player1;
                            SelectSymbol(player2, player1);
                            loop = false;
                            Console.Clear();
                            break;
                        default:
                            Console.WriteLine("Not Valid Choice...Try again");
                            Console.ReadKey();
                            Console.Clear();
                            break;
                    }

                }
            } while (loop);
        }

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

        public static void StartGame()
        {
            var gm = new GameLogic();
            gm.SelectGameMode();
            gm.LoadPlayer();
            Player firstPlayer = gm._turnOrder[0];
            Player secondPlayer = gm._turnOrder[1];

            do
            {

                Console.Write(String.Format("PG 1 [{0}]", gm.player1.Symbol));
                Console.WriteLine(String.Format(" PG 2 [{0}]", gm.player2.Symbol));
                Console.WriteLine(String.Format("Selected Game Mode [{0}]\n", gm._gameMode));
                gm.grid.PrintGrid();
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

                if (gm._turnCount == 1)
                {
                    Console.Write("Player Do wanna put the symbol: ");
                    string? choice = Console.ReadLine();
                    if (int.TryParse(choice, out int result))
                    {

                        switch (result)
                        {
                            case 1:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 2, 0);
                                break;
                            case 2:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 2, 1);
                                break;
                            case 3:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 2, 2);
                                break;
                            case 4:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 1, 0);
                                break;
                            case 5:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 1, 1);
                                break;
                            case 6:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 1, 2);
                                break;
                            case 7:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 0, 0);
                                break;
                            case 8:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 0, 1);
                                break;
                            case 9:
                                gm.grid.InsertSymbol(firstPlayer.Symbol, 0, 2);
                                break;
                            default:
                                Console.WriteLine("ERROR enter a value 1-9");
                                gm._turnCount = 0;
                                Console.ReadKey();
                                break;
                        }

                    }
                    else
                    {
                        Console.WriteLine("Not valid char");
                        gm._turnCount = 0;
                        Console.ReadKey();
                    }
                    if (gm.CheckWinner())
                    {
                        Console.WriteLine(String.Format("[{0}] Win", firstPlayer.Symbol));
                        firstPlayer.IsWinner = true;
                        Console.ReadKey();
                    }
                    if (gm.grid.FilledMatrix())
                    {
                        Console.WriteLine("Draw!!");
                        Console.ReadKey();
                    }
                    gm._turnCount++;
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
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 2, 0);
                                break;
                            case 2:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 2, 1);
                                break;
                            case 3:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 2, 2);
                                break;
                            case 4:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 1, 0);
                                break;
                            case 5:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 1, 1);
                                break;
                            case 6:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 1, 2);
                                break;
                            case 7:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 0, 0);
                                break;
                            case 8:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 0, 1);
                                break;
                            case 9:
                                gm.grid.InsertSymbol(secondPlayer.Symbol, 0, 2);
                                break;
                            default:
                                Console.WriteLine("ERROR enter a value 1-9");
                                gm._turnCount = 3;
                                Console.ReadKey();
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Not valid char");
                        gm._turnCount = 3;
                        Console.ReadKey();
                    }
                    if (gm.CheckWinner())
                    {
                        Console.WriteLine(String.Format("[{0}] Win", secondPlayer.Symbol));
                        firstPlayer.IsWinner = true;
                        Console.ReadKey();
                    }
                    if (gm.grid.FilledMatrix())
                    {
                        Console.WriteLine("Draw!!");
                        Console.ReadKey();

                    }
                    gm._turnCount--;
                }

                Console.Clear();
            } while (!(firstPlayer.IsWinner || secondPlayer.IsWinner || gm.grid.FilledMatrix()));
            Console.WriteLine("Do you wanna play again?");
            Console.WriteLine("Y - Yes\nN - No");
            Console.Write("Make Your choice: ");
            string? replayChoice = Console.ReadLine();
            if (replayChoice?.ToUpper() == "Y")
            {
                Console.Clear();
                StartGame();
            }
            else
            {
                Environment.Exit(0);
            }
        }
    }
}
