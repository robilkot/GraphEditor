using LW5.Logic;
using Microsoft.VisualBasic;
using System.Numerics;
using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public partial class EdgeControl : GraphObjectControl
    {
        public GraphObjectControl First { get; set; }
        public GraphObjectControl Second { get; set; }
        public EdgeControl()
        {
            InitializeComponent();
        }

        public void Reverse()
        {
            (Second, First) = (First, Second);
            (((Edge)Element).First, ((Edge)Element).Second) = (((Edge)Element).Second, ((Edge)Element).First);
            //Invalidate();
            GraphControl?.Invalidate();
        }
        public void ChangeWeight()
        {
            string newString = Interaction.InputBox(string.Empty, NumberInputWindowTitleText, ((Edge)Element).Weight.ToString() ?? "0");
            if (int.TryParse(newString, out int newWeight))
            {
                ((Edge)Element).Weight = newWeight;
                GraphControl?.Invalidate();
            }
        }

        private void RecalculateBounds()
        {
            if (First == Second)
            {
                // todo: Move those loopy-shit shifts to styles
                Left = First.Center().X - 10;
                Top = First.Center().Y - 10;
                Width = LoopDiameter;
                Height = LoopDiameter;
            }
            else
            {
                // todo: Optimise
                int newWidth = Math.Abs(First.Center().X - Second.Center().X);
                Width = newWidth > EdgeThickness ? newWidth : EdgeThickness;

                int newHeight = Math.Abs(First.Center().Y - Second.Center().Y);
                Height = newHeight > EdgeThickness ? newHeight : EdgeThickness;

                Left = First.Center().X < Second.Center().X ? First.Center().X : Second.Center().X;
                Top = First.Center().Y < Second.Center().Y ? First.Center().Y : Second.Center().Y;
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
            ChangeWeight();
        }
        private void IsOrientedMenuItem_Click(object sender, EventArgs e)
        {
            IsOrientedMenuItem.Checked = !IsOrientedMenuItem.Checked;
            ReverseMenuItem.Enabled = IsOrientedMenuItem.Checked;
            ((Edge)Element).EdgeType = IsOrientedMenuItem.Checked ? EdgeType.Oriented : EdgeType.Unoriented;
            GraphControl?.Invalidate();
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
        private void ReverseMenuItem_Click(object sender, EventArgs e)
        {
            Reverse();
        }
        private void EdgeControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateEdge();
        }
        private void EdgeContextMenu_Opening(object sender, EventArgs e)
        {
            IsOrientedMenuItem.Checked = ((Edge)Element).EdgeType == EdgeType.Oriented;
        }

        public override void Draw(PaintEventArgs e)
        {
            RecalculateBounds();
            var linePoints = (First.Center(), Second.Center());

            using Pen pen = new(Element.Color, EdgeThickness);
            pen.Color = _mouseHovering ? HoverColor : Selected ? SelectedColor : Element.Color;

            // If edge is loop
            if (First == Second)
            {
                // todo: Arrows for loops. Or do we need it? +Text for loops
                e.Graphics.DrawEllipse(pen, Location.X, Location.Y, Width, Height);
            }
            else
            {
                e.Graphics.DrawLine(pen, linePoints.Item1, linePoints.Item2);

                if (((Edge)Element).EdgeType == EdgeType.Oriented)
                {
                    Vector2 edgeDirection = new Vector2(linePoints.Item1.X - linePoints.Item2.X, linePoints.Item1.Y - linePoints.Item2.Y) / 4;

                    var arrowL = Vector2.Transform(edgeDirection, Matrix3x2.CreateRotation(1f / 2));
                    var arrowR = Vector2.Transform(edgeDirection, Matrix3x2.CreateRotation(-1f / 2));
                    arrowL = Vector2.Normalize(arrowL) * 20;
                    arrowR = Vector2.Normalize(arrowR) * 20;

                    var c = this.Center();
                    c.X -= (int)edgeDirection.X;
                    c.Y -= (int)edgeDirection.Y;
                    e.Graphics.DrawLine(pen, c, new Point(c.X + (int)arrowL.X, c.Y + (int)arrowL.Y));
                    e.Graphics.DrawLine(pen, c, new Point(c.X + (int)arrowR.X, c.Y + (int)arrowR.Y));
                }
                TextRenderer.DrawText(e, ((Edge)Element).Weight.ToString(), EdgeWeightFont, new Point(this.Center().X - 5, this.Center().Y - VertexNameFont.Height), Element.Color);
            }
        }
    }
}
