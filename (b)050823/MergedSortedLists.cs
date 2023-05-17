using System;
using System.Collections.Generic;

public class ListNode
{
    public int val;
    public ListNode? next;

    public ListNode(int val = 0, ListNode? next = null)
    {
        this.val = val;
        this.next = next;
    }
}

public class MinHeap<T>
{
    private readonly List<T> heap;
    private readonly Comparison<T> comparison;

    public MinHeap(Comparison<T> comparison)
    {
        this.heap = new List<T>();
        this.comparison = comparison;
    }

    public int Count { get { return heap.Count; } }

    public void Enqueue(T item)
    {
        heap.Add(item);
        int currentIndex = heap.Count - 1;

        while (currentIndex > 0)
        {
            int parentIndex = (currentIndex - 1) / 2;

            if (comparison(heap[currentIndex], heap[parentIndex]) >= 0)
                break;

            Swap(currentIndex, parentIndex);
            currentIndex = parentIndex;
        }
    }

    public T Dequeue()
    {
        int lastIndex = heap.Count - 1;
        T root = heap[0];
        heap[0] = heap[lastIndex];
        heap.RemoveAt(lastIndex);

        int currentIndex = 0;
        int childIndex = currentIndex * 2 + 1;

        while (childIndex < heap.Count)
        {
            int rightChildIndex = childIndex + 1;

            if (rightChildIndex < heap.Count && comparison(heap[rightChildIndex], heap[childIndex]) < 0)
                childIndex = rightChildIndex;

            if (comparison(heap[currentIndex], heap[childIndex]) <= 0)
                break;

            Swap(currentIndex, childIndex);
            currentIndex = childIndex;
            childIndex = currentIndex * 2 + 1;
        }

        return root;
    }

    private void Swap(int i, int j)
    {
        T temp = heap[i];
        heap[i] = heap[j];
        heap[j] = temp;
    }
}

public class Solution
{
    public ListNode? MergeKLists(ListNode[] lists)
    {
        if (lists == null || lists.Length == 0)
        {
            return null;
        }

        // Use a priority queue (min heap) to merge the lists
        MinHeap<ListNode> queue = new MinHeap<ListNode>((a, b) => a.val - b.val);

        // Add the head nodes of all lists to the priority queue
        foreach (ListNode head in lists)
        {
            if (head != null)
            {
                queue.Enqueue(head);
            }
        }

        ListNode dummy = new ListNode();
        ListNode current = dummy;

        // Merge the lists by repeatedly taking the smallest node from the priority queue
        while (queue.Count > 0)
        {
            ListNode smallest = queue.Dequeue();
            current.next = smallest;
            current = current.next;

            if (smallest.next != null)
            {
                queue.Enqueue(smallest.next);
            }
        }

        return dummy.next;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        // Create the example lists
        ListNode list1 = new ListNode(1);
        list1.next = new ListNode(4);
        list1.next.next = new ListNode(5);

        ListNode list2 = new ListNode(1);
        list2.next = new ListNode(3);
        list2.next.next = new ListNode(4);

        ListNode list3 = new ListNode(2);
        list3.next = new ListNode(6);

        // Merge the lists
        Solution solution = new Solution();
        ListNode merged = solution.MergeKLists(new ListNode[] { list1, list2, list3 });

        // Print the merged list
        while (merged != null)
        {
            Console.Write(merged.val + " ");
            merged = merged.next;
        }
    }
}
