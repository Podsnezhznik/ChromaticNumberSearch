using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChromaticNumberSearch
{
    class ChromaticNumber
    {
        static List<List<int>> combinations = new List<List<int>>();

        static bool TrueColor(List<int> num, List<int> comb1, Graph graph)
        {
            Graph graph1 = new Graph();
            for (int i = 0; i < graph.adjList.Count; i++)
            {
                graph1.adjList.Add(new List<int>());
                for (int j = 0; j < graph.adjList[i].Count; j++)
                    graph1.adjList[i].Add(graph.adjList[i][j]);
            }

            List<int> comb = comb1.ToList();

            for (int i = 0; i < comb.Count; i++)
            {
                comb[i] = -(comb[i]);
            }

            int size;

            for (int i = 0; i < num.Count; i++)
            {
                size = graph1.adjList[num[i]].Count;
                for (int j = 0; j < size; j++)
                {
                    for (int d = 0; d < comb.Count; d++)
                    {
                        if (graph1.adjList[num[i]][j] == num[d])
                        {
                            graph1.adjList[num[i]][j] = comb[d];
                        }
                    }
                }
            }

            bool go = true;
            for (int i = 0; i < num.Count; i++)
            {
                size = graph1.adjList[num[i]].Count;
                for (int j = 0; j < size; j++)
                {
                    if (graph1.adjList[num[i]][j] == comb[i] && go)
                    {
                        go = false;
                    }
                }
            }
            return go;
        }

        static void FindCombinations(List<int> color, List<int> outList, int k, int i, int n)
        {
            if (outList.Count == k)
            {
                foreach (var item in Permutation.GetAllPermutations(outList))
                {
                    combinations.Add(item);
                }
                return;

            }

            for (int j = i; j < n; j++)
            {
                outList.Add(color[j]);
                FindCombinations(color, outList, k, j, n);
                outList.RemoveAt(outList.Count - 1);
            }
        }

        static List<int> Coloring(List<int> num, Graph graph, int n)
        {
            List<int> color = new List<int>();
            List<int> outList = new List<int>();

            color.Add(1);
            for (int c = 2; c <= n; c++)
            {
                combinations.Clear();
                color.Add(c);
                FindCombinations(color, outList, n, 0, color.Count);

                if (true)
                { }

                for (int i = 0; i < combinations.Count; i++)
                {
                    if (TrueColor(num, combinations[i], graph))
                    {
                        return combinations[i];
                    }
                }
            }
            return color;
        }

        static public List<int> Play(List<Vertex> vertex, List <Edge> edges)
        {
            List<int> num = new List<int>();
            for (int i = 0; i < vertex.Count; i++)
            {
                num.Add(i);
            }

            Graph graph = new Graph(edges, num);

            return Coloring(num, graph, num.Count);

        }
    }
}
