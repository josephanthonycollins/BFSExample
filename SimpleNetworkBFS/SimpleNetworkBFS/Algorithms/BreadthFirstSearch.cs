using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SimpleNetworkBFS.Structures;
using SimpleNetworkBFS.Data;
using SimpleNetworkBFS.Wrapper;

namespace SimpleNetworkBFS.Algorithms
{
    //Class taken from www.quora.com
    //Modification made to stop search if node is reached.

    public class BreadthFirstSearch
    {
        public int[] edgeTo;
        public int[] distTo;
        public int s;
        public int e;

        public BreadthFirstSearch(GraphAdjList G, int s,int e)
        {
            edgeTo = new int[G.VertexCount];
            distTo = new int[G.VertexCount];

            for (int i = 0; i < G.VertexCount; i++)
            {
                distTo[i] = -1;
                edgeTo[i] = -1;
            }

            this.s = s;
            this.e = e;

            BFS(G, s);
        }

        void BFS(GraphAdjList G, int s)
        {
            var queue = new Queue<int>();
            queue.Enqueue(s);
            distTo[s] = 0;

            while (queue.Count != 0)
            {
                int v = queue.Dequeue();

                foreach (var w in G.GetAdj(v))
                {
                    //if we reach the destination node, clear the queue to stop the search.
                    if (w == e)
                    {
                        distTo[w] = distTo[v] + 1;
                        edgeTo[w] = v;
                        queue.Clear();
                        break;
                    }

                    if (distTo[w] == -1)
                    {
                        queue.Enqueue(w);
                        distTo[w] = distTo[v] + 1;
                        edgeTo[w] = v;
                    }
                }
            }
        }
    }
}
