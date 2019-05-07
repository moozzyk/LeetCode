public class Solution
{
    public int ShortestDistance(int[][] grid)
    {
        if (grid.Length == 0 || grid[0].Length == 0)
        {
            return -1;
        }

        var state = new Dictionary<int, int>[grid.Length, grid[0].Length];
        var q = new Queue<(int, (int, int))>();

        var id = 1;
        for (var row = 0; row < grid.Length; row++)
        {
            for (var col = 0; col < grid[0].Length; col++)
            {
                state[row, col] = new Dictionary<int, int>();
                if (grid[row][col] == 1)
                {
                    q.Enqueue((id, (row, col)));
                    id++;
                }
            }
        }

        var numHouses = id - 1;
        var step = 0;
        var minValue = int.MaxValue;
        while (q.Count > 0)
        {
            var count = q.Count;
            for (var i = 0; i < count; i++)
            {
                var (pointId, (r, c)) = q.Dequeue();
                if (r < 0 || r == grid.Length || c < 0 || c == grid[0].Length ||
                    (step > 0 && grid[r][c] != 0))
                {
                    continue;
                }

                if (state[r, c].TryAdd(pointId, step))
                {
                    if (state[r, c].Count == numHouses && step != 0)
                    {
                        minValue = Math.Min(minValue, state[r, c].Values.Sum());
                    }

                    q.Enqueue((pointId, (r + 1, c)));
                    q.Enqueue((pointId, (r - 1, c)));
                    q.Enqueue((pointId, (r, c + 1)));
                    q.Enqueue((pointId, (r, c - 1)));
                }
            }

            step++;
        }

        if (minValue < int.MaxValue)
        {
            return minValue;
        }

        return -1;
    }
}