/*
// Definition for a Node.
public class Node {
    public int val;
    public Node prev;
    public Node next;
    public Node child;

    public Node(){}
    public Node(int _val,Node _prev,Node _next,Node _child) {
        val = _val;
        prev = _prev;
        next = _next;
        child = _child;
}
*/
public class Solution
{
    public Node Flatten(Node head)
    {
        Flatten(head, out var _);
        return head;
    }

    private static Node Flatten(Node head, out Node tail)
    {
        var current = head;
        tail = null;
        while (current != null)
        {
            if (current.child != null)
            {
                var childHead = Flatten(current.child, out var childTail);
                var next = current.next;
                current.next = childHead;
                childHead.prev = current;
                childTail.next = next;
                if (next != null)
                {
                    next.prev = childTail;
                }
                current.child = null;
                current = next;
                tail = childTail;
            }
            else
            {
                tail = current;
                current = current.next;
            }
        }

        return head;
    }
}
