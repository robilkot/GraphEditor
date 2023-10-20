using LW5.Logic;
using static LW5.UserInterface.Styles;

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

        private Point _mouseDownLocation;
        private Point _mouseCurrentLocation;
        private bool _selecting;
        private Rectangle _selectionRectangle = new();

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
            foreach (UserControl control in Controls)
            {
                if (control is ISelectable selectable)
                {
                    selectable.Selected = true;
                    control.Invalidate();
                }
            }
        }
        public void DeselectAll()
        {
            foreach (var selected in Selected)
            {
                selected.Selected = false;
                ((UserControl)selected).Invalidate();
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
        public void CreateEdge(GraphObjectControl sourceControl)
        {
            //CreatingEdge = true;

            //Edge edge = new();

            //_graph.Add(edge);
            //((Vertex)sourceControl.Element).IncidentEdges.Add(edge);

            //edge.First = sourceControl.Element;
            //edge.Second = sourceControl.Element;

            //var edgeControl = new EdgeControl()
            //{
            //    Element = edge,
            //    Location = sourceControl.Location
            //};

            //Controls.Add(edgeControl);
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
            if (ModifierKeys.HasFlag(Keys.Shift) == false && ModifierKeys.HasFlag(Keys.Control) == false)
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

        private void GraphControl_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _selecting = true;

                _mouseCurrentLocation = e.Location;

                _selectionRectangle.X = _mouseDownLocation.X < _mouseCurrentLocation.X ? _mouseDownLocation.X : _mouseCurrentLocation.X;
                _selectionRectangle.Y = _mouseDownLocation.Y < _mouseCurrentLocation.Y ? _mouseDownLocation.Y : _mouseCurrentLocation.Y;

                _selectionRectangle.Width = Math.Abs(_mouseCurrentLocation.X - _mouseDownLocation.X);
                _selectionRectangle.Height = Math.Abs(_mouseCurrentLocation.Y - _mouseDownLocation.Y);

                Invalidate();
            }
        }

        private void GraphControl_Paint(object sender, PaintEventArgs e)
        {

            if (_selecting)
            {
                e.Graphics.FillRectangle(
                    SelectionRectangleBrush,
                    _selectionRectangle
                    ); ;

                e.Graphics.DrawRectangle(
                    new Pen(SelectionRectangleColor),
                    _selectionRectangle
                    );
            }
        }

        private void GraphControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _mouseCurrentLocation = e.Location;
        }

        private void GraphControl_MouseUp(object sender, MouseEventArgs e)
        {

            if (_selecting)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    foreach (var selected in Selected)
                    {
                        if (_selectionRectangle.Contains(((UserControl)selected).Bounds))
                        {
                            selected.Selected = false;
                        };
                    }
                }
                else
                {
                    foreach (UserControl control in Controls)
                    {
                        if (control is ISelectable selectable)
                        {
                            if (_selectionRectangle.Contains(control.Bounds))
                            {
                                selectable.Selected = true;
                            };
                        }
                    }

                }
            }
            _selecting = false;

            Invalidate();
        }
    }
}
