using LW5.Logic;

namespace LW5.UserInterface
{
    [Serializable]
    public partial class GraphControl : UserControl
    {
        public List<ISelectable> Selected
        {
            get
            {
                List<ISelectable> selected = new();

                foreach (var control in Controls)
                {
                    if (control is ISelectable selectable)
                    {
                        if (selectable.Selected == true)
                        {
                            selected.Add(selectable);
                        }
                    }
                }

                return selected;
            }
        }
        private Graph _graph = new();
        public Graph Graph
        {
            get => _graph;
            set
            {
                _graph = value;

                InitializeControls();
            }
        }

        public GraphControl()
        {
            InitializeComponent();
        }
        private void InitializeControls()
        {
            Controls.Clear();
            Point newControlLocation = new(Width / 2, Height / 2);

            foreach (var vertex in _graph.Vertices)
            {
                var control = new VertexControl();
                control.Vertex = vertex;

                control.Location = newControlLocation;
                Controls.Add(control);

                newControlLocation.X += 50;
                newControlLocation.Y += 50;
            }
        }

        private void CreateVertexMenuItem_Click(object sender, EventArgs e)
        {
            var layoutLocation = PointToScreen(Location);
            Point location = new(LayoutContextMenu.Left - layoutLocation.X, LayoutContextMenu.Top - layoutLocation.Y);

            CreateVertex(location);
        }

        private void SelectAllMenuItem_Click(object sender, EventArgs e)
        {
            SelectAll();
        }

        // Deselects all elements
        private void GraphControl_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) == false)
            {
                DeselectAll();
            }
        }
        public void SelectAll()
        {
            foreach (Control control in Controls)
            {
                if (control is ISelectable graphElement)
                {
                    graphElement.Selected = true;
                    control.Invalidate();
                }
            }
        }
        public void DeselectAll()
        {
            foreach (Control control in Controls)
            {
                if (control is ISelectable graphElement)
                {
                    graphElement.Selected = false;
                    control.Invalidate();
                }
            }
        }

        private void GraphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateVertex(e.Location);
        }

        private void CreateVertex(Point location)
        {
            Vertex vertex = new();
            _graph.Vertices.Add(vertex);

            var control = new VertexControl();
            control.Vertex = vertex;
            control.Location = location;

            Controls.Add(control);
        }

        private void DeleteSelectedMenuItem_Click(object sender, EventArgs e)
        {
            List<IDeletable> toDelete = new();

            foreach (var graphObject in Selected)
            {
                if (graphObject is IDeletable graphElement)
                {
                    toDelete.Add(graphElement);
                }
            }

            foreach (var element in toDelete)
            {
                element.Delete();
            }
        }
    }
}
