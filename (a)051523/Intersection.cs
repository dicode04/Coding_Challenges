//C# program for:
//Given two (singly) linked lists, determine if the two lists intersect. Return the intersecting node. 
//Note that the intersection is defined based on reference, not value. 
//That is, if the kth node of the first linked list is the exact same node (by reference) as the jth node of the second linked list, then they are intersecting.

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
    public ListNode GetIntersectionNode(ListNode headA, ListNode headB)
    {
        if (headA == null || headB == null)
            return null;

        ListNode ptrA = headA;
        ListNode ptrB = headB;

        while (ptrA != ptrB)
        {
            ptrA = ptrA.next;
            ptrB = ptrB.next;

            if (ptrA == null && ptrB == null)
                return null;

            if (ptrA == null)
                ptrA = headB;

            if (ptrB == null)
                ptrB = headA;
        }

        return ptrA;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create the first linked list: 1->2->3->4->5
        ListNode list1 = new ListNode(1);
        list1.next = new ListNode(2);
        list1.next.next = new ListNode(3);
        list1.next.next.next = new ListNode(4);
        list1.next.next.next.next = new ListNode(5);

        // Create the second linked list: 6->7->8
        ListNode list2 = new ListNode(6);
        list2.next = new ListNode(7);
        list2.next.next = new ListNode(8);

        // Connect the two lists at node 4
        list2.next.next.next = list1.next.next.next;

        // Find the intersection node
        Solution solution = new Solution();
        ListNode intersectionNode = solution.GetIntersectionNode(list1, list2);

        if (intersectionNode != null)
            Console.WriteLine("Intersection Node Value: " + intersectionNode.val);
        else
            Console.WriteLine("No Intersection Node");
    }
}
