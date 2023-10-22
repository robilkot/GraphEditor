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
            EnableStatisticsMenuItem.Checked = !EnableStatisticsMenuItem.Checked;
            ActiveGraphControl.DisplayStatistics = EnableStatisticsMenuItem.Checked;
            ActiveGraphControl?.Invalidate();
        }

        private void OpenedFilesTabs_Selected(object sender, TabControlEventArgs e)
        {
            EnableStatisticsMenuItem.Checked = ActiveGraphControl.DisplayStatistics;
        }
    }
}