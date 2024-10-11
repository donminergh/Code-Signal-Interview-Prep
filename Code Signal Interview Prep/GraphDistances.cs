using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code_Signal_Interview_Prep
{
    internal class GraphDistances
    {

        // Leetcode 743.Network Delay Time
        // Adjacency list
        Dictionary<int, List<(int Time, int Node)>> adj = new Dictionary<int, List<(int Time, int Node)>>();

        int[] graphDistances(int[][] times, int k)
        {

            for (int i = 0; i < times.Length; i++)
            {
                for (int j = 0; j < times[0].Length; j++)
                {
                    int source = i;
                    int dest = j;
                    int travelTime = times[i][j];
                    if (travelTime == -1) continue;
                    if (!adj.ContainsKey(source))
                    {
                        adj[source] = new List<(int Time, int Node)>();
                    }
                    adj[source].Add((travelTime, dest));
                }
            }

            int[] signalReceivedAt = new int[times.Length];
            Array.Fill(signalReceivedAt, int.MaxValue);

            Dijkstra(signalReceivedAt, k, times.Length);



            return signalReceivedAt;
        }

        void Dijkstra(int[] signalReceivedAt, int source)
        {
            var pq = new PriorityQueue<(int Time, int Node), int>();
            pq.Enqueue((0, source), 0);

            // Time for starting node is 0
            signalReceivedAt[source] = 0;

            while (pq.Count > 0)
            {
                var topPair = pq.Dequeue();

                int currNode = topPair.Node;
                int currNodeTime = topPair.Time;

                if (currNodeTime > signalReceivedAt[currNode])
                {
                    continue;
                }

                if (!adj.ContainsKey(currNode))
                {
                    continue;
                }

                // Broadcast the signal to adjacent nodes
                foreach (var edge in adj[currNode])
                {
                    int time = edge.Time;
                    int neighborNode = edge.Node;

                    // Fastest signal time for neighborNode so far
                    // signalReceivedAt[currNode] + time : 
                    // time when signal reaches neighborNode
                    if (signalReceivedAt[neighborNode] > currNodeTime + time)
                    {
                        signalReceivedAt[neighborNode] = currNodeTime + time;
                        pq.Enqueue((signalReceivedAt[neighborNode], neighborNode), signalReceivedAt[neighborNode]);
                    }
                }
            }
        }

    }
}
