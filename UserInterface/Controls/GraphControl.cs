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

            foreach (var element in _graph.Elements)
            {
                GraphObjectControl control;

                if (element is Vertex)
                {
                    control = new VertexControl()
                    {
                        Element = element
                    };
                }// else if(element is Edge)
                else
                {
                    control = new EdgeControl()
                    {
                        Element = element
                    };
                }

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
            _graph.Add(vertex);

            var control = new VertexControl()
            {
                Element = vertex,
                Location = location
            };

            Controls.Add(control);
        }

        public void Remove(GraphObjectControl control)
        {
            Controls.Remove(control);
            _graph.Remove(control.Element);
        }
        public void CreateEdge(GraphObjectControl control)
        {
            CreatingEdge = true;

            Edge edge = new();
            _graph.Add(edge);

            edge.First = control.Element;
            edge.Second = control.Element;

            var edgeControl = new EdgeControl()
            {
                Element = edge,
                Location = control.Location
            };

            Controls.Add(edgeControl);
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
