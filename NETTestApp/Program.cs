using NETTestApp;

class Program
{
    
    public static void Main(string[] args)
    {
        string[] bulkInput = {
                                "file1.txt 100",
                                "file2.txt 200 collection1",
                                "file3.txt 200 collection1,collection2",
                                "file4.txt 300 collection2",
                                "file5.txt 100" 
                             };
        CollectionOfFiles cof = new CollectionOfFiles(bulkInput);
        Console.WriteLine($"Total file size is {cof.GetTotalFileSize()}");
        foreach (Tuple<string, int> tup in cof.GetTopKCollections(2)) {
            Console.WriteLine($"{tup.Item1}: {tup.Item2}");
        }

        int[] times = { 0, 5, 10, 15, 20, 25, 30 };
        int val = 5;
        int index = ~Array.BinarySearch(times, val);

        int[] persons = { 0, 1, 1, 0, 0, 1, 0 };
        TopVotedCandidate tvc = new TopVotedCandidate(persons, times);
        int winner = tvc.Q(8);
        Console.WriteLine(winner);
        winner = tvc.Q(12);
        Console.WriteLine(winner);
        winner = tvc.Q(25);
        Console.WriteLine(winner);
        winner = tvc.Q(15);
        Console.WriteLine(winner);
        winner = tvc.Q(24);
        Console.WriteLine(winner);
        winner = tvc.Q(8);
        Console.WriteLine(winner);

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