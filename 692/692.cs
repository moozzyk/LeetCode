public class Solution
{
    public IList<string> TopKFrequent(string[] words, int k)
    {
        return words.GroupBy(w => w, (word, group) => new { Word = word, Count = group.Count() })
                    .OrderByDescending(item => item.Count)
                    .ThenBy(item => item.Word)
                    .Take(k)
                    .Select(item => item.Word)
                    .ToList();
    }
}
