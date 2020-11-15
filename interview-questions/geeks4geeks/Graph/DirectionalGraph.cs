using System;
using System.Collections.Generic;

namespace interview_questions.geeks4geeks.Graph
{
    internal class DirectionalGraph
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

            if (!Edges.TryGetValue(v2, out _))
                Edges.Add(v2, new List<int>());
        }

        internal void TraverseAllDeepFirst(Action<int> visitor)
        {
            var visited = new HashSet<int>();
            foreach (var vertex in Vertices)
                if (!visited.Contains(vertex))
                    TraverseDeepFirstRecursePostOrder(vertex, visitor, visited);
        }

        private void TraverseDeepFirstRecursePostOrder(int vertex, Action<int> visitor, HashSet<int> visited)
        {
            if (visited.Contains(vertex))
                return;

            visited.Add(vertex);

            foreach (var adj in Edges[vertex])
                TraverseDeepFirstRecursePostOrder(adj, visitor, visited);

            visitor(vertex);
        }

    }
}