using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class TownJudge
    {
        public int FindJudge(int n, int[][] trust)
        {
            // think of the trust relationship as a directed graph
            // judge doesnt trust anyone => no outdegrees for judge node
            // everyone else trusts the judge => n-1 indegress for judge node
            // need to find the node that matches the above two criteria

            int[] indegrees = new int[n + 1];
            int[] outdegrees = new int[n + 1];

            // sample inputs are {1,3}, {2,3}, {3,1} for n=3
            // here node1 has 1 outdegree to node3 and 1 indegree
            // node2 has one outdegree to node3
            // node3 has 2 indegrees - =1 each from node1 and node2 and 1 outdegree to node1
            foreach (int[] relation in trust)
            {
                outdegrees[relation[0]]++;
                indegrees[relation[1]]++;
            }

            // we now have the indegrees and outdegrees
            for (int i = 1; i < n + 1; i++)
            {
                if (outdegrees[i] == 0 && indegrees[i] == n - 1)
                    return i;
            }

            return -1;
        }
    }
}
