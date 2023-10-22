namespace LW5.Logic
{
    [Serializable]
    public class Graph
    {
        public List<GraphObject> Elements { get; set; } = new();
        public List<GraphObject> Vertices { get => Elements.Where(e => e is Vertex).ToList(); }
        public List<GraphObject> Edges { get => Elements.Where(e => e is Edge).ToList(); }
        public List<GraphObject> Loops { get => Elements.Where(e => e is Edge edge && edge.First == edge.Second).ToList(); }
        public int Size => Elements.Where(e => e is Vertex).Count();

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
