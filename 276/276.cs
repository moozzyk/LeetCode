public class Solution
{
    public int NumWays(int n, int k)
    {
        if (n == 0) return 0;
        if (n == 1) return k;

        var p1 = k;
        var p2 = k * k;

        for (var i = 2; i < n; i++)
        {
            var tmp = (k - 1) * (p1 + p2);
            p1 = p2;
            p2 = tmp;
        }

        return p2;
    }
}