using TicTacToeLibrary;
using TicTacToeLibrary.Models;

namespace Tic_Tac_Toe;

internal class Program
{
    // Main Method
    static public void Main(String[] args)
    {
        GameLogic gm = new();

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
        bool loadPlayerLoop = true;
        do
        {
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
                loadPlayerLoop = false;
                // SELECT SYMBOL LOOP
                bool selectSymbolLoop = true;
                do
                {
                    Console.WriteLine("Choice Your Symbol");
                    Console.WriteLine("1 - X\n2 - O");
                    string? choiceSymbol= Console.ReadLine();
                    bool choice = gm.SelectSymbol(choiceSymbol,first, second);
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

                Console.Write($"First {first}\nSecond {second}");
                Console.ReadLine();
            }

        } while (loadPlayerLoop);

        Console.WriteLine("OUT ALL CYCLE");
    }
}