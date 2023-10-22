using LW5.Logic;
using System.Drawing.Drawing2D;
using System.Windows.Forms.VisualStyles;
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

        private bool _selecting = false;
        private Rectangle _selectionRectangle = new();

        private EdgeControl _edgeControlToBeCreated = new();
        private bool _creatingEdge = false;
        public bool CreatingEdge { get => _creatingEdge; }
        public bool DisplayStatistics { get; set; } = false;

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

        // todo: When implement filesystem, adapt this to work with real graphs and restoring vertices locations
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
                }
            }
            Invalidate();
        }
        public void DeselectAll()
        {
            foreach (var selected in Selected)
            {
                selected.Selected = false;
                //((UserControl)selected).Invalidate();
            }
            Invalidate();
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
        public void StartCreatingEdge(VertexControl sourceControl)
        {
            _creatingEdge = true;

            Edge edge = new()
            {
                First = sourceControl.Element
            };

            _edgeControlToBeCreated = new()
            {
                First = sourceControl,
                Element = edge,
                Location = sourceControl.Location
            };

            sourceControl.IncidentEdgeControls.Add(_edgeControlToBeCreated);
        }

        public void FinishCreatingEdge(GraphObjectControl destinationControl)
        {
            if (_creatingEdge)
            {
                ((Edge)_edgeControlToBeCreated.Element).Second = destinationControl.Element;
                _edgeControlToBeCreated.Second = destinationControl;

                destinationControl.Element?.IncidentEdges.Add((Edge)_edgeControlToBeCreated.Element);
                destinationControl.IncidentEdgeControls.Add(_edgeControlToBeCreated);

                // todo: This works only when creating edge from vertex, not from another edge
                _edgeControlToBeCreated.First?.Element?.IncidentEdges.Add((Edge)_edgeControlToBeCreated.Element);
                _graph.Add(_edgeControlToBeCreated.Element);

                Controls.Add(_edgeControlToBeCreated);
                _creatingEdge = false;

                Invalidate();
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
            }
            if (e.Button == MouseButtons.Left || _creatingEdge)
            {
                _mouseCurrentLocation = e.Location;
                Invalidate();
            }
        }

        private void GraphControl_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

            if (_creatingEdge)
            {
                using var pen = new Pen(CreatingEdgeColor, EdgeThickness) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                e.Graphics.DrawLine(
                pen,
                _edgeControlToBeCreated.First.Center(),
                _mouseCurrentLocation
                );
            }

            // todo: Two cycles to render vertices after edges. Screw that
            foreach (UserControl control in Controls)
            {
                if (control is EdgeControl)
                {
                    ((IDrawable)control).Draw(e);
                }
            }
            foreach (UserControl control in Controls)
            {
                if (control is VertexControl)
                {
                    ((IDrawable)control).Draw(e);
                }
            }

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

            if(DisplayStatistics)
            {
                string stats = string.Format(GraphStatisticsText,
                    _graph.Vertices.Count,
                    _graph.Edges.Count,
                    _graph.Loops.Count,
                    Selected.Where(s => s is VertexControl).Count(),
                    Selected.Where(s => s is EdgeControl).Count()
                    );
                TextRenderer.DrawText(e, stats, StatisticsFont, new Point(20, 20), StatisticsFontColor);
            }
        }

        private void GraphControl_MouseDown(object sender, MouseEventArgs e)
        {
            _mouseDownLocation = e.Location;
            _mouseCurrentLocation = e.Location;

            if (e.Button == MouseButtons.Right)
            {
                _creatingEdge = false;
            }
        }

        private void GraphControl_MouseUp(object sender, MouseEventArgs e)
        {

            if (_selecting)
            {
                if (ModifierKeys.HasFlag(Keys.Control))
                {
                    foreach (var selected in Selected)
                    {
                        if (_selectionRectangle.IntersectsWith(((UserControl)selected).Bounds))
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
                            if (_selectionRectangle.IntersectsWith(control.Bounds))
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

        private void GraphControl_MouseClick(object sender, MouseEventArgs e)
        {
            if (ModifierKeys.HasFlag(Keys.Shift) == false && ModifierKeys.HasFlag(Keys.Control) == false)
            {
                DeselectAll();
            }
        }
    }
}
