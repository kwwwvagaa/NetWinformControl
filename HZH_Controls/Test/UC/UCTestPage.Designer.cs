namespace Test.UC
{
    partial class UCTestPage
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTestPage));
            this.ucPagerControl21 = new HZH_Controls.Controls.UCPagerControl2();
            this.ucPagerControl1 = new HZH_Controls.Controls.UCPagerControl();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucPagerControl21
            // 
            this.ucPagerControl21.BackColor = System.Drawing.Color.White;
            this.ucPagerControl21.DataSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucPagerControl21.DataSource")));
            this.ucPagerControl21.Location = new System.Drawing.Point(31, 19);
            this.ucPagerControl21.Name = "ucPagerControl21";
            this.ucPagerControl21.PageCount = 0;
            this.ucPagerControl21.PageIndex = 1;
            this.ucPagerControl21.PageSize = 0;
            this.ucPagerControl21.Size = new System.Drawing.Size(709, 41);
            this.ucPagerControl21.StartIndex = 0;
            this.ucPagerControl21.TabIndex = 5;
            // 
            // ucPagerControl1
            // 
            this.ucPagerControl1.DataSource = null;
            this.ucPagerControl1.Location = new System.Drawing.Point(60, 77);
            this.ucPagerControl1.Name = "ucPagerControl1";
            this.ucPagerControl1.PageCount = 0;
            this.ucPagerControl1.PageIndex = 1;
            this.ucPagerControl1.PageSize = 1;
            this.ucPagerControl1.Size = new System.Drawing.Size(304, 58);
            this.ucPagerControl1.StartIndex = 0;
            this.ucPagerControl1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(58, 182);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "模拟1000条数据，每页10条展示分页";
            // 
            // UCTestPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucPagerControl1);
            this.Controls.Add(this.ucPagerControl21);
            this.Name = "UCTestPage";
            this.Size = new System.Drawing.Size(782, 304);
            this.Load += new System.EventHandler(this.UCTestPage_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCPagerControl2 ucPagerControl21;
        private HZH_Controls.Controls.UCPagerControl ucPagerControl1;
        private System.Windows.Forms.Label label1;
    }
}
