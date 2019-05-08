public class Solution
{
    public int MaxSubArrayLen(int[] nums, int k)
    {
        var dict = new Dictionary<int, int>();
        dict[0] = -1;

        var result = 0;
        var sum = 0;
        for (var i = 0; i < nums.Length; i++)
        {
            sum += nums[i];
            dict.TryAdd(sum, i);
            if (dict.ContainsKey(sum - k))
            {
                result = Math.Max(result, i - dict[sum - k]);
            }
        }

        return result;
    }
}
