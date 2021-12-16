using System;

ScoreBoard game = new ScoreBoard();

char player1 = 'X';
char player2 = 'O';
int turnCount = 1;
char currentPlayer;
int choice;

do
{
    if (turnCount % 2 == 0) currentPlayer = player2;
    else currentPlayer = player1;

    Console.Clear();
    //game.showScoreBoardMap();
    Console.WriteLine($"It is {currentPlayer}'s turn.");
    game.showScoreBoard();
    Console.Write("What square do you want to play in? ");
    choice = Convert.ToInt32(Console.ReadLine());
    game.updateScoreBoard(currentPlayer, choice);
    if (game.isValidMove()) turnCount++;
    else Console.WriteLine("Invalid move. Try again.");

} while (!game.getPlayerWon(currentPlayer) && turnCount <= 9);

Console.Clear();
game.showScoreBoard();
if (!game.getPlayerWon(currentPlayer)) Console.WriteLine("Draw. No winner.");
else Console.WriteLine($"Player {currentPlayer} WON!");



public class ScoreBoard
{
    private char _TL, _TC, _TR; // top row -left, -center, -right
    private char _ML, _MC, _MR; // middle row -left, -center, -right
    private char _BL, _BC, _BR; // bottom row -left, -center, -right
    private bool IsValidMove { get; set; }


    public ScoreBoard()
    {
        _TL = _TC = _TR = ' ';
        _ML = _MC = _MR = ' ';
        _BL = _BC = _BR = ' ';
    }

    ~ScoreBoard() { }


    public void showScoreBoard()
    {
        Console.WriteLine($" {_TL} | {_TC} | {_TR}\n" +
        "---+---+---\n" +
        $" {_ML} | {_MC} | {_MR}\n" +
        "---+---+---\n" +
        $" {_BL} | {_BC} | {_BR}");
    }

    public void showScoreBoardMap()
    {
        Console.WriteLine("*** Map ***");
        Console.WriteLine($" 7 | 8 | 9\n" +
        "---+---+---\n" +
        $" 4 | 5 | 6\n" +
        "---+---+---\n" +
        $" 1 | 2 | 3");
        Console.WriteLine("***********");
    }

    public bool getPlayerWon(char player)
    {
        bool playerWon = false;
        // check rows
        if (
            (_TL == player && _TC == player && _TR == player) ||
            (_ML == player && _MC == player && _MR == player) ||
            (_BL == player && _BC == player && _BR == player)
            ) playerWon = true;
        // check columns
        else if (
            (_TL == player && _ML == player && _BL == player) ||
            (_TC == player && _MC == player && _BC == player) ||
            (_TC == player && _MC == player && _BC == player)
            ) playerWon = true;
        // check diag
        else if (
            (_TL == player && _MC == player && _BR == player) ||
            (_BL == player && _MC == player && _TR == player)
            ) playerWon = true;

        return playerWon;
    }

    public void updateScoreBoard(char player, int location)
    {
        IsValidMove = true;
        switch (location)
        {
            case 7:
                if (_TL == ' ') _TL = player;
                else IsValidMove = false;
                break;
            case 8:
                if (_TC == ' ') _TC = player;
                else IsValidMove = false;
                break;
            case 9:
                if (_TR == ' ') _TR = player;
                else IsValidMove = false;
                break;
            case 4:
                if (_ML == ' ') _ML = player;
                else IsValidMove = false;
                break;
            case 5:
                if (_MC == ' ') _MC = player;
                else IsValidMove = false;
                break;
            case 6:
                if (_MR == ' ') _MR = player;
                else IsValidMove = false;
                break;
            case 1:
                if (_BL == ' ') _BL = player;
                else IsValidMove = false;
                break;
            case 2:
                if (_BC == ' ') _BC = player;
                else IsValidMove = false;
                break;
            case 3:
                if (_BR == ' ') _BR = player;
                else IsValidMove = false;
                break;
            default:
                Console.WriteLine("ERROR: Invalid input.");
                break;
        };
    }

    public bool isValidMove()
    {
        return IsValidMove;
    }
}


