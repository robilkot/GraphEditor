using System.Windows.Forms;

namespace LW5.UserInterface
{
    public static class Styles
    {
        public static readonly Font VertexNameFont = new("Segoe UI", 9);

        public static readonly Color SelectedColor = Color.DodgerBlue;
        public static readonly Color HoverColor = Color.LightSkyBlue;
        public static readonly Color SelectionRectangleColor = Color.DodgerBlue;

        public static readonly SolidBrush SelectionRectangleBrush = new SolidBrush(Color.FromArgb(64, SelectionRectangleColor));

        //public const int VertexBoundsThickness = 6;
        public const int VertexDiameter = 36;
        public const int SelectionThickness = 4;

        public const string DefaultFileName = "Новый граф";
        public const string VertexToolTipText = "Цвет: {0}";

        public const string VertexRenameWindowTitleText = "Ввод идентификатора вершины";

        public const string ProgramDescriptionWindowText = "Описание программы";
        public const string ProgramDescriptionText = "Графовый редактор, сделанный в рамках лабороторной работы 5 по дисциплине ОТИС.\n\nWith love by @robilkot.";
        public static string ToRGBString(this Color color) => $"R {color.R}, G {color.G}, B {color.B}";
        public static Point Center(this UserControl control) => new(
            control.Left + control.Width / 2,
            control.Top + control.Height / 2
            );
    }
}
