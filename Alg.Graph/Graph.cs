using System;
using System.Collections.Generic;

namespace Alg.Graphs
{
    public class Graph
    {
        /// <summary>
        /// Adjency matrix 
        /// </summary>
        private readonly List<List<int>> adjency;

        public Graph()
        {
            adjency = new List<List<int>>();
        }

        /// <summary>
        /// v is vertex of graph
        /// </summary>
        /// <param name="vFirst">number of vertex</param>
        /// <param name="vSecond">number of vertex</param>
        public void AddEdge(int vFirst, int vSecond)
        {
            while (adjency.Count < vFirst)
            {
                adjency.Add(new List<int>());
            }
            adjency[vFirst].Add(vSecond);
        }

        /// <summary>
        /// Depth-first search Implementation
        /// </summary>
        /// <param name="s"></param>
        public void FindDF(int vNumber)
        {
            Stack<int> stack = new Stack<int>();
            bool[] isVisited = new bool[adjency.Count];
            isVisited[vNumber] = true;
            stack.Push(vNumber);

            while (stack.Count != 0)
            {
                vNumber = stack.Pop();
                foreach (int connectedVertex in adjency[vNumber])
                {
                    if (!isVisited[connectedVertex])
                    {
                        isVisited[connectedVertex] = true;
                        stack.Push(connectedVertex);
                    }
                }
            }
        }
    }
}
