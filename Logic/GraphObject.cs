namespace LW5.Logic
{
    [Serializable]
    abstract public class GraphObject
    {
        public string Identifier { get; set; } = string.Empty;
        public Color Color { get; set; } = Color.DimGray;
        public List<Edge> IncidentEdges { get; set; } = new();
    }
}