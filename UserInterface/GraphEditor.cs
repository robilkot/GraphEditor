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
                if (OpenedFilesTabs.SelectedTab.Controls["graphLayout"] is GraphControl graphControl)
                {
                    return graphControl.Graph;

                }
                else return null;
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
            newTab.Text = "New graph";
            newTab.Controls.Add(graphLayout);

            OpenedFilesTabs.TabPages.Add(newTab);
            OpenedFilesTabs.SelectTab(newTab);
        }

        private void CreateMenuItem_Click(object sender, EventArgs e)
        {
            CreateNewTab();

            //Graph graph = new();

            //graph.Vertices.Add(new() { Color = Color.Red, Identifier = "Test1" });
            //graph.Vertices.Add(new() { Color = Color.Blue, Identifier = "Test2" });
            //graph.Vertices.Add(new() { Color = Color.Green, Identifier = "Test3" });

            //LayoutControl layout = (LayoutControl)OpenedFilesTabs.SelectedTab.Controls["graphLayout"];
            //layout.SetGraph(graph);
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
            MessageBox.Show("Графовый редактор, сделанный в рамках лабороторной работы 5 по дисциплине ОТИС.\n\nWith love by @robilkot.", "О программе");
        }
    }
}