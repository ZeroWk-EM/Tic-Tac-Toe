﻿using TicTacToeLibrary;
using TicTacToeLibrary.Enum;
using TicTacToeLibrary.Models;

namespace Tic_Tac_Toe;

internal class Program
{
    public static void PrintGameGrid(Symbol?[,] matrix)
    {
        const int MaxGridSize = Grid.MaxGridSize;
        for (int i = 0; i < MaxGridSize; i++)
        {
            for (int j = 0; j < MaxGridSize; j++)
            {
                Console.Write(String.Format("[{0}]", matrix[i, j]));
            }
            Console.WriteLine();
        }
    }

    // Main Method
    static public void Main()
    {
        GameLogic gm = new();
        int turn = 0;
        int maxturn = Grid.MaxGridSize * Grid.MaxGridSize;

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
                                if (gm.IterativeCheckWinner(first))
                                {
                                    Console.WriteLine($"WIN {first.Symbol}");
                                    first.IsWinner = true;
                                }
                                firstTurn = false;
                                turn++;
                            }
                            else
                            {
                                gm.Grid.InsertSymbol(second.Symbol, resultRow, resultColumn);
                                PrintGameGrid(gm.Grid.GetGrid());
                                if (gm.IterativeCheckWinner(second))
                                {
                                    Console.WriteLine($"WIN {second.Symbol}");
                                    second.IsWinner = true;
                                }
                                firstTurn = true;
                                turn++;
                            }
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
            } while (!(first.IsWinner || second.IsWinner) && turn < maxturn);
            if (turn == maxturn)
            {
                Console.Clear();
                Console.WriteLine("Draw!!");
            }
        } while (preMatch);
    }
}