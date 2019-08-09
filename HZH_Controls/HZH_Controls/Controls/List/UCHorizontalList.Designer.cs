namespace HZH_Controls.Controls
{
    partial class UCHorizontalList
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
            this.panMain = new System.Windows.Forms.Panel();
            this.panList = new System.Windows.Forms.Panel();
            this.panRight = new System.Windows.Forms.Panel();
            this.panLeft = new System.Windows.Forms.Panel();
            this.panMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // panMain
            // 
            this.panMain.Controls.Add(this.panList);
            this.panMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panMain.Location = new System.Drawing.Point(46, 0);
            this.panMain.Name = "panMain";
            this.panMain.Size = new System.Drawing.Size(422, 53);
            this.panMain.TabIndex = 3;
            // 
            // panList
            // 
            this.panList.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.panList.BackColor = System.Drawing.Color.Transparent;
            this.panList.Location = new System.Drawing.Point(0, 0);
            this.panList.Name = "panList";
            this.panList.Size = new System.Drawing.Size(401, 53);
            this.panList.TabIndex = 0;
            // 
            // panRight
            // 
            this.panRight.BackgroundImage = global::HZH_Controls.Properties.Resources.chevron_right;
            this.panRight.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panRight.Dock = System.Windows.Forms.DockStyle.Right;
            this.panRight.Location = new System.Drawing.Point(468, 0);
            this.panRight.Name = "panRight";
            this.panRight.Size = new System.Drawing.Size(46, 53);
            this.panRight.TabIndex = 2;
            this.panRight.Visible = false;
            this.panRight.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panRight_MouseDown);
            // 
            // panLeft
            // 
            this.panLeft.BackgroundImage = global::HZH_Controls.Properties.Resources.chevron_left;
            this.panLeft.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.panLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.panLeft.Location = new System.Drawing.Point(0, 0);
            this.panLeft.Name = "panLeft";
            this.panLeft.Size = new System.Drawing.Size(46, 53);
            this.panLeft.TabIndex = 1;
            this.panLeft.Visible = false;
            this.panLeft.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panLeft_MouseDown);
            // 
            // UCHorizontalList
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.Controls.Add(this.panMain);
            this.Controls.Add(this.panRight);
            this.Controls.Add(this.panLeft);
            this.Name = "UCHorizontalList";
            this.Size = new System.Drawing.Size(514, 53);
            this.panMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panLeft;
        private System.Windows.Forms.Panel panRight;
        private System.Windows.Forms.Panel panMain;
        private System.Windows.Forms.Panel panList;
    }
}
