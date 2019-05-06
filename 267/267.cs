public class Solution
{
    public IList<string> GeneratePalindromes(string s)
    {
        var freqs = new Dictionary<char, int>();
        foreach (var c in s)
        {
            if (!freqs.TryAdd(c, 1))
            {
                freqs[c]++;
            }
        }

        var middle = string.Empty;
        var chars = new List<char>();
        foreach (var kvp in freqs)
        {
            if ((kvp.Value % 2) == 1)
            {
                if (middle != string.Empty)
                {
                    return new List<string>();
                }

                middle = kvp.Key.ToString();
            }

            for (var i = 0; i < kvp.Value / 2; i++)
            {
                chars.Add(kvp.Key);
            }
        }


        var result = new HashSet<string>();
        GeneratePalindromes(chars, middle, 0, result);
        return result.ToList();
    }

    private static void GeneratePalindromes(IList<char> chars, string mid, int start, ISet<string> result)
    {
        if (start == chars.Count)
        {
            var tmp = chars.ToArray();
            var front = new string(tmp);
            Array.Reverse(tmp);
            var end = new string(tmp);
            result.Add($"{front}{mid}{end}");
            return;
        }

        bool sameSeen = false;
        for (var i = start; i < chars.Count; i++)
        {
            if (i == start || chars[i] != chars[i - 1])
            {
                Swap(chars, start, i);
                GeneratePalindromes(chars, mid, start + 1, result);
                Swap(chars, i, start);
            }
        }
    }

    private static void Swap(IList<char> chars, int p1, int p2)
    {
        var tmp = chars[p1];
        chars[p1] = chars[p2];
        chars[p2] = tmp;
    }
}
