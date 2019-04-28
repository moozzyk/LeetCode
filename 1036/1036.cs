public class Solution {
    public bool IsEscapePossible(int[][] blocked, int[] source, int[] target) {
        if (blocked.Length == 0)
        {
            return true;
        }

        if (source[0] > target[0])
        {
            IsEscapePossible(blocked, target, source);
        }

        var minX = int.MaxValue;
        var maxX = int.MinValue;
        var minY = int.MaxValue;
        var maxY = int.MinValue;

        var blocks = new HashSet<(int, int)>();
        foreach (var b in blocked)
        {
            blocks.Add((b[0], b[1]));
            minX = Math.Min(minX, b[0]);
            maxX = Math.Max(maxX, b[0]);
            minY = Math.Min(minY, b[1]);
            maxY = Math.Max(maxY, b[1]);
        }

        if (maxX - minX > 200 || maxY - minY > 200)
        {
            return true;
        }

        if (minY > source[1])
        {
            source[1] = minY - 1;
        }

        if (maxY < target[1])
        {
            target[1] = maxY + 1;
        }

        if (maxX < target[0])
        {
            target[0] = maxX + 1;
        }
        if (minX > target[0])
        {
            target[0] = minX - 1;
        }

        var queue = new Queue<(int, int)>();
        queue.Enqueue((source[0], source[1]));

        var visited = new HashSet<(int, int)>();
        while (queue.Count > 0)
        {
            var coord = queue.Dequeue();
            if (visited.Contains(coord))
            {
                continue;
            }
            visited.Add(coord);
            var (x, y) = coord;
            if (x == target[0] && y == target[1])
            {
                return true;
            }
            if (y < source[1] || y > target[1] || x < 0 || x > Math.Max(source[0], target[0]) || blocks.Contains(coord))
            {
                continue;
            }

            queue.Enqueue((x + 1, y));
            queue.Enqueue((x, y + 1));
            queue.Enqueue((x - 1, y));
            queue.Enqueue((x, y - 1));
        }

        return false;
    }
}
