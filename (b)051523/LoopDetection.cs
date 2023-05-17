// Given a circular linked list, implement an algorithm that returns the node at the beginning of the loop.
// DEFINITION:
// Circular linked list: A (corrupt) linked list in which a node's next pointer points to an earlier node, so as to make a loop in the linked list.
// EXAMPLE
// Input: A -> B -> C -> D -> E -> C [the same C as earlier]
// Output: C

using System;

public class ListNode
{
    public int val;
    public ListNode next;

    public ListNode(int val = 0, ListNode next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class Solution
{
    public ListNode DetectCycle(ListNode head)
    {
        if (head == null || head.next == null)
            return null;

        ListNode slow = head;
        ListNode fast = head;

        while (fast != null && fast.next != null)
        {
            slow = slow.next;
            fast = fast.next.next;

            if (slow == fast)
                break;
        }

        if (fast == null || fast.next == null)
            return null;

        slow = head;

        while (slow != fast)
        {
            slow = slow.next;
            fast = fast.next;
        }

        return slow;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create the circular linked list: A -> B -> C -> D -> E -> C
        ListNode list = new ListNode('A');
        list.next = new ListNode('B');
        list.next.next = new ListNode('C');
        list.next.next.next = new ListNode('D');
        list.next.next.next.next = new ListNode('E');
        list.next.next.next.next.next = list.next.next; 

        Solution solution = new Solution();
        ListNode loopStartNode = solution.DetectCycle(list);

        if (loopStartNode != null)
            Console.WriteLine("Loop Start Node Value: " + loopStartNode.val);
        else
            Console.WriteLine("No Loop Found");
    }
}
