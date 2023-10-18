namespace LW5
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
            this.VertexContextMenu.Size = new System.Drawing.Size(259, 152);
            // 
            // RenameMenuItem
            // 
            this.RenameMenuItem.Name = "RenameMenuItem";
            this.RenameMenuItem.Size = new System.Drawing.Size(258, 24);
            this.RenameMenuItem.Text = "Изменить идентификатор";
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
            // VertexControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ContextMenuStrip = this.VertexContextMenu;
            this.Cursor = System.Windows.Forms.Cursors.SizeAll;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.MaximumSize = new System.Drawing.Size(35, 35);
            this.MinimumSize = new System.Drawing.Size(35, 35);
            this.Name = "VertexControl";
            this.Size = new System.Drawing.Size(35, 35);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.VertexControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.VertexControl_MouseMove);
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
    }
}
