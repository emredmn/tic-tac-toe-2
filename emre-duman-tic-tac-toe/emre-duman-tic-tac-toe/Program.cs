
void DrawGameBoard(string[] board)
{
    int cellIndex = 0;
    for (int i = 0; i < 3; i++)
    {
        for (int j = 1; j <= 11; j++)
        {
            if (j % 4 == 0)
            {
                Console.Write("|");
            }
            else if (j % 2 == 0)
            {
                if (board[cellIndex] == "X" || board[cellIndex] == "O")
                {
                    Console.Write(board[cellIndex]);
                }
                else
                {
                    Console.Write(" ");
                }
                cellIndex++;
            }
            else
            {
                Console.Write(" ");
            }
        }
        if (i < 2)
        {
            Console.WriteLine();
            Console.WriteLine("---+---+---");
        }
    }
    Console.WriteLine();
}

bool checkWinner(string[] board, string player)
{
    for (int i = 0; i < 3; i++)
    {
        if (board[i * 3] == player && board[i * 3 + 1] == player && board[i * 3 + 2] == player
            || board[i] == player && board[i + 3] == player && board[i + 6] == player)
            return true;
    }
    if (board[0] == player && board[4] == player && board[8] == player || board[2] == player && board[4] == player && board[6] == player)
        return true;
    return false;
}


do
{
    Console.WriteLine("1. New game");
    Console.WriteLine("2. About the author");
    Console.WriteLine("3. Exit");
    Console.Write("> ");
    string menu = Console.ReadLine();
    Console.WriteLine();
    if (menu == "1")
    {
        int moveCount = 0;
        string[] board = new string[9];
        DrawGameBoard(board);

        do
        {
            if (moveCount != 9)
            {
                string currentPlayer;
                if (moveCount % 2 == 0)
                {
                    currentPlayer = "X";
                }
                else
                {
                    currentPlayer = "O";
                }
                Console.Write($"{currentPlayer}'s move > ");

                int userMove = int.Parse(Console.ReadLine()) - 1;
                Console.WriteLine();
                if (board[userMove] == "X" || board[userMove] == "O" || userMove < 0 || board.Length <= userMove)
                {
                    Console.WriteLine("Illegal move! Try again.");
                    continue;
                }

                board[userMove] = currentPlayer;
                moveCount++;
                DrawGameBoard(board);

                if (checkWinner(board, currentPlayer))
                {
                    Console.WriteLine($"\n{currentPlayer} won!");
                    Console.Write("[Press Enter to return to main menu...]");
                    Console.ReadLine();
                    Console.WriteLine();
                    break;
                }
            }
            else
            {
                moveCount++;
                Console.WriteLine("Game over!");
            }
        } while (moveCount < 10);
    }
    else if (menu == "2")
    {
        Console.WriteLine("Made by Emre Duman");
        Console.Write("[Press Enter to return to main menu...]");
        Console.ReadLine();
        Console.WriteLine();
    }
    else if (menu == "3")
    {
        Console.WriteLine("Are you sure you want to quit? [y/n]");
        Console.Write("> ");
        string temp = Console.ReadLine();
        if (temp.ToLower() == "y") break;
        Console.WriteLine();
    }
    else
    {
        Console.WriteLine();
    }
} while (true);

