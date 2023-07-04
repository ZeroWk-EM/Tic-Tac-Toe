using TicTacToeLibrary;
using TicTacToeLibrary.Enum;

namespace Tic_Tac_Toe;

internal class Program
{
    public static void PrintGameGrid(Symbol?[,] grid)
    {

        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < 3; j++)
            {
                Console.Write(String.Format("[{0}]", grid[i, j]));
            }
            Console.WriteLine();
        }
    }


    // Main Method
    static public void Main()
    {
        GameLogic gm = new();
        int turn = 0;

        // SELECT GAMEMODE LOOP
        bool gameModeLoop = true;
        do
        {
            Console.WriteLine("Do yoy wanna play");
            Console.WriteLine("1 - Player 1 VS Player 2\n2 - Player 1 VS CPU");
            Console.Write("\nInsert Your choice: ");
            string? choiceGameMode = Console.ReadLine();
            bool choice = gm.SelectGameMode(choiceGameMode);
            if (choice == true)
            {
                Console.Write("Not valid input, press any key and try again...");
                Console.ReadKey();
            }
            else
            {
                gameModeLoop = false;
            }
            Console.Clear();
        } while (gameModeLoop);

        // SELECT STARTED PLAYER LOOP 
        bool preMatch = true;
        do
        {
            Console.Clear();
            Console.WriteLine("Do you wanna start");
            Console.WriteLine("1 - Player 1\n2 - Player 2");
            Console.Write("\nInsert choice: ");
            string? choiceLoopPlayer = Console.ReadLine();
            var (condition, first, second) = gm.LoadPlayer(choiceLoopPlayer);
            if (condition == true)
            {
                Console.Write("Not valid input, press any key and try again...");
                Console.ReadKey();
            }
            else
            {
                preMatch = false;
                // SELECT SYMBOL LOOP
                bool selectSymbolLoop = true;
                do
                {
                    Console.Clear();
                    Console.WriteLine("Choice Your Symbol");
                    Console.WriteLine("1 - X\n2 - O");
                    string? choiceSymbol = Console.ReadLine();
                    bool choice = GameLogic.SelectSymbol(choiceSymbol, first, second);
                    if (choice == true)
                    {
                        Console.Write("Not valid input, press any key and try again...");
                        Console.ReadKey();
                    }
                    else
                    {
                        selectSymbolLoop = false;
                    }
                } while (selectSymbolLoop);
            }
            // MATCH
            bool firstTurn = true;
            do
            {

                Console.WriteLine($"\nFirst [{first!.Symbol}]\nSecond [{second!.Symbol}]");
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
                            if (firstTurn)
                            {
                                gm.Grid.InsertSymbol(first.Symbol, resultRow, resultColumn);
                                PrintGameGrid(gm.Grid.GetGrid());
                                if (gm.CheckWinner(first))
                                {
                                    Console.WriteLine($"WIN {first.Symbol}");
                                    first.IsWinner = true;
                                }
                                firstTurn = false;
                                turn++;
                                Console.WriteLine($"\nDEBUG - Turn counter [{turn}]");
                            }
                            else
                            {
                                gm.Grid.InsertSymbol(second.Symbol, resultRow, resultColumn);
                                PrintGameGrid(gm.Grid.GetGrid());
                                if (gm.CheckWinner(second))
                                {
                                    Console.WriteLine($"WIN {second.Symbol}");
                                    second.IsWinner = true;
                                }
                                firstTurn = true;
                                turn++;
                                Console.WriteLine($"\nDEBUG - Turn counter [{turn}]");

                            }

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine($"\nDEBUG - Turn counter into catch [{turn}]");
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            } while (!(first.IsWinner || second.IsWinner) && turn < 9);
            if (turn == 9)
            {
                Console.WriteLine("Draw!!");
            }
        } while (preMatch);

        Console.WriteLine("DEBUG - OUT ALL CYCLE");
    }
}