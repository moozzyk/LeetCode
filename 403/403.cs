public class Solution
{
    public bool CanCross(int[] stones)
    {
        return CanCross(0, 0, stones.Last(), new HashSet<int>(stones), new Dictionary<int, bool>());
    }

    private bool CanCross(int position, int jump, int target, HashSet<int> stones, IDictionary<int, bool> dp)
    {
        if (!stones.Contains(position))
        {
            return false;
        }

        if (position == target)
        {
            return true;
        }

        var key = jump * 2000 + position;
        if (dp.TryGetValue(key, out var result))
        {
            return result;
        }

        result = CanCross(position + jump, jump + 1, target, stones, dp);
        result = result || (jump > 0) && CanCross(position + jump, jump, target, stones, dp);
        result = result || (jump > 1) && CanCross(position + jump, jump - 1, target, stones, dp);

        dp[key] = result;

        return result;
    }
}