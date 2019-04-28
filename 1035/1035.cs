public class Solution {
    public int MaxUncrossedLines(int[] A, int[] B)
    {
        var dp = new int[A.Length, B.Length];

        for (var r = 0; r < A.Length; r++)
        {
            for (var c = 0; c < B.Length; c++)
            {
                var up = r == 0 ? 0 : dp[r - 1, c];
                var left = c == 0 ? 0 : dp[r, c - 1];
                var res = Math.Max(up, left);
                if (A[r] == B[c])
                {
                    var diag = (r == 0 || c == 0) ? 0 : dp[r - 1, c - 1];
                    res = Math.Max(res, diag + 1);
                }
                dp[r, c] = res;
            }
        }

        return dp[A.Length - 1, B.Length - 1];
    }
}
