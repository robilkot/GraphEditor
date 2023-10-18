namespace LW5.Logic
{
    [Serializable]
    public class Edge : GraphObject
    {
        public EdgeType EdgeType { get; set; } = EdgeType.Default;
        public int Weight { get; set; } = 0;
        public Tuple<GraphObject, GraphObject>? ConnectedObjects { get; set; } = null;
        public bool ReversedDirection { get; set; } = false;
    }
}
