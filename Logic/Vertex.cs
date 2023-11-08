using System.Text.Json.Serialization;

namespace LW5.Logic
{
    [Serializable]
    public class Vertex : GraphObject
    {
        private const string DefaultName = "Vertex";
        public VertexType VertexType = VertexType.Default;
        [JsonIgnore]
        public int Degree => IncidentEdges.Count;
        [JsonIgnore]
        public List<Vertex> AdjacentVertices
        {
            get
            {
                List<Vertex> adjacent = new();

                foreach (var e in IncidentEdges)
                {
                    if (e.EdgeType == EdgeType.Unoriented)
                    {
                        if (e.First == this && e.Second == this)
                        {
                            adjacent.Add(this);
                        }
                        else
                        {
                            if (e.First != this && e.Second is Vertex v1)
                            {
                                adjacent.Add(v1);
                            }
                            else if (e.Second != this && e.First is Vertex v2)
                            {
                                adjacent.Add(v2);
                            }
                        }
                    }

                    if (e.EdgeType == EdgeType.Oriented)
                    {
                        if (e.First == this && e.Second is Vertex v)
                        {
                            adjacent.Add(v);
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
