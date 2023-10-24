using LW5.UserInterface;
using System.Text.Json.Serialization;
using LW5.Logic;

namespace LW5.FileSystem
{
    [Serializable]
    public class GraphRecord
    {
        public List<GraphObjectRecord> GraphObjects { get; set; } = new();

        [JsonConstructor]
        public GraphRecord() { }
        public GraphRecord(GraphControl graphControl)
        {
            foreach(var graphObjectControl in graphControl.Controls.OfType<GraphObjectControl>())
            {
                GraphObjects.Add(new(graphObjectControl));
            }
        }
    }
}
