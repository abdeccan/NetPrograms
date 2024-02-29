using NETTestApp;

class Program
{
    public static void DoTest()
    {
        int[] nums = {3,0,1 };

        int newSize = nums.Length + 1;
        int[] tmpArr = Enumerable.Repeat(-1, newSize).ToArray();
        for (int i = 0; i < nums.Length; i++)
        {
            tmpArr[nums[i]] = 0;
        }

        int index = 0;
        for (; index < tmpArr.Length; index++)
        {
            if (tmpArr[index] == -1)
                break;
        }
        Console.WriteLine($"missing num  {index}");

    }

    public static void Main(string[] args)
    {
        even_odd_levels.TestEvenOddLevels();

        DiameterBinTree.TestDiameterBinTree();

        SameTree.TestSameTree();

        CheapestFlight cf = new CheapestFlight();
        int[][] flights = new int[][] { new int[] { 0, 1, 100 },
                                        new int[] { 1, 2, 100 },
                                        new int[] { 2, 0, 100 },
                                        new int[] {1,3,600},
                                        new int[] {2,3,200 }};
        int cheapest = cf.FindCheapestPrice(4, flights, 0, 3, 1);

        TownJudge tj = new TownJudge();
        int n = 3;
        int[][] trust = new int[][] { new int[] { 1, 2 }, new int[] { 2, 3 } }; // { new int[] { 1, 3 }, new int[] { 2, 3 }, new int[] { 3, 1 } };,
        int judge = tj.FindJudge(n, trust);

        TrieFileSystem fs = new TrieFileSystem();
        bool bRet = fs.CreatePath("/leet", 1);
        bRet = fs.CreatePath("/leet/code", 2);
        bRet = fs.CreatePath("/leet/code/neat", 3);
        bRet = fs.CreatePath("/a", 10);
        bRet = fs.CreatePath("/neat/code", 100);

        int fsVal = fs.Get("/leet/code/neat");
        fsVal = fs.Get("/leet/code/");
        fsVal = fs.Get("/leet/neat");

        // team voting
        string[] votes = { "ABC", "ACB", "ABC", "ACB", "ACB" }; // { "ACBD", "ACBD", "BCDA", "BDCA" };// //{ "WXYZ", "XYZW" }; // 
        TeamVoting teamVoting = new TeamVoting();
        string result = teamVoting.RankTeams(votes);
        Console.WriteLine($"result is {result}");

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