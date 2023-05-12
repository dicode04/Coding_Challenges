//(b) Program for: Merged k Sorted Lists
using System;
using System.Collections.Generic;
public class Solution {
    public ListNode MergeKLists(ListNode[] lists) {
        if(lists.Length == 1) return lists[0];
        ListNode mergedHead = new ListNode();
        if(lists.Length == 0) return null;
        ListNode mergePtr = mergedHead;
        PriorityQueue<ListNode,int> heap = new PriorityQueue<ListNode,int>();
        for(int i=0;i<lists.Length;i++){
            if(lists[i]!=null)
                heap.Enqueue(lists[i], lists[i].val);
        }
        while(heap.Count>0){
            ListNode temp = heap.Dequeue();
            ListNode newNode = new ListNode();
            newNode.val = temp.val;
            temp = temp.next;
            if(temp!=null)
                heap.Enqueue(temp,temp.val);
            mergePtr.next = newNode;
            mergePtr = mergePtr.next;
        }
        return mergedHead.next;
    }
}
