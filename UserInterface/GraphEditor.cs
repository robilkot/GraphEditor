using LW5.Logic;
using LW5.UserInterface;

using static LW5.UserInterface.Styles;

namespace LW5
{
    public partial class GraphEditor : Form
    {
        public Graph? ActiveGraph
        {
            get
            {
                return ActiveGraphControl?.Graph;
            }
        }
        public GraphControl? ActiveGraphControl
        {
            get
            {
                if (OpenedFilesTabs.SelectedTab == null) return null;

                if (OpenedFilesTabs.SelectedTab.Controls["graphLayout"] is GraphControl graphControl)
                {
                    return graphControl;
                }
                else return null;
            }
        }
        public GraphEditor()
        {
            InitializeComponent();
        }
        private void CreateNewTab()
        {
            var graphLayout = new GraphControl()
            {
                Dock = DockStyle.Fill,
                Name = "graphLayout"
            };

            TabPage newTab = new()
            {
                Text = DefaultFileName
            };
            newTab.Controls.Add(graphLayout);

            OpenedFilesTabs.TabPages.Add(newTab);
            OpenedFilesTabs.SelectTab(newTab);
        }

        private void GraphEditor_Load(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void CreateMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenedFilesTabs.SelectedTab != null)
            {
                OpenedFilesTabs.TabPages.Remove(OpenedFilesTabs.SelectedTab);
            }
        }

        private void InfoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ProgramDescriptionText, ProgramDescriptionWindowText);
        }

        private void EnableStatisticsMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraphControl != null)
            {
                EnableStatisticsMenuItem.Checked = !EnableStatisticsMenuItem.Checked;
                ActiveGraphControl.DisplayStatistics = EnableStatisticsMenuItem.Checked;
                ActiveGraphControl?.Invalidate();
            }
        }

        private void OpenedFilesTabs_Selected(object sender, TabControlEventArgs e)
        {
            if (ActiveGraphControl != null)
            {
                EnableStatisticsMenuItem.Checked = ActiveGraphControl.DisplayStatistics;
            }
        }

        private void ConnectivityCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraph != null)
            {
                MessageBox.Show(Algorithm.IsStronglyConnected(ActiveGraph).ToString());
            }
        }

        private void WeakConnectivityCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraph != null)
            {
                MessageBox.Show(Algorithm.IsWeaklyConnected(ActiveGraph).ToString());
            }
        }

        private void EulerCheckMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraph != null)
            {
                MessageBox.Show(Algorithm.IsEuler(ActiveGraph).ToString());
            }
        }

        private void FindEulerCycleMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraph != null)
            {
                var path = Algorithm.EulerCycle(ActiveGraph);
                if (path.Count == 0)
                {
                    MessageBox.Show("Граф не содержит эйлеров цикл");
                    return;
                }

                var viewer = new ResultViewer();
                viewer.SetContent(path);
                viewer.Show();
            }
        }

        private void FindRouteMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraph != null)
            {
                if (ActiveGraphControl.Selected.Count >= 2 &&
                    ActiveGraphControl.Selected[0] is VertexControl vc1 &&
                    ActiveGraphControl.Selected[1] is VertexControl vc2)
                {
                    var path = Algorithm.Dijkstra(ActiveGraph, (Vertex)vc1.Element, (Vertex)vc2.Element);
                    if (path.Count < 1)
                    {
                        MessageBox.Show("Маршрут между вершинами не найден");
                        return;
                    }

                    var viewer = new ResultViewer();
                    viewer.SetContent(path);
                    viewer.Show();

                    return;
                }
                MessageBox.Show("Первые два выделенных элемента должны быть начальной и конечной точкой маршрута");
                return;
            }
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (ActiveGraphControl != null)
            {
                if (SaveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FileSystem.FileSystem.SaveToFile(new(ActiveGraphControl), SaveFileDialog.FileName);
                }
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var graphRecord = FileSystem.FileSystem.ReadFromFile(OpenFileDialog.FileName);
                CreateNewTab();
                ActiveGraphControl.SetGraph(graphRecord);
            }
        }
    }
}