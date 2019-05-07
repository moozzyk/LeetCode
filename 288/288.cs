public class ValidWordAbbr
{
    private Dictionary<string, HashSet<string>> _abbreviations = new Dictionary<string, HashSet<string>>();

    public ValidWordAbbr(string[] dictionary)
    {
        foreach (var s in dictionary)
        {
            var abbr = Abbreviate(s);
            _abbreviations.TryAdd(abbr, new HashSet<string>());
            _abbreviations[abbr].Add(s);
        }
    }

    public bool IsUnique(string word) {
        var abbr = Abbreviate(word);
        if (!_abbreviations.TryGetValue(abbr, out var words))
        {
            return true;
        }

        return words.Count == 1 && words.Contains(word);
    }

    private string Abbreviate(string s)
    {
        if (s.Length <= 2)
        {
            return s;
        }

        return $"{s[0]}{s.Length - 2}{s[s.Length - 1]}";
    }
}

/**
 * Your ValidWordAbbr object will be instantiated and called as such:
 * ValidWordAbbr obj = new ValidWordAbbr(dictionary);
 * bool param_1 = obj.IsUnique(word);
 */