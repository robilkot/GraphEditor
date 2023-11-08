using LW5.FileSystem;
using LW5.Logic;
using System.Drawing.Drawing2D;
using LW5.Interfaces;

using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public partial class GraphControl : UserControl
    {
        public List<ISelectable> Selected
        {
            get
            {
                return (from c in Controls.OfType<ISelectable>()
                        where c.Selected == true
                        select c).ToList();
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
        }

        public void SetGraph(GraphRecord graphRecord)
        {
            Controls.Clear();
            _graph = new();
            _graph.Elements.AddRange(from obj in graphRecord.GraphObjects
                                     select obj.GraphObject);

            foreach (var obj in graphRecord.GraphObjects)
            {
                // Bruh, sOlid has left chat
                GraphObjectControl newControl;
                if (obj.GraphObject is Vertex)
                {
                    newControl = new VertexControl();
                }
                else
                {
                    newControl = new EdgeControl();
                }

                newControl.Location = obj.Location;
                newControl.Element = obj.GraphObject;

                Controls.Add(newControl);
            }

            // Before these lines only elements in graph are linked, not their controls
            foreach (var edge in Controls.OfType<EdgeControl>())
            {
                foreach (var c in Controls.OfType<GraphObjectControl>())
                {
                    if (c.Element == ((Edge)edge.Element).First)
                    {
                        edge.First = c;
                    }
                    if (c.Element == ((Edge)edge.Element).Second)
                    {
                        edge.Second = c;
                    }
                    if (c.Element == ((Edge)edge.Element).Second || c.Element == ((Edge)edge.Element).First)
                    {
                        c.IncidentEdgeControls.Add(edge);
                    }
                }
            }
        }

        public GraphControl()
        {
            InitializeComponent();
        }

        public void SelectAll()
        {
            foreach (var control in Controls.OfType<UserControl>())
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

            Invalidate();
        }
        public void StartCreatingEdge(GraphObjectControl sourceControl)
        {
            _creatingEdge = true;

            _edgeControlToBeCreated = new()
            {
                First = sourceControl,
                Element = new Edge() { First = sourceControl.Element },
                Location = sourceControl.Location
            };
        }

        public void FinishCreatingEdge(GraphObjectControl destinationControl)
        {
            if (_creatingEdge)
            {
                ((Edge)_edgeControlToBeCreated.Element).Second = destinationControl.Element;
                _edgeControlToBeCreated.Second = destinationControl;

                destinationControl.IncidentEdgeControls.Add(_edgeControlToBeCreated);
                destinationControl.Element.IncidentEdges.Add((Edge)_edgeControlToBeCreated.Element);

                _edgeControlToBeCreated.First.IncidentEdgeControls.Add(_edgeControlToBeCreated);
                _edgeControlToBeCreated.First.Element.IncidentEdges.Add((Edge)_edgeControlToBeCreated.Element);

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
            foreach (var element in Selected.OfType<IDeletable>())
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
            foreach (var control in Controls.OfType<EdgeControl>())
            {
                ((IDrawable)control).Draw(e);
                //e.Graphics.DrawRectangle(Pens.Black, control.Bounds); // DEBUG
            }
            foreach (var control in Controls.OfType<VertexControl>())
            {
                ((IDrawable)control).Draw(e);
            }
            //foreach (var control in Controls.OfType<IDrawable>())
            //{
            //    control.Draw(e);
            //}

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

            if (DisplayStatistics)
            {
                string stats = string.Format(GraphStatisticsText,
                    _graph.Vertices.Count,
                    _graph.Edges.Count,
                    _graph.Loops.Count,
                    Selected.OfType<VertexControl>().Count(),
                    Selected.OfType<EdgeControl>().Count()
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
                    foreach (var control in Controls.OfType<ISelectable>())
                    {
                        if (_selectionRectangle.IntersectsWith(((UserControl)control).Bounds))
                        {
                            control.Selected = true;
                        };
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
