/**
 * Definition for singly-linked list.
 * public class ListNode {
 *     public int val;
 *     public ListNode next;
 *     public ListNode(int x) { val = x; }
 * }
 */
public class Solution
{
    public ListNode AddTwoNumbers(ListNode l1, ListNode l2)
    {
        var resultHead = new ListNode(-1);
        var result = resultHead;

        var carry = 0;
        while (l1 != null || l2 != null) {

            var digit = (l1?.val ?? 0) + (l2?.val ?? 0) + carry;
            result.next = new ListNode(digit % 10);
            result = result.next;
            carry = digit / 10 != 0 ? 1 : 0;
            l1 = l1?.next;
            l2 = l2?.next;
        }

        if (carry > 0) {
            result.next = new ListNode(1);
        }

        return resultHead.next;
    }
}