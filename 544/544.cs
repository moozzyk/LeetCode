public class Solution
{
    public string FindContestMatch(int n)
    {
        var l = Enumerable.Range(1, n).Select(i => new Item {Singleton = i}).ToList();
        var result = Recurse(l);
        return result[0].ToString();
    }

    private static IList<Item> Recurse(IList<Item> l)
    {
        if (l.Count == 1)
        {
            return l;
        }

        var newList = new List<Item>();
        for (var i = 0; i < l.Count / 2; i++)
        {
            newList.Add(new Item { Nested = new List<Item> { l[i], l[l.Count - 1 - i]}});
        }

        return Recurse(newList);
    }

    private class Item
    {
        public List<Item> Nested { get; set; }
        public int Singleton { get; set; }

        public override string ToString()
        {
            return "(" + string.Join(",", Nested.Select(i => Nested[0].Nested != null ? i.ToString() : i.Singleton.ToString()))  + ")";
        }
    }
}