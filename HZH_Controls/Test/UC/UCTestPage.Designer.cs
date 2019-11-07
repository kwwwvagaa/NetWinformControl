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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ucPagerControl22 = new HZH_Controls.Controls.UCPagerControl2();
            this.ucPagerControl2 = new HZH_Controls.Controls.UCPagerControl();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // ucPagerControl21
            // 
            this.ucPagerControl21.BackColor = System.Drawing.Color.White;
            this.ucPagerControl21.DataSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucPagerControl21.DataSource")));
            this.ucPagerControl21.Location = new System.Drawing.Point(21, 35);
            this.ucPagerControl21.Name = "ucPagerControl21";
            this.ucPagerControl21.PageCount = 0;
            this.ucPagerControl21.PageIndex = 1;
            this.ucPagerControl21.PageModel = HZH_Controls.Controls.PageModel.Soure;
            this.ucPagerControl21.PageSize = 0;
            this.ucPagerControl21.Size = new System.Drawing.Size(709, 41);
            this.ucPagerControl21.StartIndex = 0;
            this.ucPagerControl21.TabIndex = 5;
            // 
            // ucPagerControl1
            // 
            this.ucPagerControl1.DataSource = null;
            this.ucPagerControl1.Location = new System.Drawing.Point(21, 82);
            this.ucPagerControl1.Name = "ucPagerControl1";
            this.ucPagerControl1.PageCount = 0;
            this.ucPagerControl1.PageIndex = 1;
            this.ucPagerControl1.PageModel = HZH_Controls.Controls.PageModel.Soure;
            this.ucPagerControl1.PageSize = 1;
            this.ucPagerControl1.Size = new System.Drawing.Size(304, 58);
            this.ucPagerControl1.StartIndex = 0;
            this.ucPagerControl1.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(477, 128);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(197, 12);
            this.label1.TabIndex = 7;
            this.label1.Text = "模拟1000条数据，每页10条展示分页";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ucPagerControl21);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.ucPagerControl1);
            this.groupBox1.Location = new System.Drawing.Point(15, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(753, 176);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "数据模式（PageModel=Source）";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ucPagerControl22);
            this.groupBox2.Controls.Add(this.ucPagerControl2);
            this.groupBox2.Location = new System.Drawing.Point(15, 216);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(753, 176);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "页数模式（PageModel=PageCount）";
            // 
            // ucPagerControl22
            // 
            this.ucPagerControl22.BackColor = System.Drawing.Color.White;
            this.ucPagerControl22.DataSource = ((System.Collections.Generic.List<object>)(resources.GetObject("ucPagerControl22.DataSource")));
            this.ucPagerControl22.Location = new System.Drawing.Point(21, 35);
            this.ucPagerControl22.Name = "ucPagerControl22";
            this.ucPagerControl22.PageCount = 0;
            this.ucPagerControl22.PageIndex = 1;
            this.ucPagerControl22.PageModel = HZH_Controls.Controls.PageModel.PageCount;
            this.ucPagerControl22.PageSize = 0;
            this.ucPagerControl22.Size = new System.Drawing.Size(709, 41);
            this.ucPagerControl22.StartIndex = 0;
            this.ucPagerControl22.TabIndex = 5;
            // 
            // ucPagerControl2
            // 
            this.ucPagerControl2.DataSource = null;
            this.ucPagerControl2.Location = new System.Drawing.Point(21, 82);
            this.ucPagerControl2.Name = "ucPagerControl2";
            this.ucPagerControl2.PageCount = 0;
            this.ucPagerControl2.PageIndex = 1;
            this.ucPagerControl2.PageModel = HZH_Controls.Controls.PageModel.PageCount;
            this.ucPagerControl2.PageSize = 1;
            this.ucPagerControl2.Size = new System.Drawing.Size(304, 58);
            this.ucPagerControl2.StartIndex = 0;
            this.ucPagerControl2.TabIndex = 6;
            // 
            // UCTestPage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "UCTestPage";
            this.Size = new System.Drawing.Size(782, 567);
            this.Load += new System.EventHandler(this.UCTestPage_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCPagerControl2 ucPagerControl21;
        private HZH_Controls.Controls.UCPagerControl ucPagerControl1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private HZH_Controls.Controls.UCPagerControl2 ucPagerControl22;
        private HZH_Controls.Controls.UCPagerControl ucPagerControl2;
    }
}
