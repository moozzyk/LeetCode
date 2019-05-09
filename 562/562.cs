public class Solution
{
    private struct Memo
    {
        public int Rows;
        public int Cols;
        public int Diag;
        public int AntiDiag;
    }

    public int LongestLine(int[][] M)
    {
        if (M.Length == 0)
        {
            return 0;
        }

        var dp = new Memo[M.Length, M[0].Length];

        var result = 0;
        for (var row = 0; row < M.Length; row++)
        {
            for (var col = 0; col < M[0].Length; col++)
            {
                if (M[row][col] == 1)
                {
                    dp[row, col].Rows = dp[row, Math.Max(0, col - 1)].Rows + 1;
                    dp[row, col].Cols = dp[Math.Max(0, row - 1), col].Cols + 1;
                    dp[row, col].Diag = ((row > 0 && col > 0) ? dp[row- 1, col - 1].Diag : 0) + 1;
                    dp[row, col].AntiDiag = ((row > 0 && col < M[0].Length - 1) ? dp[row - 1, col + 1].AntiDiag : 0) + 1;

                    result = Math.Max(result, dp[row, col].Rows);
                    result = Math.Max(result, dp[row, col].Cols);
                    result = Math.Max(result, dp[row, col].Diag);
                    result = Math.Max(result, dp[row, col].AntiDiag);
                }
            }
        }

        return result;
    }
}
