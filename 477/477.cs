public class Solution {
    public int TotalHammingDistance(int[] nums)
    {
        var result = 0;

        var mask = 1;
        while (mask != 0)
        {
            var ones = 0;
            for (var i = 0; i < nums.Length; i++)
            {
                if ((nums[i] & mask) != 0)
                {
                    ones++;
                }
            }

            result += ones * (nums.Length - ones);
            mask <<= 1;
        }

        return result;
    }
}

