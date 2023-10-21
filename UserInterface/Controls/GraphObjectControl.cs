using LW5.Logic;

namespace LW5.UserInterface
{
    public abstract class GraphObjectControl : UserControl, ISelectable, IDeletable, IDrawable
    {

        public GraphControl? GraphControl { get => Parent as GraphControl; }
        public GraphObject? Element { get; set; }
        public bool Selected { get; set; }
        protected bool _mouseHovering = false;
        public virtual void Delete()
        {
            GraphControl?.Remove(this);
            Dispose();
        }

        private void InitializeComponent()
        {
            SuspendLayout();
            // 
            // GraphObjectControl
            // 
            Name = "GraphObjectControl";
            ResumeLayout(false);
        }

        public abstract void Draw(PaintEventArgs e);
    }
}
