/*
// Definition for a Node.
public class Node {
    public int val;
    public Node left;
    public Node right;

    public Node(){}
    public Node(int _val,Node _left,Node _right) {
        val = _val;
        left = _left;
        right = _right;
}
*/
public class Solution
{
    public Node TreeToDoublyList(Node root)
    {
        if (root == null)
        {
            return null;
        }

        TreeToDoublyList(root, out var head, out var tail);
        head.left = tail;
        tail.right = head;
        return head;
    }

    private void TreeToDoublyList(Node node, out Node head, out Node tail)
    {
        if (node.left != null)
        {
            TreeToDoublyList(node.left, out var leftHead, out var leftTail);
            node.left = leftTail;
            leftTail.right = node;
            head = leftHead;
        }
        else
        {
            head = node;
        }

        if (node.right != null)
        {
            TreeToDoublyList(node.right, out var rightHead, out var rightTail);
            node.right = rightHead;
            rightHead.left = node;
            tail = rightTail;
        }
        else
        {
            tail = node;
        }
    }
}
