namespace LW5.Logic
{
    [Serializable]
    public class Vertex : GraphObject
    {
        private const string DefaultName = "Vertex";
        public VertexType VertexType = VertexType.Default;
        public int Degree => IncidentEdges.Count;

        public Vertex()
        {
            Identifier = DefaultName;
        }
    }
}
