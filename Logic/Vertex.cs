using System.Text.Json.Serialization;

namespace LW5.Logic
{
    [Serializable]
    public class Vertex : GraphObject
    {
        private const string DefaultName = "Vertex";
        public VertexType VertexType = VertexType.Default;
        public int Degree => IncidentEdges.Count;

        public List<Vertex> AdjacentVertices
        {
            get
            {
                List<Vertex> adjacent = new();

                foreach (var e in IncidentEdges)
                {
                    if (e.Second is Vertex v2 && v2 != this)
                    {
                        adjacent.Add(v2);
                    }
                    if (e.EdgeType == EdgeType.Unoriented)
                    {
                        if (e.First is Vertex v1 && v1 != this)
                        {
                            adjacent.Add(v1);
                        }
                    }
                }

                return adjacent.ToList();
            }
        }


        [JsonConstructor]
        public Vertex()
        {
            Identifier = DefaultName;
        }
    }
}
