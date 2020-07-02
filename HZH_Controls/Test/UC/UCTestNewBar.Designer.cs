namespace Test.UC
{
    partial class UCTestNewBar
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.scrollbarComponent1 = new HZH_Controls.Controls.ScrollbarComponent(this.components);
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "6",
            "2",
            "23",
            "23",
            "23",
            "2323",
            "32",
            "32",
            "32",
            "3",
            "23",
            "2",
            "3",
            "32",
            "32",
            "23",
            "23",
            "2",
            "23",
            "23",
            "23",
            "23",
            "23",
            "23",
            "2",
            "3",
            "2",
            "23",
            "1",
            "3",
            "2",
            "r",
            "rtf",
            "f",
            "2",
            "f"});
            this.listBox1.Location = new System.Drawing.Point(45, 26);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(222, 280);
            this.listBox1.TabIndex = 0;
            this.scrollbarComponent1.SetUserCustomScrollbar(this.listBox1, true);
            // 
            // UCTestNewBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Name = "UCTestNewBar";
            this.Size = new System.Drawing.Size(941, 601);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ListBox listBox1;
        private HZH_Controls.Controls.ScrollbarComponent scrollbarComponent1;
    }
}
