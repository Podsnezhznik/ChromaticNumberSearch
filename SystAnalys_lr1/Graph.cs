using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticNumberSearch
{
    class Graph
    {
        public List<List<int>> adjList = new List<List<int>>();

        public Graph()
        {

        }

        public Graph(List<Edge> edges, List<int> num)
        {
            int max = 0;
            foreach (int i in num)
            {
                if (max < i)
                {
                    max = i;
                }
            }

            adjList = new List<List<int>>(max + 1);
            for (int i = 0; i <= max + 1; i++)
                adjList.Add(new List<int>());

            foreach (Edge edge in edges)
            {
                adjList[edge.v1].Add(edge.v2);
                adjList[edge.v2].Add(edge.v1);
            }
        }

        public Graph(Graph graph)
        {
            this.adjList = graph.adjList.ToList();
        }
    }
}
