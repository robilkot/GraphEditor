using System.Text.Json.Serialization;

namespace LW5.Logic
{
    [Serializable]
    public class Graph
    {
        public List<GraphObject> Elements { get; set; } = new();
        public List<Vertex> Vertices { get => Elements.OfType<Vertex>().ToList(); }
        public List<Edge> Edges { get => Elements.OfType<Edge>().ToList(); }
        public List<Edge> Loops { get => (from e in Edges
                                         where e.First == e.Second
                                         select e).ToList(); }
        public int Size => Vertices.Count;

        [JsonConstructor]
        public Graph() { }

        public void Add(GraphObject graphObject)
        {
            Elements.Add(graphObject);
        }
        public void Remove(GraphObject graphObject)
        {
            Elements.Remove(graphObject);
            foreach (var incident in graphObject.IncidentEdges)
            {
                Elements.Remove(incident);
            }
            if (graphObject is Edge edge)
            {
                foreach (Vertex vertex in Vertices.Cast<Vertex>())
                {
                    vertex.IncidentEdges.RemoveAll(e => e == edge);
                }
            }
        }
    }
}
