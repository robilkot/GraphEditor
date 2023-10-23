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
            this.OpenedFilesTabs = new System.Windows.Forms.TabControl();
            this.MenuStrip = new System.Windows.Forms.MenuStrip();
            this.файлToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.OpenMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CloseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SaveAsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EnableStatisticsMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StrongConnectivityCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.WeakConnectivityCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EulerCheckMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InfoMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FindEulerCycleMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // OpenedFilesTabs
            // 
            this.OpenedFilesTabs.AllowDrop = true;
            this.OpenedFilesTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OpenedFilesTabs.ItemSize = new System.Drawing.Size(200, 30);
            this.OpenedFilesTabs.Location = new System.Drawing.Point(0, 28);
            this.OpenedFilesTabs.Margin = new System.Windows.Forms.Padding(2);
            this.OpenedFilesTabs.Name = "OpenedFilesTabs";
            this.OpenedFilesTabs.SelectedIndex = 0;
            this.OpenedFilesTabs.Size = new System.Drawing.Size(1262, 645);
            this.OpenedFilesTabs.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.OpenedFilesTabs.TabIndex = 1;
            this.OpenedFilesTabs.Selected += new System.Windows.Forms.TabControlEventHandler(this.OpenedFilesTabs_Selected);
            // 
            // MenuStrip
            // 
            this.MenuStrip.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.файлToolStripMenuItem,
            this.ToolsMenuItem,
            this.InfoMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(1262, 28);
            this.MenuStrip.TabIndex = 2;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // файлToolStripMenuItem
            // 
            this.файлToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateMenuItem,
            this.OpenMenuItem,
            this.CloseMenuItem,
            this.SaveMenuItem,
            this.SaveAsMenuItem});
            this.файлToolStripMenuItem.Name = "файлToolStripMenuItem";
            this.файлToolStripMenuItem.Size = new System.Drawing.Size(59, 24);
            this.файлToolStripMenuItem.Text = "Файл";
            // 
            // CreateMenuItem
            // 
            this.CreateMenuItem.Name = "CreateMenuItem";
            this.CreateMenuItem.ShortcutKeyDisplayString = "Ctrl+N";
            this.CreateMenuItem.Size = new System.Drawing.Size(205, 26);
            this.CreateMenuItem.Text = "Создать";
            this.CreateMenuItem.Click += new System.EventHandler(this.CreateMenuItem_Click);
            // 
            // OpenMenuItem
            // 
            this.OpenMenuItem.Name = "OpenMenuItem";
            this.OpenMenuItem.Size = new System.Drawing.Size(205, 26);
            this.OpenMenuItem.Text = "Открыть";
            // 
            // CloseMenuItem
            // 
            this.CloseMenuItem.Name = "CloseMenuItem";
            this.CloseMenuItem.ShortcutKeyDisplayString = "Ctrl+W";
            this.CloseMenuItem.Size = new System.Drawing.Size(205, 26);
            this.CloseMenuItem.Text = "Закрыть";
            this.CloseMenuItem.Click += new System.EventHandler(this.CloseMenuItem_Click);
            // 
            // SaveMenuItem
            // 
            this.SaveMenuItem.Name = "SaveMenuItem";
            this.SaveMenuItem.Size = new System.Drawing.Size(205, 26);
            this.SaveMenuItem.Text = "Сохранить";
            // 
            // SaveAsMenuItem
            // 
            this.SaveAsMenuItem.Name = "SaveAsMenuItem";
            this.SaveAsMenuItem.Size = new System.Drawing.Size(205, 26);
            this.SaveAsMenuItem.Text = "Сохранить как";
            // 
            // ToolsMenuItem
            // 
            this.ToolsMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.EnableStatisticsMenuItem,
            this.StrongConnectivityCheckMenuItem,
            this.WeakConnectivityCheckMenuItem,
            this.EulerCheckMenuItem,
            this.FindEulerCycleMenuItem});
            this.ToolsMenuItem.Name = "ToolsMenuItem";
            this.ToolsMenuItem.Size = new System.Drawing.Size(117, 24);
            this.ToolsMenuItem.Text = "Инструменты";
            // 
            // EnableStatisticsMenuItem
            // 
            this.EnableStatisticsMenuItem.Name = "EnableStatisticsMenuItem";
            this.EnableStatisticsMenuItem.Size = new System.Drawing.Size(327, 26);
            this.EnableStatisticsMenuItem.Text = "Отображение статистики";
            this.EnableStatisticsMenuItem.Click += new System.EventHandler(this.EnableStatisticsMenuItem_Click);
            // 
            // StrongConnectivityCheckMenuItem
            // 
            this.StrongConnectivityCheckMenuItem.Name = "StrongConnectivityCheckMenuItem";
            this.StrongConnectivityCheckMenuItem.Size = new System.Drawing.Size(327, 26);
            this.StrongConnectivityCheckMenuItem.Text = "Проверить на сильную связность";
            this.StrongConnectivityCheckMenuItem.Click += new System.EventHandler(this.ConnectivityCheckMenuItem_Click);
            // 
            // WeakConnectivityCheckMenuItem
            // 
            this.WeakConnectivityCheckMenuItem.Name = "WeakConnectivityCheckMenuItem";
            this.WeakConnectivityCheckMenuItem.Size = new System.Drawing.Size(327, 26);
            this.WeakConnectivityCheckMenuItem.Text = "Проверить на слабую связность";
            this.WeakConnectivityCheckMenuItem.Click += new System.EventHandler(this.WeakConnectivityCheckMenuItem_Click);
            // 
            // EulerCheckMenuItem
            // 
            this.EulerCheckMenuItem.Name = "EulerCheckMenuItem";
            this.EulerCheckMenuItem.Size = new System.Drawing.Size(327, 26);
            this.EulerCheckMenuItem.Text = "Проверить на эйлеровость";
            this.EulerCheckMenuItem.Click += new System.EventHandler(this.EulerCheckMenuItem_Click);
            // 
            // InfoMenuItem
            // 
            this.InfoMenuItem.Name = "InfoMenuItem";
            this.InfoMenuItem.Size = new System.Drawing.Size(118, 24);
            this.InfoMenuItem.Text = "О программе";
            this.InfoMenuItem.Click += new System.EventHandler(this.InfoMenuItem_Click);
            // 
            // FindEulerCycleMenuItem
            // 
            this.FindEulerCycleMenuItem.Name = "FindEulerCycleMenuItem";
            this.FindEulerCycleMenuItem.Size = new System.Drawing.Size(327, 26);
            this.FindEulerCycleMenuItem.Text = "Найти эйлеров цикл";
            this.FindEulerCycleMenuItem.Click += new System.EventHandler(this.FindEulerCycleMenuItem_Click);
            // 
            // GraphEditor
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1262, 673);
            this.Controls.Add(this.OpenedFilesTabs);
            this.Controls.Add(this.MenuStrip);
            this.HelpButton = true;
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.MinimumSize = new System.Drawing.Size(900, 450);
            this.Name = "GraphEditor";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Графовый редактор";
            this.Load += new System.EventHandler(this.GraphEditor_Load);
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}