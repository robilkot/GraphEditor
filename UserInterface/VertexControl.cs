using LW5.Logic;
using LW5.UserInterface;

namespace LW5
{
    [Serializable]
    public partial class VertexControl : UserControl, ISelectable, IDeletable
    {
        public Vertex Vertex { get; init; } = new();
        public bool Selected { get; set; }

        private Point MouseDownLocation;
        public VertexControl()
        {
            InitializeComponent();
        }

        public VertexControl(Vertex vertex)
        {
            InitializeComponent();
            Vertex = vertex;
        }

        private void VertexControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (Control.ModifierKeys.HasFlag(Keys.Shift) == false)
            {
                Program.GraphEditor.ActiveGraphControl?.DeselectAll();
            }

            Selected = !Selected;

            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }

            Invalidate();
        }
        private void VertexControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Left += e.Location.X - MouseDownLocation.X;
                Top += e.Location.Y - MouseDownLocation.Y;
            }
        }
        private void VertexControl_Paint(object sender, PaintEventArgs e)
        {
            BackColor = Selected ? Color.CadetBlue : Vertex.Color;
        }
        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if(Program.GraphEditor.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Vertex.Color = Program.GraphEditor.InputColorDialog.Color;
                Invalidate();
            }
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Delete()
        {
            // check for incident edges referencing this
            Program.GraphEditor.ActiveGraph?.DeleteVertex(Vertex);
            Dispose();
        }
    }
}
