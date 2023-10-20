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
            components = new System.ComponentModel.Container();
            VertexContextMenu = new ContextMenuStrip(components);
            RenameMenuItem = new ToolStripMenuItem();
            ChangeColorMenuItem = new ToolStripMenuItem();
            CreateEdgeMenuItem = new ToolStripMenuItem();
            ExcludeMenuItem = new ToolStripMenuItem();
            DeleteMenuItem = new ToolStripMenuItem();
            VertexIcon = new Panel();
            VertexToolTip = new ToolTip(components);
            VertexContextMenu.SuspendLayout();
            SuspendLayout();
            // 
            // VertexContextMenu
            // 
            VertexContextMenu.ImageScalingSize = new Size(20, 20);
            VertexContextMenu.Items.AddRange(new ToolStripItem[] { RenameMenuItem, ChangeColorMenuItem, CreateEdgeMenuItem, ExcludeMenuItem, DeleteMenuItem });
            VertexContextMenu.Name = "contextMenuStrip1";
            VertexContextMenu.Size = new Size(294, 164);
            // 
            // RenameMenuItem
            // 
            RenameMenuItem.Name = "RenameMenuItem";
            RenameMenuItem.Size = new Size(293, 32);
            RenameMenuItem.Text = "Изменить идентификатор";
            RenameMenuItem.Click += RenameMenuItem_Click;
            // 
            // ChangeColorMenuItem
            // 
            ChangeColorMenuItem.Name = "ChangeColorMenuItem";
            ChangeColorMenuItem.Size = new Size(293, 32);
            ChangeColorMenuItem.Text = "Изменить цвет";
            ChangeColorMenuItem.Click += ChangeColorMenuItem_Click;
            // 
            // CreateEdgeMenuItem
            // 
            CreateEdgeMenuItem.Name = "CreateEdgeMenuItem";
            CreateEdgeMenuItem.Size = new Size(293, 32);
            CreateEdgeMenuItem.Text = "Начать дугу";
            CreateEdgeMenuItem.Click += CreateEdgeMenuItem_Click;
            // 
            // ExcludeMenuItem
            // 
            ExcludeMenuItem.Name = "ExcludeMenuItem";
            ExcludeMenuItem.Size = new Size(293, 32);
            ExcludeMenuItem.Text = "Исключить";
            // 
            // DeleteMenuItem
            // 
            DeleteMenuItem.Name = "DeleteMenuItem";
            DeleteMenuItem.Size = new Size(293, 32);
            DeleteMenuItem.Text = "Удалить";
            DeleteMenuItem.Click += DeleteMenuItem_Click;
            // 
            // VertexIcon
            // 
            VertexIcon.Dock = DockStyle.Fill;
            VertexIcon.Location = new Point(0, 0);
            VertexIcon.Name = "VertexIcon";
            VertexIcon.Size = new Size(35, 35);
            VertexIcon.TabIndex = 1;
            VertexIcon.Paint += VertexIcon_Paint;
            VertexIcon.MouseDown += VertexControl_MouseDown;
            VertexIcon.MouseEnter += VertexControl_MouseEnter;
            VertexIcon.MouseLeave += VertexControl_MouseLeave;
            VertexIcon.MouseMove += VertexControl_MouseMove;
            // 
            // VertexToolTip
            // 
            VertexToolTip.AutoPopDelay = 5000;
            VertexToolTip.InitialDelay = 100;
            VertexToolTip.ReshowDelay = 100;
            VertexToolTip.ToolTipIcon = ToolTipIcon.Info;
            VertexToolTip.ToolTipTitle = "Вершина";
            // 
            // VertexControl
            // 
            BackColor = Color.Transparent;
            BackgroundImageLayout = ImageLayout.None;
            ContextMenuStrip = VertexContextMenu;
            Controls.Add(VertexIcon);
            Cursor = Cursors.SizeAll;
            DoubleBuffered = true;
            Margin = new Padding(0);
            Name = "VertexControl";
            Size = new Size(35, 35);
            Paint += VertexControl_Paint;
            MouseDown += VertexControl_MouseDown;
            MouseEnter += VertexControl_MouseEnter;
            MouseLeave += VertexControl_MouseLeave;
            MouseMove += VertexControl_MouseMove;
            VertexContextMenu.ResumeLayout(false);
            ResumeLayout(false);
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
