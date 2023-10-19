using LW5.Logic;
using LW5.UserInterface;

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

        private void GraphEditor_Load(object sender, EventArgs e)
        {
            CreateNewTab();
        }

        private void CreateNewTab()
        {
            var graphLayout = new GraphControl();
            graphLayout.Dock = DockStyle.Fill;
            graphLayout.Name = "graphLayout";

            TabPage newTab = new();
            newTab.Text = Styles.DefaultFileName;
            newTab.Controls.Add(graphLayout);

            OpenedFilesTabs.TabPages.Add(newTab);
            OpenedFilesTabs.SelectTab(newTab);
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
            MessageBox.Show(Styles.ProgramDescriptionText, Styles.ProgramDescriptionWindowText);
        }
    }
}