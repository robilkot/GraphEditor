namespace LW5.Logic
{
    [Serializable]
    public class Graph : GraphObject
    {
        public List<Vertex> Vertices { get; set; } = new();
        public List<Edge> Edges { get; set; } = new();
        public int Size => Vertices.Count;
    }
}
