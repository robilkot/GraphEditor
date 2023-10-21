using LW5.Logic;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using static LW5.UserInterface.Styles;

namespace LW5.UserInterface
{
    public partial class EdgeControl : GraphObjectControl
    {
        public GraphObjectControl? First { get; set; }
        public GraphObjectControl? Second { get; set; }
        public EdgeControl()
        {
            InitializeComponent();

            typeof(Panel).InvokeMember("DoubleBuffered", BindingFlags.SetProperty
            | BindingFlags.Instance | BindingFlags.NonPublic, null,
            EdgeIcon, new object[] { true });
        }

        private void EdgeControl_Paint(object sender, PaintEventArgs e)
        {
            int newWidth = Math.Abs(First.Left - Second.Left);
            Width = newWidth > 0 ? newWidth : 1;

            int newHeight = Math.Abs(First.Top - Second.Top);
            Height = newHeight > 0 ? newHeight : 1;

            Left = First.Left < Second.Left ? First.Center().X : Second.Center().X;
            Top = First.Top < Second.Top ? First.Center().Y : Second.Center().Y;
        }

        private void EdgeControl_MouseMove(object sender, MouseEventArgs e)
        {

        }

        private void EdgeControl_MouseDown(object sender, MouseEventArgs e)
        {

        }

        private void EdgeIcon_Paint(object sender, PaintEventArgs e)
        {
            //e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

            var x = First.Center();
            x.X -= Left;
            x.Y -= Top;

            var y = Second.Center();
            y.X -= Left;
            y.Y -= Top;

            e.Graphics.DrawLine(
                Pens.Black,
                x,
                y
                );
        }

        private void DeleteMenuItem_Click(object sender, EventArgs e)
        {
            Delete();
        }
    }
}
