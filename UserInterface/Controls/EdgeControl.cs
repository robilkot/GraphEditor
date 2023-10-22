using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public partial class EdgeControl : GraphObjectControl
    {
        public GraphObjectControl? First { get; set; }
        public GraphObjectControl? Second { get; set; }
        public EdgeControl()
        {
            InitializeComponent();
        }

        public void Reverse()
        {
            (Second, First) = (First, Second);
            Invalidate();
        }
        private void EdgeControl_Paint(object sender, PaintEventArgs e)
        {
            if (First == Second)
            {
                // todo: Move that loopy-shit to styles
                Left = First.Center().X - 10;
                Top = First.Center().Y - 10;
                Width = 50;
                Height = 50;
            }
            else
            {
                int newWidth = Math.Abs(First.Left - Second.Left);
                Width = newWidth > 0 ? newWidth : 1;

                int newHeight = Math.Abs(First.Top - Second.Top);
                Height = newHeight > 0 ? newHeight : 1;

                Left = First.Left < Second.Left ? First.Center().X : Second.Center().X;
                Top = First.Top < Second.Top ? First.Center().Y : Second.Center().Y;
            }
        }
        private void EdgeControl_MouseDown(object sender, MouseEventArgs e)
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

            Invalidate();
        }
        private void EdgeControl_MouseEnter(object sender, EventArgs e)
        {
            _mouseHovering = true;
            GraphControl?.Invalidate();
        }
        private void EdgeControl_MouseLeave(object sender, EventArgs e)
        {
            _mouseHovering = false;
            GraphControl?.Invalidate();
        }
        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            ChangeColor();
        }
        private void RenameMenuItem_Click(object sender, EventArgs e)
        {
            Rename();
        }
        private void ChangeWeightMenuItem_Click(object sender, EventArgs e)
        {
            // todo: Input number dialog
        }
        
        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void ReverseMenuItem_Click(object sender, EventArgs e)
        {
            Reverse();
        }

        public override void Draw(PaintEventArgs e)
        {
            var linePoints = (First.Center(), Second.Center());
            using (Pen pen = new(Element.Color, EdgeThickness))
            {
                pen.Color = _mouseHovering ? HoverColor : Selected ? SelectedColor : Element.Color;


                if (First == Second)
                {
                    e.Graphics.DrawEllipse(pen, Location.X, Location.Y, Width, Height);
                }
                else
                {
                    e.Graphics.DrawLine(pen, linePoints.Item1, linePoints.Item2);
                }
            }
            // todo: Differentiate between oriented and non-oriented edges
        }
    }
}
