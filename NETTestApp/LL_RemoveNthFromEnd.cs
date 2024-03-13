using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class LL_RemoveNthFromEnd
    {
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
        public ListNode RemoveNthFromEnd(ListNode head, int n)
        {

            ListNode dummy = new ListNode(0);
            dummy.next = head;
            ListNode first = dummy;
            ListNode second = dummy;

            // Advances first pointer so that the gap between first and second is n nodes apart
            for (int i = 1; i <= n + 1; i++)
            {
                first = first.next;
            }

            // Move first to the end, maintaining the gap
            while (first != null)
            {
                first = first.next;
                second = second.next;
            }
            second.next = second.next.next;
            return dummy.next;
        }

        public static void Test()
        {
            ListNode list = new();
            ListNode head = list;
            list.val = 1;

            for (int i = 1; i < 2; i++)
            {
                ListNode temp = new();
                temp.val = i + 1;
                list.next = temp;
                list = temp;
            }
            Console.WriteLine("Before removal");
            ListNode node = head;

            while (node != null)
            {
                Console.Write($"{node.val} --> ");
                node = node.next;
            }

            LL_RemoveNthFromEnd obj = new();
            ListNode newHead = obj.RemoveNthFromEnd(head, 2);

            Console.WriteLine("After removal");
            node = newHead;

            while (node != null)
            {
                Console.Write($"{node.val} --> ");
                node = node.next;
            }
        }
    }
}
