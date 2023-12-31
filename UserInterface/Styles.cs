﻿namespace LW5.UserInterface
{
    public static class Styles
    {
        public static readonly Font VertexNameFont = new("Segoe UI", 12);
        public static readonly Font EdgeWeightFont = new("Segoe UI", 9);
        public static readonly Font StatisticsFont = new("Segoe UI", 9);

        public static readonly Color SelectedColor = Color.DodgerBlue;
        public static readonly Color HoverColor = Color.LightSkyBlue;
        public static readonly Color SelectionRectangleColor = Color.DodgerBlue;
        public static readonly Color CreatingEdgeColor = Color.Gray;
        public static readonly Color StatisticsFontColor = Color.Gray;

        public static readonly SolidBrush SelectionRectangleBrush = new(Color.FromArgb(64, SelectionRectangleColor));

        public const int VertexDiameter = 36;
        public const int LoopDiameter = 50;
        public const int SelectionThickness = 4;
        public const int EdgeThickness = 4;

        public const string DefaultFileName = "Новый граф";
        public const string DefaultVertexName = "Вершина";
        public const string DefaultEdgeName = "Ребро";
        public const string DefaultElementName = "Объект";

        public const string VertexToolTipText = "Степень: {0}\nЦвет: {1}";
        public const string GraphStatisticsText = "Мощность графа: {0}\nКоличество дуг: {1}\nКоличество петель: {2}\n\nВыделено вершин: {3}\nВыделено дуг: {4}";

        public const string RenameWindowTitleText = "Ввод идентификатора";
        public const string NumberInputWindowTitleText = "Ввод целочисленного значения";
        public const string NumberEvaluatingErrorText = "Введено не целочисленное значение";

        public const string ProgramDescriptionWindowTitle = "Описание программы";
        public const string ProgramDescriptionText = "Графовый редактор, сделанный в рамках лабороторной работы 5 по дисциплине ОТИС.\n\nWith love by @robilkot.";
        public static string ToRGBString(this Color color) => $"R {color.R}, G {color.G}, B {color.B}";
        public static Point Center(this UserControl control)
        {
            return new(
            control.Left + control.Width / 2,
            control.Top + control.Height / 2
            );
        }
    }
}
