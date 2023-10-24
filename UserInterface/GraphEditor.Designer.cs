namespace LW5
{
    partial class GraphEditor
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            OpenedFilesTabs = new TabControl();
            MenuStrip = new MenuStrip();
            файлToolStripMenuItem = new ToolStripMenuItem();
            CreateMenuItem = new ToolStripMenuItem();
            OpenMenuItem = new ToolStripMenuItem();
            CloseMenuItem = new ToolStripMenuItem();
            SaveMenuItem = new ToolStripMenuItem();
            SaveAsMenuItem = new ToolStripMenuItem();
            ToolsMenuItem = new ToolStripMenuItem();
            EnableStatisticsMenuItem = new ToolStripMenuItem();
            StrongConnectivityCheckMenuItem = new ToolStripMenuItem();
            WeakConnectivityCheckMenuItem = new ToolStripMenuItem();
            EulerCheckMenuItem = new ToolStripMenuItem();
            FindEulerCycleMenuItem = new ToolStripMenuItem();
            FindShortestRouteMenuItem = new ToolStripMenuItem();
            InfoMenuItem = new ToolStripMenuItem();
            OpenFileDialog = new OpenFileDialog();
            SaveFileDialog = new SaveFileDialog();
            MenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // OpenedFilesTabs
            // 
            OpenedFilesTabs.AllowDrop = true;
            OpenedFilesTabs.Dock = DockStyle.Fill;
            OpenedFilesTabs.ItemSize = new Size(200, 30);
            OpenedFilesTabs.Location = new Point(0, 33);
            OpenedFilesTabs.Margin = new Padding(2);
            OpenedFilesTabs.Name = "OpenedFilesTabs";
            OpenedFilesTabs.SelectedIndex = 0;
            OpenedFilesTabs.Size = new Size(1578, 808);
            OpenedFilesTabs.SizeMode = TabSizeMode.Fixed;
            OpenedFilesTabs.TabIndex = 1;
            OpenedFilesTabs.Selected += OpenedFilesTabs_Selected;
            // 
            // MenuStrip
            // 
            MenuStrip.ImageScalingSize = new Size(20, 20);
            MenuStrip.Items.AddRange(new ToolStripItem[] { файлToolStripMenuItem, ToolsMenuItem, InfoMenuItem });
            MenuStrip.Location = new Point(0, 0);
            MenuStrip.Name = "MenuStrip";
            MenuStrip.Padding = new Padding(8, 2, 0, 2);
            MenuStrip.Size = new Size(1578, 33);
            MenuStrip.TabIndex = 2;
            MenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            файлToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { CreateMenuItem, OpenMenuItem, CloseMenuItem, SaveMenuItem, SaveAsMenuItem });
            файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            файлToolStripMenuItem.Size = new Size(69, 29);
            файлToolStripMenuItem.Text = "Файл";
            // 
            // CreateMenuItem
            // 
            CreateMenuItem.Name = "CreateMenuItem";
            CreateMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            CreateMenuItem.Size = new Size(250, 34);
            CreateMenuItem.Text = "Создать";
            CreateMenuItem.Click += CreateMenuItem_Click;
            // 
            // OpenMenuItem
            // 
            OpenMenuItem.Name = "OpenMenuItem";
            OpenMenuItem.Size = new Size(250, 34);
            OpenMenuItem.Text = "Открыть";
            OpenMenuItem.Click += OpenMenuItem_Click;
            // 
            // CloseMenuItem
            // 
            CloseMenuItem.Name = "CloseMenuItem";
            CloseMenuItem.ShortcutKeyDisplayString = "Ctrl+W";
            CloseMenuItem.Size = new Size(250, 34);
            CloseMenuItem.Text = "Закрыть";
            CloseMenuItem.Click += CloseMenuItem_Click;
            // 
            // SaveMenuItem
            // 
            SaveMenuItem.Name = "SaveMenuItem";
            SaveMenuItem.Size = new Size(250, 34);
            SaveMenuItem.Text = "Сохранить";
            SaveMenuItem.Visible = false;
            // 
            // SaveAsMenuItem
            // 
            SaveAsMenuItem.Name = "SaveAsMenuItem";
            SaveAsMenuItem.Size = new Size(250, 34);
            SaveAsMenuItem.Text = "Сохранить как";
            SaveAsMenuItem.Click += SaveAsMenuItem_Click;
            // 
            // ToolsMenuItem
            // 
            ToolsMenuItem.DropDownItems.AddRange(new ToolStripItem[] { EnableStatisticsMenuItem, StrongConnectivityCheckMenuItem, WeakConnectivityCheckMenuItem, EulerCheckMenuItem, FindEulerCycleMenuItem, FindShortestRouteMenuItem });
            ToolsMenuItem.Name = "ToolsMenuItem";
            ToolsMenuItem.Size = new Size(138, 29);
            ToolsMenuItem.Text = "Инструменты";
            // 
            // EnableStatisticsMenuItem
            // 
            EnableStatisticsMenuItem.Name = "EnableStatisticsMenuItem";
            EnableStatisticsMenuItem.Size = new Size(389, 34);
            EnableStatisticsMenuItem.Text = "Отображение статистики";
            EnableStatisticsMenuItem.Click += EnableStatisticsMenuItem_Click;
            // 
            // StrongConnectivityCheckMenuItem
            // 
            StrongConnectivityCheckMenuItem.Name = "StrongConnectivityCheckMenuItem";
            StrongConnectivityCheckMenuItem.Size = new Size(389, 34);
            StrongConnectivityCheckMenuItem.Text = "Проверить на сильную связность";
            StrongConnectivityCheckMenuItem.Click += ConnectivityCheckMenuItem_Click;
            // 
            // WeakConnectivityCheckMenuItem
            // 
            WeakConnectivityCheckMenuItem.Name = "WeakConnectivityCheckMenuItem";
            WeakConnectivityCheckMenuItem.Size = new Size(389, 34);
            WeakConnectivityCheckMenuItem.Text = "Проверить на слабую связность";
            WeakConnectivityCheckMenuItem.Click += WeakConnectivityCheckMenuItem_Click;
            // 
            // EulerCheckMenuItem
            // 
            EulerCheckMenuItem.Name = "EulerCheckMenuItem";
            EulerCheckMenuItem.Size = new Size(389, 34);
            EulerCheckMenuItem.Text = "Проверить на эйлеровость";
            EulerCheckMenuItem.Click += EulerCheckMenuItem_Click;
            // 
            // FindEulerCycleMenuItem
            // 
            FindEulerCycleMenuItem.Name = "FindEulerCycleMenuItem";
            FindEulerCycleMenuItem.Size = new Size(389, 34);
            FindEulerCycleMenuItem.Text = "Найти эйлеров цикл";
            FindEulerCycleMenuItem.Click += FindEulerCycleMenuItem_Click;
            // 
            // FindShortestRouteMenuItem
            // 
            FindShortestRouteMenuItem.Name = "FindShortestRouteMenuItem";
            FindShortestRouteMenuItem.Size = new Size(389, 34);
            FindShortestRouteMenuItem.Text = "Найти кратчайший путь";
            FindShortestRouteMenuItem.Click += FindRouteMenuItem_Click;
            // 
            // InfoMenuItem
            // 
            InfoMenuItem.Name = "InfoMenuItem";
            InfoMenuItem.Size = new Size(141, 29);
            InfoMenuItem.Text = "О программе";
            InfoMenuItem.Click += InfoMenuItem_Click;
            // 
            // OpenFileDialog
            // 
            OpenFileDialog.FileName = "graph.json";
            OpenFileDialog.Title = "Открыть файл";
            // 
            // SaveFileDialog
            // 
            SaveFileDialog.FileName = "graph.json";
            SaveFileDialog.Title = "Сохранить файл";
            // 
            // GraphEditor
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1578, 841);
            Controls.Add(OpenedFilesTabs);
            Controls.Add(MenuStrip);
            HelpButton = true;
            MainMenuStrip = MenuStrip;
            Margin = new Padding(2);
            MinimumSize = new Size(1120, 548);
            Name = "GraphEditor";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Графовый редактор";
            Load += GraphEditor_Load;
            MenuStrip.ResumeLayout(false);
            MenuStrip.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TabControl OpenedFilesTabs;
        private MenuStrip MenuStrip;
        private ToolStripMenuItem файлToolStripMenuItem;
        private ToolStripMenuItem CreateMenuItem;
        private ToolStripMenuItem OpenMenuItem;
        private ToolStripMenuItem CloseMenuItem;
        private ToolStripMenuItem SaveMenuItem;
        private ToolStripMenuItem SaveAsMenuItem;
        private ToolStripMenuItem ToolsMenuItem;
        private ToolStripMenuItem InfoMenuItem;
        private ToolStripMenuItem EnableStatisticsMenuItem;
        private ToolStripMenuItem StrongConnectivityCheckMenuItem;
        private ToolStripMenuItem WeakConnectivityCheckMenuItem;
        private ToolStripMenuItem EulerCheckMenuItem;
        private ToolStripMenuItem FindEulerCycleMenuItem;
        private ToolStripMenuItem FindShortestRouteMenuItem;
        private OpenFileDialog OpenFileDialog;
        private SaveFileDialog SaveFileDialog;
    }
}