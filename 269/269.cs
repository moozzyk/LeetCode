public class Solution
{
    public string AlienOrder(string[] words)
    {
        var graph = new Dictionary<char, HashSet<char>>();

        foreach (var w in words)
        {
            foreach (var c in w)
            {
                graph.TryAdd(c, new HashSet<char>());
            }
        }

        for (var i = 0; i < words.Length - 1; i++)
        {
            for (var k = 0; k < Math.Min(words[i].Length, words[i+1].Length); k++)
            {
                if (words[i][k] != words[i+1][k])
                {
                    graph[words[i][k]].Add(words[i+1][k]);
                    break;
                }
            }
        }

        var indegree = new int[26];
        foreach (var kvp in graph)
        {
            foreach (var c in kvp.Value)
            {
                indegree[c - 'a']++;
            }
        }

        var result = new StringBuilder();
        var visited = new HashSet<char>();
        foreach (var n in graph.Keys.Where(v => indegree[v - 'a'] == 0).ToArray())
        {
            if (!TopologicalSort(n, graph, indegree, result, visited))
            {
                return "";
            }
        }

        return result.Length != graph.Count ? "" : result.ToString();
    }

    private bool TopologicalSort(char node, IDictionary<char, HashSet<char>> graph, int[] indegree, StringBuilder result, HashSet<char> visited)
    {
        if (visited.Contains(node))
        {
            return false;
        }

        result.Append(node);
        visited.Add(node);

        if (!graph.ContainsKey(node))
        {
            return true;
        }

        foreach (var n in graph[node])
        {
            indegree[n - 'a']--;
            if (indegree[n - 'a'] == 0)
            {
                if (!TopologicalSort(n, graph, indegree, result, visited))
                {
                    return false;
                }
            }
        }

        return true;
    }
}
