using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using LW5.Logic;

namespace LW5
{
    public partial class VertexControl : UserControl
    {
        public Vertex Vertex { get; set; } = new();
        public VertexControl()
        {
            InitializeComponent();
        }
        public VertexControl(Vertex vertex)
        {
            Vertex = vertex;
            InitializeComponent();
        }

        private Point MouseDownLocation;
        private void VertexControl_MouseDown(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
                MouseDownLocation = e.Location;
            }
        }
        private void VertexControl_MouseMove(object sender, MouseEventArgs e)
        {
            if(e.Button == MouseButtons.Left)
            {
            VertexName.Left += e.Location.X - MouseDownLocation.X;
            VertexName.Top += e.Location.Y - MouseDownLocation.Y;
            }
        }
    }
}
