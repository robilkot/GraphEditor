using System.Text.Json.Serialization;

namespace LW5.Logic
{
    [Serializable]
    [JsonDerivedType(typeof(Vertex), typeDiscriminator: "Vertex")]
    [JsonDerivedType(typeof(Edge), typeDiscriminator: "Edge")]
    abstract public class GraphObject
    {
        public string Identifier { get; set; } = string.Empty;
        public Color Color { get; set; } = Color.DimGray;
        public List<Edge> IncidentEdges { get; set; } = new();

        [JsonConstructor]
        public GraphObject() { }
    }
}