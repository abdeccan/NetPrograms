using NETTestApp;

class Program
{
    
    public static void Main(string[] args)
    {
        PriorityQueueTest priQTest = new PriorityQueueTest();
        int[] nums = new int[] { 10, 20, 40, 50, 25, 12, 15, 6 };
        int kthLargest = priQTest.FindKthLargest(nums, 4);

        PriorityQueueTest.TestPriorityQueue();

        Trie trie = new Trie();
        trie.Insert("apple");
        bool found = trie.Search("app");
        found = trie.StartsWith("app");
        trie.Insert("app");
        found = trie.Search("app");

        Queue<string> letterQ = new();
        letterQ.Enqueue("sunday");
        letterQ.Enqueue("monday");
        letterQ.Enqueue("tuesday");
        letterQ.Enqueue("wednesday");
        letterQ.Enqueue("thursday");
        letterQ.Enqueue("friday");
        letterQ.Enqueue("saturday");

        while (letterQ.Count > 0)
        {
            Console.WriteLine("letterQ next: {0}", letterQ.Dequeue());
        }

        Stack<string> tasks = new();
        tasks.Push("maths hw");
        tasks.Push("science hw");
        tasks.Push("english hw");

        while (tasks.Count > 0)
        {
            Console.WriteLine("Tasks next: {0}", tasks.Pop());
        }

        


        Console.WriteLine("tasks size: {0}", tasks.Count);
    }
    
}