namespace Test.UC
{
    partial class UCTestListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTestListView));
            this.ucListView1 = new HZH_Controls.Controls.UCListView();
            this.SuspendLayout();
            // 
            // ucListView1
            // 
            this.ucListView1.BackColor = System.Drawing.Color.White;
            this.ucListView1.DataSource = ((object)(resources.GetObject("ucListView1.DataSource")));
            this.ucListView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucListView1.IsMultiple = false;
            this.ucListView1.ItemType = typeof(HZH_Controls.Controls.UCListViewItem);
            this.ucListView1.Location = new System.Drawing.Point(0, 0);
            this.ucListView1.Margin = new System.Windows.Forms.Padding(0);
            this.ucListView1.Name = "ucListView1";
            this.ucListView1.Page = null;
            this.ucListView1.SelectedSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucListView1.SelectedSource")));
            this.ucListView1.Size = new System.Drawing.Size(624, 590);
            this.ucListView1.TabIndex = 4;
            // 
            // UCTestListView
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucListView1);
            this.Name = "UCTestListView";
            this.Size = new System.Drawing.Size(624, 590);
            this.Load += new System.EventHandler(this.UCTestListView_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCListView ucListView1;
    }
}
