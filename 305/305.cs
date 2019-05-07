public class Solution
{
    public IList<int> NumIslands2(int m, int n, int[][] positions)
    {
        var result = new List<int>();
        var numIslands = 0;
        var islands = Enumerable.Repeat(-1, n * m).ToArray();

        foreach (var pos in positions)
        {
            var island = pos[0] * n + pos[1];
            numIslands++;
            islands[island] = island;

            numIslands -= JoinIslands(island, islands, pos[0] - 1, pos[1], m, n);
            numIslands -= JoinIslands(island, islands, pos[0] + 1, pos[1], m, n);
            numIslands -= JoinIslands(island, islands, pos[0], pos[1] - 1, m, n);
            numIslands -= JoinIslands(island, islands, pos[0], pos[1] + 1, m, n);
            result.Add(numIslands);
        }

        return result;
    }

    static int JoinIslands(int island, int[] islands, int m, int n, int M, int N)
    {
        var neighbor = m * N + n;
        if (m < 0 || m == M || n < 0 || n == N || islands[neighbor] == -1)
        {
            return 0;
        }

        var neighborParent = FindRoot(islands, neighbor);
        if (neighborParent != island)
        {
            islands[neighborParent] = island;
            return 1;
        }

        return 0;
    }

    static int FindRoot(int[] islands, int island)
    {
        while (island != islands[island])
        {
            island = islands[island];
            islands[island] = islands[islands[island]]; // path compression (25% speed up)
        }
        return island;
    }
}