using System;
using System.Collections.Generic;
using System.Linq;

namespace microsoft_questions.geeks4geeks.Graph
{
    internal class UnDirectionalGraph
    {
        internal HashSet<int> Vertices = new HashSet<int>();
        internal Dictionary<int, List<int>> Edges = new Dictionary<int, List<int>>();

        internal void AddEdge(int v1, int v2)
        {
            Vertices.Add(v1);
            Vertices.Add(v2);

            if (Edges.TryGetValue(v1, out var adj)) 
                adj.Add(v2);
            else
                Edges.Add(v1, new List<int> {v2});

            if (Edges.TryGetValue(v2, out var adj2))
                adj2.Add(v1);
            else
                Edges.Add(v2, new List<int> {v1});
        }

        internal void TraverseDeepFirst(int vertex, Action<int> visitor)
        {
            TraverseDeepFirstRecurse(vertex, visitor, new HashSet<int>());
        }

        internal void TraverseBreadthFirst(int start, Action<int> visitor)
        {
            var verticesToGo = new Queue<int>();
            var visited = new HashSet<int>();

            verticesToGo.Enqueue(start);

            while (verticesToGo.Any())
            {
                var vertex = verticesToGo.Dequeue();
                if (visited.Contains(vertex))
                    continue;
                visited.Add(vertex);
                visitor(vertex);
                foreach (var adj in Edges[vertex]) 
                    verticesToGo.Enqueue(adj);
            }
        }

        private void TraverseDeepFirstRecurse(int vertex, Action<int> visitor, HashSet<int> visited)
        {
            if (visited.Contains(vertex))
                return;

            visitor(vertex);
            visited.Add(vertex);

            foreach (var adj in Edges[vertex]) 
                TraverseDeepFirstRecurse(adj, visitor, visited);
        }
    }
}