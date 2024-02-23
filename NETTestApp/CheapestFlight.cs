using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NETTestApp
{
    internal class CheapestFlight
    {
        public int FindCheapestPrice(int n, int[][] flights, int src, int dst, int k)
        {
            Dictionary<int, List<int[]>> adj = new();
            foreach (var flight in flights)
            {
                if (!adj.ContainsKey(flight[0]))
                {
                    adj.Add(flight[0], new List<int[]>());
                }
                adj[flight[0]].Add(new int[] { flight[1], flight[2] });
            }

            int[] dist = Enumerable.Repeat(int.MaxValue, n).ToArray();

            Queue<int[]> q = new();
            q.Enqueue(new int[] { src, 0 });
            int stops = 0;

            while (stops <= k && q.Count > 0)
            {
                int size = q.Count;
                while (size-- > 0)
                {
                    int[] entry = q.Peek();
                    int node = entry[0];
                    int distance = entry[1];
                    q.Dequeue();

                    if (!adj.ContainsKey(node)) continue;

                    // iterate over the neighbors of the popped node
                    foreach (var t in adj[node])
                    {
                        var price = t[1];
                        var neighbor = t[0];
                        if (price + distance >= dist[neighbor]) continue;

                        dist[neighbor] = price + distance;
                        q.Enqueue(new int[] { neighbor, dist[neighbor] });
                    }
                }
                stops++;
            }

            return dist[dst] == int.MaxValue ? -1 : dist[dst];
        }
    }
}
