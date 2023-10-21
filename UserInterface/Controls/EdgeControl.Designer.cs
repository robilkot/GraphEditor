namespace LW5.UserInterface
{
    partial class EdgeControl
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
            this.EdgeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.RenameMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ChangeColorMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReverseMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DeleteMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EdgeIcon = new System.Windows.Forms.Panel();
            this.EdgeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // EdgeContextMenu
            // 
            this.EdgeContextMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.EdgeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.RenameMenuItem,
            this.ChangeColorMenuItem,
            this.ReverseMenuItem,
            this.DeleteMenuItem});
            this.EdgeContextMenu.Name = "contextMenuStrip1";
            this.EdgeContextMenu.Size = new System.Drawing.Size(259, 128);
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
            // 
            // ReverseMenuItem
            // 
            this.ReverseMenuItem.Name = "ReverseMenuItem";
            this.ReverseMenuItem.Size = new System.Drawing.Size(258, 24);
            this.ReverseMenuItem.Text = "Изменить направление";
            // 
            // DeleteMenuItem
            // 
            this.DeleteMenuItem.Name = "DeleteMenuItem";
            this.DeleteMenuItem.Size = new System.Drawing.Size(258, 24);
            this.DeleteMenuItem.Text = "Удалить";
            this.DeleteMenuItem.Click += new System.EventHandler(this.DeleteMenuItem_Click);
            // 
            // EdgeIcon
            // 
            this.EdgeIcon.Dock = System.Windows.Forms.DockStyle.Fill;
            this.EdgeIcon.Location = new System.Drawing.Point(0, 0);
            this.EdgeIcon.Name = "EdgeIcon";
            this.EdgeIcon.Size = new System.Drawing.Size(150, 150);
            this.EdgeIcon.TabIndex = 2;
            this.EdgeIcon.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgeIcon_Paint);
            // 
            // EdgeControl
            // 
            this.BackColor = System.Drawing.Color.Transparent;
            this.ContextMenuStrip = this.EdgeContextMenu;
            this.Controls.Add(this.EdgeIcon);
            this.Name = "EdgeControl";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.EdgeControl_Paint);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.EdgeControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.EdgeControl_MouseMove);
            this.EdgeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private ContextMenuStrip EdgeContextMenu;
        private ToolStripMenuItem RenameMenuItem;
        private ToolStripMenuItem ChangeColorMenuItem;
        private ToolStripMenuItem ReverseMenuItem;
        private ToolStripMenuItem DeleteMenuItem;
        private Panel EdgeIcon;
    }
}
