namespace LW5.Logic
{
    [Serializable]
    public class Graph
    {
        public List<GraphObject> Elements { get; set; } = new();
        public int Size => Elements.Where(e => e is Vertex).Count();

        public void Add(GraphObject graphObject)
        {
            Elements.Add(graphObject);
        }
        public void Remove(GraphObject graphObject)
        {
            Elements.Remove(graphObject);
            Elements.RemoveAll(e => e is Edge edge && (edge.First == graphObject || edge.Second == graphObject));
        }
    }
}
