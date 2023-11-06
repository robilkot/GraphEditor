using LW5.FileSystem;
using LW5.Logic;
using LW5.Logic.Commands;
using LW5.UserInterface;

using static LW5.UserInterface.Styles;

namespace LW5
{
    public partial class GraphEditor : Form
    {
        private Invoker _invoker = new();
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

                return OpenedFilesTabs.SelectedTab.Controls["graphLayout"] as GraphControl;
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

            ToolsMenuItem.Enabled = true;
            CloseMenuItem.Enabled = true;
            SaveAsMenuItem.Enabled = true;
        }

        private void CloseMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenedFilesTabs.SelectedTab != null)
            {
                OpenedFilesTabs.TabPages.Remove(OpenedFilesTabs.SelectedTab);

                if (OpenedFilesTabs.TabPages.Count == 0)
                {
                    ToolsMenuItem.Enabled = false;
                    CloseMenuItem.Enabled = false;
                    SaveAsMenuItem.Enabled = false;
                }
            }
        }

        private void InfoMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show(ProgramDescriptionText, ProgramDescriptionWindowTitle);
        }

        private void EnableStatisticsMenuItem_Click(object sender, EventArgs e)
        {
            EnableStatisticsMenuItem.Checked = !EnableStatisticsMenuItem.Checked;
            ActiveGraphControl.DisplayStatistics = EnableStatisticsMenuItem.Checked;
            ActiveGraphControl.Invalidate();
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
            IsStronglyConnectedCommand command = new(ActiveGraph);
            _invoker.SetCommand(command);
            _invoker.Run();

            MessageBox.Show(command.Result ? "Граф является сильно связным" : "Граф не является сильно связным");
        }

        private void WeakConnectivityCheckMenuItem_Click(object sender, EventArgs e)
        {
            IsWeaklyConnectedCommand command = new(ActiveGraph);
            _invoker.SetCommand(command);
            _invoker.Run();

            MessageBox.Show(command.Result ? "Граф является слабо связным" : "Граф не является слабо связным");
        }

        private void EulerCheckMenuItem_Click(object sender, EventArgs e)
        {
            IsEulerCommand command = new(ActiveGraph);
            _invoker.SetCommand(command);
            _invoker.Run();

            MessageBox.Show(command.Result ? "Граф является эйлеровым" : "Граф не является эйлеровым");
        }

        private void FindEulerCycleMenuItem_Click(object sender, EventArgs e)
        {
            EulerCycleCommand command = new(ActiveGraph);
            _invoker.SetCommand(command);
            _invoker.Run();

            if (command.Result.Count > 0)
            {
                var viewer = new ResultViewer();
                viewer.SetContent(command.Result);
                viewer.Show();
            }
        }

        private void FindRouteMenuItem_Click(object sender, EventArgs e)
        {
            DijkstraCommand command = new(ActiveGraph, (from control in ActiveGraphControl.Selected
                                                        where control is GraphObjectControl gControl
                                                        select ((GraphObjectControl)control).Element).ToList());
            _invoker.SetCommand(command);
            _invoker.Run();

            if (command.Result.Count > 1)
            {
                var viewer = new ResultViewer();
                viewer.SetContent(command.Result);
                viewer.Show();
            }
        }

        private void FindShortestRouteLengthMenuItem_Click(object sender, EventArgs e)
        {
            FindShortestPathLengthCommand command = new(ActiveGraph, (from control in ActiveGraphControl.Selected
                                                                      where control is GraphObjectControl gControl
                                                                      select ((GraphObjectControl)control).Element).ToList());
            _invoker.SetCommand(command);
            _invoker.Run();

            MessageBox.Show($"Длина найденного пути: {command.Result}");
        }

        private void SaveAsMenuItem_Click(object sender, EventArgs e)
        {
            if (SaveFileDialog.ShowDialog() == DialogResult.OK)
            {
                FileSystem.FileSystem.SaveToFile(new(ActiveGraphControl), SaveFileDialog.FileName);
                OpenedFilesTabs.SelectedTab.Text = Path.GetFileName(SaveFileDialog.FileName);
            }
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            if (OpenFileDialog.ShowDialog() == DialogResult.OK)
            {
                var graphRecord = FileSystem.FileSystem.ReadFromFile(OpenFileDialog.FileName);
                OpenGraph(graphRecord, Path.GetFileName(OpenFileDialog.FileName));
            }
        }

        public void OpenGraph(GraphRecord graphRecord, string name)
        {
            CreateNewTab();
            ActiveGraphControl.SetGraph(graphRecord);
            OpenedFilesTabs.SelectedTab.Text = name;
        }
    }
}