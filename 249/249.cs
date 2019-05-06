public class Solution
{
    public IList<IList<string>> GroupStrings(string[] strings)
    {
        var groups = new Dictionary<string, IList<string>>();
        var sb = new StringBuilder();
        foreach (var s in strings)
        {
            var diff = s[0] - 'a';
            foreach (var c in s)
            {
                char x = (char)(c - diff);
                if (x < 'a') x += (char)26;

                sb.Append(x);
            }

            var hash = sb.ToString();
            if (groups.TryGetValue(hash, out var group))
            {
                group.Add(s);
            }
            else
            {
                groups[hash] = new List<string>{s};
            }

            sb.Length = 0;
        }

        return groups.Values.ToList();
    }
}