public class Solution
{
    public int[] TwoSum(int[] nums, int target)
    {
        var numbers = new Dictionary<int, int>();
        for (var i = 0; i < nums.Length; i++)
        {
            if (numbers.TryGetValue(target - nums[i], out var idx))
            {
                return new int[] { idx, i };
            }
            numbers[nums[i]] = i;
        }

        throw new ArgumentException("Invalid input");
    }
}