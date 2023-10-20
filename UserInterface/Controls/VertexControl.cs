using LW5.Logic;
using LW5.UserInterface;
using Microsoft.VisualBasic;
using System.Drawing.Drawing2D;
using System.Reflection;

using static LW5.UserInterface.Styles;

namespace LW5
{
    [Serializable]
    public partial class VertexControl : UserControl, ISelectable, IDeletable
    {
        public GraphControl? GraphControl { get => Parent as GraphControl; }
        public Vertex Vertex { get; set; } = new();
        public bool Selected { get; set; }
        private bool _mouseHovering = false;

        private Point _mouseDownLocation;
        public VertexControl()
        {
            InitializeComponent();
            Width = VertexDiameter;
            Height = VertexDiameter;
            UpdateToolTip();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            VertexIcon, new object[] { true });
        }
        public void Delete()
        {
            // check for incident edges referencing this
            GraphControl?.Graph.DeleteVertex(Vertex);
            Dispose();
        }

        private void UpdateToolTip()
        {
            string newText = string.Format(VertexToolTipText, Vertex.Color.ToRGBString());
            VertexToolTip.ToolTipTitle = Vertex.Identifier;

            VertexToolTip.SetToolTip(VertexIcon, newText);
        }
        private void VertexControl_MouseDown(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Right)
            {
                if (ModifierKeys.HasFlag(Keys.Shift) == false)
                {
                    GraphControl?.DeselectAll();
                }

                Selected = true;
            }

            if (e.Button == MouseButtons.Left)
            {
                _mouseDownLocation = e.Location;

                if (ModifierKeys.HasFlag(Keys.Shift) == true)
                {
                    Selected = !Selected;
                }
                else
                {
                    GraphControl?.DeselectAll();
                    Selected = true;
                }
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
                        selected.Left += e.Location.X - _mouseDownLocation.X;
                        selected.Top += e.Location.Y - _mouseDownLocation.Y;
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
                UpdateToolTip();
            }
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void VertexIcon_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            Rectangle drawingBounds = new(
                SelectionThickness / 2,
                SelectionThickness / 2,
                VertexIcon.Width - SelectionThickness - 1,
                VertexIcon.Height - SelectionThickness - 1);

            e.Graphics.FillEllipse(
                    new SolidBrush(Vertex.Color),
                    //new Pen(Vertex.Color, Styles.VertexBoundsThickness),
                    drawingBounds
                    );

            if (_mouseHovering)
            {
                e.Graphics.DrawEllipse(
                        new Pen(HoverColor, SelectionThickness),
                        drawingBounds
                        );
            }

            if (Selected)
            {
                e.Graphics.DrawEllipse(
                    new Pen(SelectedColor, SelectionThickness),
                    drawingBounds
                    );
            }
        }
        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            Vertex.Identifier = Interaction.InputBox(string.Empty, VertexRenameWindowTitleText, Vertex.Identifier);
            UpdateToolTip();
        }

        private void CreateEdgeMenuItem_Click(object sender, EventArgs e)
        {
            GraphControl.CreateEdge(this);
            UpdateToolTip();
        }

        private void VertexControl_MouseEnter(object sender, EventArgs e)
        {
            _mouseHovering = true;
            Invalidate();
        }

        private void VertexControl_MouseLeave(object sender, EventArgs e)
        {
            _mouseHovering = false;
            Invalidate();
        }
    }
}
