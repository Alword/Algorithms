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
        /// <param name="vNumber">vertex Number</param>
        public void DFS(int vNumber)
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

        /// <summary>
        /// Breadth-first search
        /// </summary>
        /// <param name="vNumber"></param>
        public void BFS(int vNumber)
        {
            bool[] isVisited = new bool[adjency.Count];

            Queue<int> queue = new Queue<int>();
            isVisited[vNumber] = true;
            queue.Enqueue(vNumber);

            while (queue.Count != 0)
            {
                vNumber = queue.Dequeue();
                foreach (int connectedVertex in adjency[vNumber])
                {
                    if (!isVisited[connectedVertex])
                    {
                        isVisited[connectedVertex] = true;
                        queue.Enqueue(connectedVertex);
                    }
                }
            }
        }
    }
}