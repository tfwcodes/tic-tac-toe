using System;
using System.Collections;
using System.Threading;
using System.Collections.Generic;

var game = new Game();
game.RenderBeginningBoard();
game.GameEngine();



class Game : WinningMessages
{
    // main variables
    public string currentPlayer = "X";
    public string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " };
    public bool GameTie { get; private set; }


    // check if the space is open
    public bool CheckIfOpen(int playerTurn, string currentTurn)
    {
        if (board[playerTurn] == " ")
        {
            board[playerTurn] = currentTurn;
            return true;
        }
        else
        {
            Console.WriteLine("Enter another number (space is not open)");
            return false;

        }
    }

    // render the board with the players decisions
    public void RenderBoard()
    {
        Console.WriteLine($"| {board[0]} | {board[1]} | {board[2]} | \n");
        Console.WriteLine($"| {board[3]} | {board[4]} | {board[5]} | \n");
        Console.WriteLine($"| {board[6]} | {board[7]} | {board[8]} | \n");
    }

    // render the board at the beginning so that the players know the positions
    public void RenderBeginningBoard()
    {
        Console.WriteLine("| 0 | 1 | 2|");
        Console.WriteLine("| 3 | 4 | 5|");
        Console.WriteLine("| 6 | 7 | 8|");
    }

    // main game
    public void GameEngine()
    {
        while (true)
        {
            CheckIfTie();
            Console.Write($"Enter a number from 0-8({currentPlayer} turn): ");
            try
            {
                int numberTurn = Convert.ToInt32(Console.ReadLine());
                if (CheckIfOpen(numberTurn, currentPlayer))
                {
                    RenderBoard();
                    FlipPlayer();
                    CheckRows();
                    CheckColumns();
                    CheckDiagonals();
                }
                else
                {
                    GameEngine();
                }

            }
            catch
            {
                Console.WriteLine("Please enter a number from 0-8\n");
            }

        }
    }


    // check the rows 
    public void CheckRows()
    {

        if (board[0] == "X" && board[1] == "X" && board[2] == "X")
        {
            XWinningMessage();
        }
        else if (board[3] == "X" && board[4] == "X" && board[5] == "X")
        {
            XWinningMessage();
        }
        else if (board[7] == "X" && board[6] == "X" && board[9] == "X")
        {
            XWinningMessage();
        } // done checking the rows for X


        if (board[0] == "0" && board[1] == "0" && board[2] == "0")
        {
            OWinningMessages();
        }
        else if (board[3] == "0" && board[4] == "0" && board[5] == "0")
        {
            OWinningMessages();
        }
        else if (board[6] == "0" && board[7] == "0" && board[8] == "0")
        {
            OWinningMessages();
        } // done checking the rows for 0

    }

    // check the columns
    public void CheckColumns()
    {
        if (board[0] == "X" && board[3] == "X" && board[6] == "X")
        {
            XWinningMessage();
        }
        else if (board[1] == "X" && board[4] == "X" && board[7] == "X")
        {
            XWinningMessage();
        }
        else if (board[2] == "X" && board[5] == "X" && board[8] == "X")
        {
            XWinningMessage();
        } // done checking the columns for X


        if (board[0] == "0" && board[3] == "0" && board[6] == "0")
        {
            OWinningMessages();
        }
        else if (board[1] == "0" && board[4] == "0" && board[7] == "0")
        {
            OWinningMessages();
        }
        else if (board[2] == "0" && board[5] == "0" && board[8] == "0")
        {
            OWinningMessages();
        } // done checking the columns for 0

    }

    // check the diagonals
    public void CheckDiagonals()
    {
        if (board[0] == "X" && board[4] == "X" && board[8] == "X")
        {
            XWinningMessage();
        }
        else if (board[2] == "X" && board[4] == "X" && board[6] == "X")
        {
            XWinningMessage();
        }
        if (board[0] == "0" && board[4] == "0" && board[8] == "0")
        {
            OWinningMessages();
        }
        else if (board[2] == "0" && board[4] == "0" && board[6] == "0")
        {
            OWinningMessages();
        }

    }


    // check if the game is a tie
    public void CheckIfTie()
    {
        var ArrayToList = board.ToList();
        foreach (var element in ArrayToList)
        {
            if (element == "X" || element == "0")
            {
                GameTie = true;
            }
            else
            {
                GameTie = false;
                break;
            }
        }

        if (GameTie)
        {
            Console.WriteLine("The game is a tie");
            Console.WriteLine("Exiting in 10 seconds");
            Thread.Sleep(10000);
            Environment.Exit(0);
        }
    }



    // flip the players turn
    public void FlipPlayer()
    {
        if (currentPlayer == "X")
        {
            currentPlayer = "0";
        }
        else if (currentPlayer == "0")
        {
            currentPlayer = "X";
        }
    }


}


// winning messages
class WinningMessages
{

    // x winning message
    public void XWinningMessage()
    {
        Console.WriteLine("X won");
        Console.WriteLine("Exiting in 10 seconds");
        Thread.Sleep(10000);
        Environment.Exit(0);
    }

    // 0 winning messages
    public void OWinningMessages()
    {
        Console.WriteLine("0 won");
        Console.WriteLine("Exiting in 10 seconds");
        Thread.Sleep(10000);
        Environment.Exit(0);
    }
}