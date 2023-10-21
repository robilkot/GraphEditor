using Microsoft.VisualBasic;
using System.Reflection;

using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    [Serializable]
    public partial class VertexControl : GraphObjectControl
    {
        private Point _mouseDownLocation;

        public List<EdgeControl> IncidentEdgeControls { get; set; } = new();
        public VertexControl()
        {
            InitializeComponent();
            Width = VertexDiameter;
            Height = VertexDiameter;

            //typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            //| BindingFlags.Instance | BindingFlags.NonPublic, null,
            //VertexIcon, new object[] { true });
        }
        private void UpdateToolTip()
        {
            string newText = string.Format(VertexToolTipText, Element.Color.ToRGBString());
            VertexToolTip.ToolTipTitle = Element.Identifier;

            VertexToolTip.SetToolTip(VertexIcon, newText);
        }

        private void CreateEdge()
        {
            GraphControl?.StartCreatingEdge(this);
            UpdateToolTip();
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

                if (GraphControl.CreatingEdge)
                {
                    GraphControl.FinishCreatingEdge(this);
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
        //private void VertexControl_Paint(object sender, PaintEventArgs e)
        //{
        //    foreach (EdgeControl control in IncidentEdgeControls)
        //    {
        //        control.Invalidate();
        //    }
        //}
        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphControl?.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Element.Color = GraphControl.InputColorDialog.Color;
                VertexIcon.Invalidate();
                UpdateToolTip();
            }
        }
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        //private void VertexIcon_Paint(object sender, PaintEventArgs e)
        //{
        //    //e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

        //    //GraphControl.Invalidate();
        //    //Draw(e);
        //}

        public override void Draw(PaintEventArgs e)
        {
            Rectangle drawingBounds = new(
                Location.X + SelectionThickness / 2,
                Location.Y + SelectionThickness / 2,
                VertexIcon.Width - SelectionThickness - 1,
                VertexIcon.Height - SelectionThickness - 1);

            using (SolidBrush brush = new(Element.Color))
            {
                e.Graphics.FillEllipse(
                            brush,
                            drawingBounds
                            );
            }

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
            Element.Identifier = Interaction.InputBox(string.Empty, VertexRenameWindowTitleText, Element.Identifier);
            UpdateToolTip();
        }

        private void CreateEdgeMenuItem_Click(object sender, EventArgs e)
        {
            CreateEdge();
        }
        private void VertexControl_MouseEnter(object sender, EventArgs e)
        {
            _mouseHovering = true;
            Invalidate();

            UpdateToolTip();
        }

        private void VertexControl_MouseLeave(object sender, EventArgs e)
        {
            _mouseHovering = false;
            Invalidate();
        }

        private void VertexControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateEdge();
        }
    }
}
