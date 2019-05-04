public class LRUCache
{
    private readonly LinkedList<KeyValuePair<int, int>> _list = new LinkedList<KeyValuePair<int, int>>();
    private readonly Dictionary<int, LinkedListNode<KeyValuePair<int, int>>> _dict = new Dictionary<int, LinkedListNode<KeyValuePair<int, int>>>();
    private readonly int _capacity;

    public LRUCache(int capacity)
    {
        _capacity = capacity;
    }

    public int Get(int key)
    {
        if (_dict.TryGetValue(key, out var node))
        {
            _list.Remove(node);
            _list.AddFirst(node);
            return node.Value.Value;
        }

        return -1;
    }

    public void Put(int key, int value)
    {
        if (_dict.TryGetValue(key, out var node))
        {
            node.Value = new KeyValuePair<int, int>(key, value);
            _list.Remove(node);
            _list.AddFirst(node);
            return;
        }

        node = new LinkedListNode<KeyValuePair<int, int>>(new KeyValuePair<int, int>(key, value));
        _list.AddFirst(node);
        _dict[key] = node;
        if (_list.Count > _capacity)
        {
            node = _list.Last;
            _list.RemoveLast();
            _dict.Remove(node.Value.Key);
        }
    }
}

/**
 * Your LRUCache object will be instantiated and called as such:
 * LRUCache obj = new LRUCache(capacity);
 * int param_1 = obj.Get(key);
 * obj.Put(key,value);
 */
