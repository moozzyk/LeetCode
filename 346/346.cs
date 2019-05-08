public class MovingAverage
{
    private readonly int size = 0;
    private Queue<int> que = new Queue<int>();
    private int sum = 0;

    /** Initialize your data structure here. */
    public MovingAverage(int size)
    {
        this.size = size;
    }

    public double Next(int val)
    {
        que.Enqueue(val);
        sum += val;
        if (que.Count > size)
        {
            sum -= que.Dequeue();
        }

        return (double)sum / (double)que.Count;
    }
}

/**
 * Your MovingAverage object will be instantiated and called as such:
 * MovingAverage obj = new MovingAverage(size);
 * double param_1 = obj.Next(val);
 */