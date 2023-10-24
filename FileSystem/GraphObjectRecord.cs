using LW5.Logic;
using LW5.UserInterface;
using System.Text.Json.Serialization;

namespace LW5.FileSystem
{
    [Serializable]
    public class GraphObjectRecord
    {
        public GraphObject GraphObject { get; set; }
        public Point Location { get; set; }

        [JsonConstructor]
        public GraphObjectRecord() { }
        public GraphObjectRecord(GraphObjectControl graphObjectControl)
        {
            GraphObject = graphObjectControl.Element;
            Location = graphObjectControl.Location;
        }
    }
}
