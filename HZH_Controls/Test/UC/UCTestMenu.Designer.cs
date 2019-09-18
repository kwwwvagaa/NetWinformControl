namespace Test.UC
{
    partial class UCTestMenu
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
            this.ucMenu1 = new HZH_Controls.Controls.UCMenu();
            this.ucSplitLine_V1 = new HZH_Controls.Controls.UCSplitLine_V();
            this.ucMenu2 = new HZH_Controls.Controls.UCMenu();
            this.SuspendLayout();
            // 
            // ucMenu1
            // 
            this.ucMenu1.AutoScroll = true;
            this.ucMenu1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.ucMenu1.ChildrenItemStyles = null;
            this.ucMenu1.ChildrenItemType = typeof(HZH_Controls.Controls.UCMenuChildrenItem);
            this.ucMenu1.DataSource = null;
            this.ucMenu1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMenu1.IsShowFirstItem = true;
            this.ucMenu1.Location = new System.Drawing.Point(0, 0);
            this.ucMenu1.MenuStyle = HZH_Controls.Controls.MenuStyle.Fill;
            this.ucMenu1.Name = "ucMenu1";
            this.ucMenu1.ParentItemStyles = null;
            this.ucMenu1.ParentItemType = typeof(HZH_Controls.Controls.UCMenuParentItem);
            this.ucMenu1.Size = new System.Drawing.Size(194, 645);
            this.ucMenu1.TabIndex = 1;
            // 
            // ucSplitLine_V1
            // 
            this.ucSplitLine_V1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucSplitLine_V1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucSplitLine_V1.Location = new System.Drawing.Point(194, 0);
            this.ucSplitLine_V1.Name = "ucSplitLine_V1";
            this.ucSplitLine_V1.Size = new System.Drawing.Size(1, 645);
            this.ucSplitLine_V1.TabIndex = 2;
            this.ucSplitLine_V1.TabStop = false;
            // 
            // ucMenu2
            // 
            this.ucMenu2.AutoScroll = true;
            this.ucMenu2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(30)))), ((int)(((byte)(39)))));
            this.ucMenu2.ChildrenItemStyles = null;
            this.ucMenu2.ChildrenItemType = typeof(HZH_Controls.Controls.UCMenuChildrenItem);
            this.ucMenu2.DataSource = null;
            this.ucMenu2.Dock = System.Windows.Forms.DockStyle.Left;
            this.ucMenu2.IsShowFirstItem = true;
            this.ucMenu2.Location = new System.Drawing.Point(195, 0);
            this.ucMenu2.MenuStyle = HZH_Controls.Controls.MenuStyle.Top;
            this.ucMenu2.Name = "ucMenu2";
            this.ucMenu2.ParentItemStyles = null;
            this.ucMenu2.ParentItemType = typeof(HZH_Controls.Controls.UCMenuParentItem);
            this.ucMenu2.Size = new System.Drawing.Size(194, 645);
            this.ucMenu2.TabIndex = 3;
            // 
            // UCTestMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucMenu2);
            this.Controls.Add(this.ucSplitLine_V1);
            this.Controls.Add(this.ucMenu1);
            this.Name = "UCTestMenu";
            this.Size = new System.Drawing.Size(648, 645);
            this.Load += new System.EventHandler(this.UCTestMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCMenu ucMenu1;
        private HZH_Controls.Controls.UCSplitLine_V ucSplitLine_V1;
        private HZH_Controls.Controls.UCMenu ucMenu2;

    }
}
