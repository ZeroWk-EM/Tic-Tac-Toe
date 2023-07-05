
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

        // TODO: FIX ERROR

        // V1
        /*       public bool IterativeCheckWinner(Player pg)
               {
                   int count = 0;
                   Symbol?[,] matrix = grid.GetGrid();

                   for (int i = 0; i < MaxGridSize; i++)
                   {

                       for (int j = 0; j < MaxGridSize; j++)
                       {
                           Console.WriteLine($"Pos [{i},{j}] - [{matrix[i, j] == pg.Symbol}]");
                           // ERROR - THIS DON'T CHECK IF IS IN THE SAME ROW/COLUMN 
                           if (matrix[i, j] == pg.Symbol)
                           {
                               count++;
                           }
                       }
                   }
                   return count == 3;
               }*/

        //V2
        /*public bool IterativeCheckWinner(Player pg)
        {
            int count = 0;
            Symbol?[,] matrix = grid.GetGrid();

            bool foundRow=false;
            bool foundColumn = false;
            for (int i = 0; i < MaxGridSize; i++)
            {
                for (int j = 0; j < MaxGridSize; j++)
                {
                    // COLUMN
                    if (!foundRow && matrix[0, j] == pg.Symbol)
                    {
                        Console.WriteLine("\nControllo colonne");
                        Console.WriteLine($"Pos [{i},{j}]");
                        Console.WriteLine($"Count {count}");
                        count++;
                        foundColumn = true;
                    }
                    // ROW
                    if (!foundColumn && matrix[i, 0] == pg.Symbol)
                    {
                        Console.WriteLine("\nControllo righe");
                        Console.WriteLine($"Pos [{i},{j}]");
                        Console.WriteLine($"Count {count}");
                        count++;
                        foundRow = true;
                    }
                }
            }
            return count == 3;
        }*/

        //V3
        public bool IterativeCheckWinner(Player pg)
        {
            int count = 0;
            Symbol?[,] matrix = grid.GetGrid();

            for (int i = 0; i < MaxGridSize; i++)
            {
                for (int j = 0; j < MaxGridSize; j++)
                {
                    Console.WriteLine($"COLUMN - {matrix[0, j] == pg.Symbol}");
                    // COLUMN
                    if (matrix[0, j] == pg.Symbol)
                    {
                        Console.WriteLine("\nControllo colonne");
                        Console.WriteLine($"Pos [{i},{j}]");
                        Console.WriteLine($"Count {count}");
                        count++;
                    }
               
                    // ROW
                    Console.WriteLine($"ROW - {matrix[i, 0] == pg.Symbol}");
                    if (matrix[i, 0] == pg.Symbol)
                    {
                        Console.WriteLine("\nControllo righe");
                        Console.WriteLine($"Pos [{i},{j}]");
                        Console.WriteLine($"Count {count}");
                        count++;
                    }
             
                }
            }
            return count == MaxGridSize;
        }
    }
}
