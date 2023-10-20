﻿namespace LW5.Logic
{
    [Serializable]
    public class Graph : GraphObject
    {
        public List<Vertex> Vertices { get; set; } = new();
        public List<Edge> Edges { get; set; } = new();
        public int Size => Vertices.Count;

        public void DeleteVertex(Vertex vertex)
        {
            Vertices.Remove(vertex);
            Edges.RemoveAll(e=> e.First == vertex || e.Second == vertex);
        }

        public void DeleteEdge(Edge edge)
        {
            Edges.Remove(edge);
            Edges.RemoveAll(e => e.First == edge || e.Second == edge);
        }
    }
}
