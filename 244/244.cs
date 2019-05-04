public class WordDistance
{
    private IDictionary<string, List<int>> _positions = new Dictionary<string, List<int>>();

    public WordDistance(string[] words)
    {
        for (var i = 0; i < words.Length; i++)
        {
            var w = words[i];
            _positions.TryAdd(w, new List<int>());
            _positions[w].Add(i);
        }
    }

    public int Shortest(string word1, string word2) {
        var l1 = _positions[word1];
        var l2 = _positions[word2];

        var i1 = 0;
        var i2 = 0;

        var result = int.MaxValue;
        while (i1 < l1.Count && i2 < l2.Count)
        {
            result = Math.Min(result, Math.Abs(l1[i1] - l2[i2]));
            if (l2[i2] < l1[i1])
            {
                i2++;
            }
            else
            {
                i1++;
            }
        }
        return result;
    }
}

/**
 * Your WordDistance object will be instantiated and called as such:
 * WordDistance obj = new WordDistance(words);
 * int param_1 = obj.Shortest(word1,word2);
 */