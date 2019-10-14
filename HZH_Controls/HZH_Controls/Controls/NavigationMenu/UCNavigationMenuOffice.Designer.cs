namespace HZH_Controls.Controls
{
    partial class UCNavigationMenuOffice
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
            this.panMenu = new System.Windows.Forms.Panel();
            this.panChilds = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // panMenu
            // 
            this.panMenu.Dock = System.Windows.Forms.DockStyle.Top;
            this.panMenu.Location = new System.Drawing.Point(0, 0);
            this.panMenu.MaximumSize = new System.Drawing.Size(0, 25);
            this.panMenu.MinimumSize = new System.Drawing.Size(0, 25);
            this.panMenu.Name = "panMenu";
            this.panMenu.Size = new System.Drawing.Size(441, 25);
            this.panMenu.TabIndex = 0;
            // 
            // panChilds
            // 
            this.panChilds.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panChilds.Location = new System.Drawing.Point(0, 25);
            this.panChilds.Name = "panChilds";
            this.panChilds.Size = new System.Drawing.Size(441, 100);
            this.panChilds.TabIndex = 1;
            // 
            // UCNavigationMenuOffice
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(57)))), ((int)(((byte)(61)))), ((int)(((byte)(73)))));
            this.Controls.Add(this.panChilds);
            this.Controls.Add(this.panMenu);
            this.Font = new System.Drawing.Font("微软雅黑", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.Name = "UCNavigationMenuOffice";
            this.Size = new System.Drawing.Size(441, 125);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panMenu;
        private System.Windows.Forms.Panel panChilds;
    }
}
