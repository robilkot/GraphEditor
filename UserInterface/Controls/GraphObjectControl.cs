using LW5.Logic;
using Microsoft.VisualBasic;
using LW5.Interfaces;

using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public abstract class GraphObjectControl : UserControl, ISelectable, IDeletable, IDrawable
    {
        public GraphControl GraphControl { get => Parent as GraphControl; }
        public GraphObject Element { get; set; }
        public List<EdgeControl> IncidentEdgeControls { get; set; } = new();

        public bool Selected { get; set; }
        protected bool _mouseHovering = false;
        public virtual void Delete()
        {
            foreach (var incident in IncidentEdgeControls)
            {
                incident.Delete();
            }
            GraphControl?.Remove(this);
            Dispose();
        }
        public virtual void Rename()
        {
            string newString = Interaction.InputBox(string.Empty, RenameWindowTitleText, Element?.Identifier ?? DefaultElementName);
            if (newString.Length > 0) Element.Identifier = newString;
        }
        public virtual void CreateEdge()
        {
            GraphControl?.StartCreatingEdge(this);
        }
        public virtual void ChangeColor()
        {
            if (GraphControl?.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Element.Color = GraphControl.InputColorDialog.Color;
                Invalidate();
            }
        }
        public abstract void Draw(PaintEventArgs e);
    }
}
