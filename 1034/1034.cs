public class Solution
{
    public int[][] ColorBorder(int[][] grid, int r0, int c0, int color)
    {
        var border = new List<(int, int)>();
        FindBorder(grid, r0, c0, grid[r0][c0], border, new HashSet<(int, int)>());

        foreach (var (r, c) in border)
        {
            grid[r][c] = color;
        }

        return grid;
    }

    private void FindBorder(int[][] grid, int r, int c, int color, IList<(int, int)> border, HashSet<(int, int)> visited)
    {
        if (r < 0 || c < 0 || r == grid.Length || c == grid[0].Length || grid[r][c] != color || visited.Contains((r, c)))
        {
            return;
        }

        visited.Add((r, c));

        if (r == 0 || c == 0 || r == grid.Length - 1 || c == grid[0].Length - 1 ||
            grid[r - 1][c] != color || grid[r + 1][c] != color || grid[r][c - 1] != color || grid[r][c + 1] != color)
        {
            border.Add((r, c));
        }

        FindBorder(grid, r - 1, c, color, border, visited);
        FindBorder(grid, r + 1, c, color, border, visited);
        FindBorder(grid, r, c - 1, color, border, visited);
        FindBorder(grid, r, c + 1, color, border, visited);
    }
}
