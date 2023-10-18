namespace LW5.Logic
{
    [Serializable]
    public class Vertex : GraphObject
    {
        public VertexType VertexType = VertexType.Default;
        public List<Edge> IncidentEdges { get; set; } = new();
        public PointF Location { get; set; } = new();
        public int Degree => IncidentEdges.Count;
    }
}
