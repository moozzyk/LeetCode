public class Solution
{
    public int[] NumMovesStones(int x, int y, int z)
    {
        var a = Math.Min(x, Math.Min(y, z));
        var c = Math.Max(x, Math.Max(y, z));
        var b = x;
        if ((a == x && c == y) || (a == y && c == x))
        {
            b = z;
        }
        if ((a == x && c == z) || (a == z && c == x))
        {
            b = y;
        }

        var max = c - a - 2;
        var min = 2;

        if (a + 1 == b && b + 1 == c)
        {
            min = 0;
        }
        else if (a + 1 == b - 1 || b + 1 == c - 1 || a + 1 == b || b + 1 == c)
        {
            min = 1;
        }

        return new int[] { min, max };
    }
}