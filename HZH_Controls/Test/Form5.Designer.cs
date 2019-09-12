namespace Test
{
    partial class Form5
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
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
            this.contextMenuStrip1.Size = new System.Drawing.Size(153, 48);
            // 
            // aaaaaToolStripMenuItem
            // 
            this.aaaaaToolStripMenuItem.Name = "aaaaaToolStripMenuItem";
            this.aaaaaToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.aaaaaToolStripMenuItem.Text = "更改随机文本";
            this.aaaaaToolStripMenuItem.Click += new System.EventHandler(this.aaaaaToolStripMenuItem_Click);
            // 
            // ucMindMappingPanel1
            // 
            this.ucMindMappingPanel1.AutoScroll = true;
            this.ucMindMappingPanel1.BackColor = System.Drawing.Color.White;
            this.ucMindMappingPanel1.DataSource = null;
            this.ucMindMappingPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucMindMappingPanel1.ItemBackcolor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucMindMappingPanel1.ItemContextMenuStrip = this.contextMenuStrip1;
            this.ucMindMappingPanel1.LineColor = System.Drawing.Color.Black;
            this.ucMindMappingPanel1.Location = new System.Drawing.Point(0, 0);
            this.ucMindMappingPanel1.Name = "ucMindMappingPanel1";
            this.ucMindMappingPanel1.Size = new System.Drawing.Size(654, 566);
            this.ucMindMappingPanel1.TabIndex = 0;
            this.ucMindMappingPanel1.ItemClicked += new System.EventHandler(this.ucMindMappingPanel1_ItemClicked);
            // 
            // Form5
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(654, 566);
            this.Controls.Add(this.ucMindMappingPanel1);
            this.Name = "Form5";
            this.Text = "Form5";
            this.Load += new System.EventHandler(this.Form5_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCMindMappingPanel ucMindMappingPanel1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem aaaaaToolStripMenuItem;
    }
}