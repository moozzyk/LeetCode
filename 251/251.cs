public class Vector2D
{
    private readonly int[][] _v;
    private int _array = 0;
    private int _item = -1;

    public Vector2D(int[][] v)
    {
        _v = v;
    }

    public int Next()
    {
        (_array, _item) = NextIndex();
        return _v[_array][_item];
    }

    public bool HasNext()
    {
        var (array, _) = NextIndex();
        return array < _v.Length;
    }

    private (int, int) NextIndex()
    {
        var array = _array;
        var item = _item;
        while (array < _v.Length)
        {
            item++;
            if (item == _v[array].Length)
            {
                array++;
                item = -1;
            }
            else
            {
                break;
            }
        }

        return (array, item);
    }
}

/**
 * Your Vector2D object will be instantiated and called as such:
 * Vector2D obj = new Vector2D(v);
 * int param_1 = obj.Next();
 * bool param_2 = obj.HasNext();
 */