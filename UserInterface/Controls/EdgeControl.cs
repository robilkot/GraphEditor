using LW5.Logic;

using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public partial class EdgeControl : GraphObjectControl
    {
        public EdgeControl()
        {
            InitializeComponent();
        }
        private void ChangeColorMenuItem_Click(object sender, EventArgs e)
        {
            if (GraphControl?.InputColorDialog.ShowDialog() == DialogResult.OK)
            {
                Element.Color = GraphControl.InputColorDialog.Color;
                Refresh();
            }
        }

    }
}
