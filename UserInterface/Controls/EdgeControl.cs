using LW5.Logic;

namespace LW5.UserInterface
{
    public partial class EdgeControl : UserControl, ISelectable, IDeletable
    {
        public GraphControl? GraphControl { get => Parent as GraphControl; }
        public Edge Edge { get; init; } = new();
        public bool Selected { get; set; }
        public EdgeControl()
        {
            InitializeComponent();
        }

        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphControl?.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Edge.Color = GraphControl.InputColorDialog.Color;
                Refresh();
            }
        }

        public void Delete()
        {
            // check for incident edges referencing this
            GraphControl?.Graph.DeleteEdge(Edge);
            Dispose();
        }
    }
}
