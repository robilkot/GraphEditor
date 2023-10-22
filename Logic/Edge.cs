﻿namespace LW5.Logic
{
    [Serializable]
    public class Edge : GraphObject
    {
        private const string DefaultName = "Edge";
        public EdgeType EdgeType { get; set; } = EdgeType.Oriented;
        public int Weight { get; set; } = 0;

        public GraphObject? First { get; set; } = null;
        public GraphObject? Second { get; set; } = null;

        public Edge() {
            Identifier = DefaultName;
        }
    }
}
