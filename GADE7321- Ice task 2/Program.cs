using System;

class Program
{
    static void Main()
    {
        // Create a new game instance
        TicTacToeGame game = new TicTacToeGame();

        // Start the game
        game.Start();
    }
}

class TicTacToeGame
{
    private char[,] board;
    private const int BoardSize = 3;

    public void Start()
    {
        // Initialize the game board
        board = new char[BoardSize, BoardSize];
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                board[i, j] = ' ';
            }
        }

        // Game loop
        while (true)
        {
            // Display the current board
            DisplayBoard();

            // Player's move
            Console.WriteLine("Enter row and column (1-3) to place your mark (X):");
            int row = int.Parse(Console.ReadLine()) - 1;
            int col = int.Parse(Console.ReadLine()) - 1;
            if (board[row, col] != ' ')
            {
                Console.WriteLine("Invalid move. Try again.");
                continue;
            }
            board[row, col] = 'X';

            // Check for player win or draw
            if (CheckWin('X'))
            {
                DisplayBoard();
                Console.WriteLine("You win!");
                break;
            }
            else if (CheckDraw())
            {
                DisplayBoard();
                Console.WriteLine("It's a draw!");
                break;
            }

            // AI's move (minimax algorithm)
            
        }
    }

    private void DisplayBoard()
    {
        Console.WriteLine("  1 2 3");
        for (int i = 0; i < BoardSize; i++)
        {
            Console.Write(i + 1 + " ");
            for (int j = 0; j < BoardSize; j++)
            {
                Console.Write(board[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    private bool CheckWin(char mark)
    {
        for (int i = 0; i < BoardSize; i++)
        {
            if (board[i, 0] == mark && board[i, 1] == mark && board[i, 2] == mark)
            {
                return true;
            }
        }

        // Check columns
        for (int j = 0; j < BoardSize; j++)
        {
            if (board[0, j] == mark && board[1, j] == mark && board[2, j] == mark)
            {
                return true;
            }
        }
        // Check diagonals
        if ((board[0, 0] == mark && board[1, 1] == mark && board[2, 2] == mark) ||
            (board[0, 2] == mark && board[1, 1] == mark && board[2, 0] == mark))
        {
            return true;
        }
        return false;
    }

    private bool CheckDraw()
    {
        // Check if all cells are filled
        for (int i = 0; i < BoardSize; i++)
        {
            for (int j = 0; j < BoardSize; j++)
            {
                if (board[i, j] == ' ')
                {
                    // There's an empty cell, game is not drawn yet
                    return false;
                }
            }
        }
        // All cells are filled, and no one has won, it's a draw

        return false;
    }
}

//https://github.com/Nkwemakaleng/GADE7321--Ice-task-2