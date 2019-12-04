namespace Test.UC
{
    partial class UCTestMindMapping
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.aaaaaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ucMindMappingPanel1 = new HZH_Controls.Controls.UCMindMappingPanel();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aaaaaToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(149, 26);
            // 
            // aaaaaToolStripMenuItem
            // 
            this.aaaaaToolStripMenuItem.Name = "aaaaaToolStripMenuItem";
            this.aaaaaToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.aaaaaToolStripMenuItem.Text = "更改随机文本";
            this.aaaaaToolStripMenuItem.Click += new System.EventHandler(this.ToolStripMenuItem_Click);
            // 
            // ucMindMappingPanel1
            // 
            this.ucMindMappingPanel1.AutoScroll = true;
            this.ucMindMappingPanel1.BackColor = System.Drawing.Color.White;
            this.ucMindMappingPanel1.ContextMenuStrip = this.contextMenuStrip1;
            this.ucMindMappingPanel1.DataSource = null;
            this.ucMindMappingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMindMappingPanel1.ItemBackcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMindMappingPanel1.ItemContextMenuStrip = null;
            this.ucMindMappingPanel1.LineColor = System.Drawing.Color.Black;
            this.ucMindMappingPanel1.Location = new System.Drawing.Point(0, 0);
            this.ucMindMappingPanel1.Name = "ucMindMappingPanel1";
            this.ucMindMappingPanel1.Size = new System.Drawing.Size(707, 581);
            this.ucMindMappingPanel1.TabIndex = 1;
            // 
            // UCTestMindMapping
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucMindMappingPanel1);
            this.Name = "UCTestMindMapping";
            this.Size = new System.Drawing.Size(707, 581);
            this.Load += new System.EventHandler(this.UCTestMindMapping_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCMindMappingPanel ucMindMappingPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaaaToolStripMenuItem;
    }
}
