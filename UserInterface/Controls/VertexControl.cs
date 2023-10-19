using LW5.Logic;
using LW5.UserInterface;
using System.Drawing.Drawing2D;
using System.Reflection;

namespace LW5
{
    [Serializable]
    public partial class VertexControl : UserControl, ISelectable, IDeletable
    {
        public GraphControl? GraphControl { get => Parent as GraphControl; }
        public Vertex Vertex { get; set; } = new();
        public bool Selected { get; set; }

        private Point MouseDownLocation;
        public VertexControl()
        {
            InitializeComponent();
            Width = Styles.VertexDiameter;
            Height = Styles.VertexDiameter;

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            VertexIcon, new object[] { true });
        }

        private void VertexControl_MouseDown(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) == false)
            {
                GraphControl?.DeselectAll();
            }

            Selected = !Selected;

            if (e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }

            VertexIcon.Invalidate();
        }
        private void VertexControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                foreach (var selectedControl in GraphControl.Selected)
                {
                    if (selectedControl is UserControl selected)
                    {
                        selected.Left += e.Location.X - MouseDownLocation.X;
                        selected.Top += e.Location.Y - MouseDownLocation.Y;
                    }
                }

                Selected = true;
                VertexIcon.Invalidate();
            }
        }
        private void VertexControl_Paint(object sender, PaintEventArgs e)
        {
            //VertexIcon.Invalidate();
        }
        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphControl?.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Vertex.Color = GraphControl.InputColorDialog.Color;
                VertexIcon.Invalidate();
            }
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }

        public void Delete()
        {
            // check for incident edges referencing this
            GraphControl?.Graph.DeleteVertex(Vertex);
            Dispose();
        }

        private void VertexIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle drawingBounds = new(
                Styles.SelectionThickness / 2,
                Styles.SelectionThickness / 2,
                VertexIcon.Width - Styles.SelectionThickness - 1,
                VertexIcon.Height - Styles.SelectionThickness - 1);

            e.Graphics.FillEllipse(
                    new SolidBrush(Vertex.Color),
                    //new Pen(Vertex.Color, Styles.VertexBoundsThickness),
                    drawingBounds
                    );

            if (Selected)
            {
                e.Graphics.DrawEllipse(
                    new Pen(Styles.SelectedColor, Styles.SelectionThickness),
                    drawingBounds
                    );
            }
        }
    }
}
