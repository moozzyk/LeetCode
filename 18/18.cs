public class Solution
{
    public IList<IList<int>> FourSum(int[] nums, int target)
    {
        var result = new List<IList<int>>();

        Array.Sort(nums);
        for (var i = 0; i < nums.Length; i++)
        {
            if (i > 0 && nums[i] == nums[i - 1])
            {
                continue;
            }

            for (var j = i + 1; j < nums.Length; j++)
            {
                if (j > i + 1 && nums[j] == nums[j - 1])
                {
                    continue;
                }

                TwoSum(nums, i, j, target - nums[i] - nums[j], result);
            }
        }

        return result;
    }

    private void TwoSum(int[] nums, int i, int j, int target, IList<IList<int>> result)
    {
        var left = j + 1;
        var right = nums.Length - 1;
        while (left < right)
        {
            if (nums[left] + nums[right] > target)
            {
                right--;
            }
            else if (nums[left] + nums[right] < target)
            {
                left++;
            }
            else
            {
                result.Add(new List<int>{nums[i], nums[j], nums[left], nums[right]});
                do
                {
                    left++;
                }
                while (left <= right && nums[left] == nums[left - 1]);

                do
                {
                    right--;
                }
                while (left <= right && nums[right] == nums[right + 1]);
            }
        }
    }
}