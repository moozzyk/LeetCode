public class Solution
{
    public int[] PrisonAfterNDays(int[] cells, int N) {
        if (N == 0)
        {
            return cells;
        }

        var cache = new List<int[]>();
        var visited = new HashSet<int>();
        cells = Transform(cells);

        for (var i = 0; i <= N; i++)
        {
            var hash = cells.Aggregate((res, next) => (res << 1) + next);
            if (visited.Contains(hash))
            {
                break;
            }
            visited.Add(hash);
            cache.Add((int[])cells.Clone());
            cells = Transform(cells);
        }

        var idx = (N - 1) % cache.Count;
        return cache[idx];
    }

    private static int[] Transform(int[] cells)
    {
        var newCells = new int[cells.Length];
        for (var i = 1; i < cells.Length - 1; i++)
        {
            if (cells[i - 1] == cells[i + 1])
            {
                newCells[i] = 1;
            }
        }

        return newCells;
    }
}
