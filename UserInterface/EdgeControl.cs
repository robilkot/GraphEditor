using LW5.Logic;

namespace LW5.UserInterface
{
    public partial class EdgeControl : UserControl, ISelectable, IDeletable
    {
        public Edge Edge { get; init; } = new();
        public bool Selected { get; set; }
        public EdgeControl()
        {
            InitializeComponent();
        }

        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.GraphEditor.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Edge.Color = Program.GraphEditor.InputColorDialog.Color;
                Refresh();
            }
        }

        public void Delete()
        {
            // check for incident edges referencing this
            Program.GraphEditor.ActiveGraph?.DeleteEdge(Edge);
            Dispose();
        }
    }
}
