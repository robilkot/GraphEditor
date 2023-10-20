namespace LW5.UserInterface
{
    partial class GraphControl
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
            this.LayoutContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CreateVertexMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectAllMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteSelectedMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.InputColorDialog = new System.Windows.Forms.ColorDialog();
            this.LayoutContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // LayoutContextMenu
            // 
            this.LayoutContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.LayoutContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CreateVertexMenuItem,
            this.SelectAllMenuItem,
            this.DeleteSelectedMenuItem});
            this.LayoutContextMenu.Name = "LayoutContextMenu";
            this.LayoutContextMenu.ShowImageMargin = false;
            this.LayoutContextMenu.Size = new System.Drawing.Size(234, 76);
            // 
            // CreateVertexMenuItem
            // 
            this.CreateVertexMenuItem.Name = "CreateVertexMenuItem";
            this.CreateVertexMenuItem.ShortcutKeyDisplayString = "Shift+A";
            this.CreateVertexMenuItem.Size = new System.Drawing.Size(233, 24);
            this.CreateVertexMenuItem.Text = "Создать вершину";
            this.CreateVertexMenuItem.Click += new System.EventHandler(this.CreateVertexMenuItem_Click);
            // 
            // SelectAllMenuItem
            // 
            this.SelectAllMenuItem.Name = "SelectAllMenuItem";
            this.SelectAllMenuItem.ShortcutKeyDisplayString = "Ctrl+A";
            this.SelectAllMenuItem.Size = new System.Drawing.Size(233, 24);
            this.SelectAllMenuItem.Text = "Выделить всё";
            this.SelectAllMenuItem.Click += new System.EventHandler(this.SelectAllMenuItem_Click);
            // 
            // DeleteSelectedMenuItem
            // 
            this.DeleteSelectedMenuItem.Name = "DeleteSelectedMenuItem";
            this.DeleteSelectedMenuItem.ShortcutKeyDisplayString = "Del";
            this.DeleteSelectedMenuItem.Size = new System.Drawing.Size(233, 24);
            this.DeleteSelectedMenuItem.Text = "Удалить выделенное";
            this.DeleteSelectedMenuItem.Click += new System.EventHandler(this.DeleteSelectedMenuItem_Click);
            // 
            // GraphControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ContextMenuStrip = this.LayoutContextMenu;
            this.DoubleBuffered = true;
            this.Name = "GraphControl";
            this.Size = new System.Drawing.Size(757, 500);
            this.Click += new System.EventHandler(this.GraphControl_Click);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.GraphControl_Paint);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.GraphControl_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.GraphControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.GraphControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.GraphControl_MouseUp);
            this.LayoutContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip LayoutContextMenu;
        private ToolStripMenuItem CreateVertexMenuItem;
        private ToolStripMenuItem SelectAllMenuItem;
        private ToolStripMenuItem DeleteSelectedMenuItem;
        internal ColorDialog InputColorDialog;
    }
}
