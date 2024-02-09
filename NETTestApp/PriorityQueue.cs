using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class PriorityQueueTest
    {
        public class IntMaxComparer : IComparer<int>
        {
            public int Compare(int x, int y)
            {
                //return y.CompareTo(x); // max heap, descending
                return x.CompareTo(y); // min heap, ascending
            }
        }
        public int FindKthLargest(int[] nums, int k)
        {
            PriorityQueue<int, int> priQ = new (new IntMaxComparer());
            // populate the PriorityQueue
            for (int index = 0; index < nums.Length; index++)
            {
                priQ.Enqueue(nums[index], nums[index]);
            }

            // the max heap will alredy have the nums in sorted order, need to pop the top element\
            // k times
            int kthLargest = 0;
            for (int index = 0; index < k; index++)
            {
                kthLargest = priQ.Dequeue();
            }

            return kthLargest;
        }
        public class Employee : IComparable<Employee>
        {
            public int _id;
            public string _name;
            public Employee(string name, int id)
            {
                _name = name;
                _id = id;
            }

            public int CompareTo(Employee? other)
            {
                if (this._id > other._id)
                    return 1;
                else if (this._id < other._id)
                    return -1;
                else
                    return 0;
            }
        }

        public class MyComparer : IComparer<Employee>
        {
            public int Compare(Employee? x, Employee? y)
            {
                return x.CompareTo(y); // min heap, ascending
            }
        }
        public static void TestPriorityQueue()
        {
            PriorityQueue<Employee, Employee> priQ = new (new MyComparer());
            Employee john = new("John", 1);
            Employee mary = new("Mary", 2);
            Employee dean = new("Dean", 3);
            Employee sam = new("Sam", 4);
            MyComparer comp = new();

            priQ.Enqueue(sam, sam);
            priQ.Enqueue(dean, dean);
            priQ.Enqueue(john, john);
            priQ.Enqueue(mary, mary);

            while (priQ.Count > 0)
            {
                Console.WriteLine($"Dequeued { priQ.Dequeue()._name}");
            }
        }
    }
}
