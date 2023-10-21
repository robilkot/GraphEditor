namespace LW5.UserInterface
{
    partial class VertexControl
    {
        /// <summary> 
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.VertexContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.CreateEdgeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ExcludeMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VertexIcon = new System.Windows.Forms.Panel();
            this.VertexToolTip = new System.Windows.Forms.ToolTip(this.components);
            this.VertexContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // VertexContextMenu
            // 
            this.VertexContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.VertexContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameMenuItem,
            this.ChangeColorMenuItem,
            this.CreateEdgeMenuItem,
            this.ExcludeMenuItem,
            this.DeleteMenuItem});
            this.VertexContextMenu.Name = "contextMenuStrip1";
            this.VertexContextMenu.Size = new System.Drawing.Size(259, 124);
            // 
            // RenameMenuItem
            // 
            this.RenameMenuItem.Name = "RenameMenuItem";
            this.RenameMenuItem.Size = new System.Drawing.Size(258, 24);
            this.RenameMenuItem.Text = "Изменить идентификатор";
            this.RenameMenuItem.Click += new System.EventHandler(this.RenameMenuItem_Click);
            // 
            // ChangeColorMenuItem
            // 
            this.ChangeColorMenuItem.Name = "ChangeColorMenuItem";
            this.ChangeColorMenuItem.Size = new System.Drawing.Size(258, 24);
            this.ChangeColorMenuItem.Text = "Изменить цвет";
            this.ChangeColorMenuItem.Click += new System.EventHandler(this.ChangeColorMenuItem_Click);
            // 
            // CreateEdgeMenuItem
            // 
            this.CreateEdgeMenuItem.Name = "CreateEdgeMenuItem";
            this.CreateEdgeMenuItem.Size = new System.Drawing.Size(258, 24);
            this.CreateEdgeMenuItem.Text = "Начать дугу";
            this.CreateEdgeMenuItem.Click += new System.EventHandler(this.CreateEdgeMenuItem_Click);
            // 
            // ExcludeMenuItem
            // 
            this.ExcludeMenuItem.Name = "ExcludeMenuItem";
            this.ExcludeMenuItem.Size = new System.Drawing.Size(258, 24);
            this.ExcludeMenuItem.Text = "Исключить";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(258, 24);
            this.DeleteMenuItem.Text = "Удалить";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // VertexIcon
            // 
            this.VertexIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.VertexIcon.Location = new System.Drawing.Point(0, 0);
            this.VertexIcon.Name = "VertexIcon";
            this.VertexIcon.Size = new System.Drawing.Size(35, 35);
            this.VertexIcon.TabIndex = 1;
            this.VertexIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.VertexIcon_Paint);
            this.VertexIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseDoubleClick);
            this.VertexIcon.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseDown);
            this.VertexIcon.MouseEnter += new System.EventHandler(this.VertexControl_MouseEnter);
            this.VertexIcon.MouseLeave += new System.EventHandler(this.VertexControl_MouseLeave);
            this.VertexIcon.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseMove);
            // 
            // VertexToolTip
            // 
            this.VertexToolTip.AutoPopDelay = 5000;
            this.VertexToolTip.InitialDelay = 100;
            this.VertexToolTip.ReshowDelay = 100;
            this.VertexToolTip.ToolTipIcon = System.Windows.Forms.ToolTipIcon.Info;
            this.VertexToolTip.ToolTipTitle = "Вершина";
            // 
            // VertexControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ContextMenuStrip = this.VertexContextMenu;
            this.Controls.Add(this.VertexIcon);
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "VertexControl";
            this.Size = new System.Drawing.Size(35, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VertexControl_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseDoubleClick);
            this.VertexContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip VertexContextMenu;
        private ToolStripMenuItem RenameMenuItem;
        private ToolStripMenuItem CreateEdgeMenuItem;
        private ToolStripMenuItem ChangeColorMenuItem;
        private ToolStripMenuItem DeleteMenuItem;
        private ToolStripMenuItem ExcludeMenuItem;
        private Panel VertexIcon;
        private ToolTip VertexToolTip;
    }
}
