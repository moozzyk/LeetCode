public class TicTacToe
{
    private int[,] _board;

    /** Initialize your data structure here. */
    public TicTacToe(int n)
    {
        _board = new int[n, n];
    }

    /** Player {player} makes a move at ({row}, {col}).
        @param row The row of the board.
        @param col The column of the board.
        @param player The player, can be either 1 or 2.
        @return The current winning condition, can be either:
                0: No one wins.
                1: Player 1 wins.
                2: Player 2 wins. */
    public int Move(int row, int col, int player)
    {
        _board[row, col] = player;

        if (CheckRow(row, player) || CheckCol(col, player) || CheckDiag(player))
        {
            return player;
        }

        return 0;

    }

    private bool CheckRow(int row, int player)
    {
        for (var col = 0; col < _board.GetLength(1); col++)
        {
            if (_board[row, col] != player)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckCol(int col, int player)
    {
        for (var row = 0; row < _board.GetLength(0); row++)
        {
            if (_board[row, col] != player)
            {
                return false;
            }
        }

        return true;
    }

    private bool CheckDiag(int player)
    {
        var diagLeft = true;
        var diagRight = true;
        for (var i = 0; i < _board.GetLength(0); i++)
        {
            if (_board[i, i] != player)
            {
                diagLeft = false;
            }

            if (_board[i, _board.GetLength(1) - i - 1] != player)
            {
                diagRight = false;
            }
        }

        return diagLeft || diagRight;
    }
}

/**
 * Your TicTacToe object will be instantiated and called as such:
 * TicTacToe obj = new TicTacToe(n);
 * int param_1 = obj.Move(row,col,player);
 */