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
        public bool CreatingEdge { get; private set; } = false;

        public GraphControl()
        {
            InitializeComponent();
        }

        // todo: adapt this to work with real graphs and restoring vertices locations
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
        public void CreateVertex(Point location)
        {
            Vertex vertex = new();
            _graph.Vertices.Add(vertex);

            var control = new VertexControl()
            {
                Vertex = vertex,
                Location = location
            };

            Controls.Add(control);
        }

        public void CreateEdge(VertexControl vertexControl)
        {
            CreatingEdge = true;

            Edge edge = new();
            _graph.Edges.Add(edge);

            edge.First = vertexControl.Vertex;
            edge.Second = vertexControl.Vertex;

            var control = new EdgeControl()
            {
                Edge = edge,
                Location = vertexControl.Location
            };

            Controls.Add(control);
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

        private void GraphControl_Click(object sender, EventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) == false)
            {
                DeselectAll();
            }
        }

        private void GraphControl_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            CreateVertex(e.Location);
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
