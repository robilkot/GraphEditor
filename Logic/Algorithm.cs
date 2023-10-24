namespace LW5.Logic
{
    public static class Algorithm
    {
        public static bool IsEuler(Graph graph)
        {
            if ((from v in graph.Vertices
                 where v.Degree % 2 != 0
                 select v).Count() > 2)
            {
                return false;
            }

            foreach (var vertex in graph.Vertices)
            {
                if (InDegree(vertex) != OutDegree(vertex))
                {
                    return false;
                }
            }

            if (!IsWeaklyConnected(graph))
            {
                return false;
            }

            return true;
        }

        public static List<Vertex> EulerCycle(Graph graph)
        {
            if (graph.Size == 0)
            {
                return new();
            }
            if (!IsEuler(graph))
            {
                return new();
            }

            List<Edge> visited = new();
            List<Vertex> path = new();
            Stack<Vertex> stack = new();

            stack.Push(graph.Vertices[0]);

            while (stack.Count > 0)
            {
                var V = stack.Peek();

                var E = V.IncidentEdges.Find(e => visited.Contains(e) == false);

                if (E != null)
                {
                    stack.Push((Vertex)E.Second);
                    visited.Add(E);
                }
                else
                {
                    _ = stack.Pop();
                    path.Add(V);
                }
            }

            path.RemoveAt(path.Count - 1);
            path.Reverse();
            return path.ToList();
        }

        public static List<Vertex> Dijkstra(Graph graph, Vertex begin, Vertex end)
        {
            Dictionary<Vertex, int> shortestPaths = graph.Vertices.ToDictionary(v => v, v => int.MaxValue);
            Dictionary<Vertex, Vertex> prevVerts = graph.Vertices.ToDictionary(v => v, v => v);
            List<Vertex> visited = new(graph.Size);

            void visitVertex(Vertex v)
            {
                if (visited.Contains(v))
                {
                    return;
                }
                visited.Add(v);

                foreach (var adj in v.AdjacentVertices)
                {
                    var edge = v.IncidentEdges.Find(e => e.EdgeType == EdgeType.Unoriented || e.First == v && e.Second == adj);

                    var newDistance = shortestPaths[v] + edge.Weight;
                    if (newDistance < shortestPaths[adj])
                    {
                        shortestPaths[adj] = newDistance;
                        prevVerts[adj] = v;
                    }
                }

                foreach (var adj in v.AdjacentVertices)
                {
                    visitVertex(adj);
                }
            }

            shortestPaths[begin] = 0;
            visitVertex(begin);

            // Restore route
            List<Vertex> route = new()
            {
                end
            };
            while (prevVerts[route.Last()] != route.Last())
            {
                route.Add(prevVerts[route.Last()]);
            }

            return route;
        }

        //public static List<List<Vertex>> GetAllRoutes(Graph graph, Vertex begin, Vertex end)
        //{
        //    List<List<Vertex>> routes = new();

        //    return routes;
        //}

        public static bool IsStronglyConnected(Graph graph)
        {
            if (graph.Size == 0) return false;

            List<Vertex> visited = new(graph.Size);

            foreach (var vertex in graph.Vertices)
            {
                visited.Clear();
                VisitVertex(vertex, visited);
                if (visited.Count != graph.Size)
                {
                    return false;
                }
            }

            return true;
        }
        private static void VisitVertex(Vertex vertex, List<Vertex> visited)
        {
            if (visited.Contains(vertex))
            {
                return;
            }
            visited.Add(vertex);

            foreach (var adjacent in vertex.AdjacentVertices)
            {
                VisitVertex(adjacent, visited);
            }
        }

        public static bool IsWeaklyConnected(Graph graph)
        {
            if (graph.Size == 0) return false;

            List<Vertex> visited = new(graph.Size);

            foreach (var vertex in graph.Vertices)
            {
                visited.Clear();
                WeakVisitVertex(vertex, visited);
                if (visited.Count != graph.Size)
                {
                    return false;
                }
            }

            return true;
        }
        private static void WeakVisitVertex(Vertex vertex, List<Vertex> visited)
        {
            if (visited.Contains(vertex))
            {
                return;
            }
            visited.Add(vertex);

            foreach (var adjacent in WeakAdjacentVertices(vertex))
            {
                WeakVisitVertex(adjacent, visited);
            }
        }
        private static List<Vertex> WeakAdjacentVertices(Vertex vertex)
        {
            List<Vertex> adjacent = new();

            foreach (var e in vertex.IncidentEdges)
            {
                if (e.Second is Vertex v2 && v2 != vertex)
                {
                    adjacent.Add(v2);
                }
                if (e.First is Vertex v1 && v1 != vertex)
                {
                    adjacent.Add(v1);
                }
            }

            return adjacent.ToList();
        }

        public static int InDegree(Vertex vertex)
        {
            return (from e in vertex.IncidentEdges
                    where e.Second == vertex || e.EdgeType == EdgeType.Unoriented
                    select e).Count();
        }
        public static int OutDegree(Vertex vertex)
        {
            return (from e in vertex.IncidentEdges
                    where e.First == vertex || e.EdgeType == EdgeType.Unoriented
                    select e).Count();
        }
    }
}
