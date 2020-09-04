namespace Test.UC
{
    partial class UCTestCalendarNotes
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
            this.ucCalendarNotes1 = new HZH_Controls.Controls.UCCalendarNotes();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ucCalendarNotes1
            // 
            this.ucCalendarNotes1.BackColor = System.Drawing.Color.White;
            this.ucCalendarNotes1.CurrentTime = new System.DateTime(2020, 8, 13, 0, 0, 0, 0);
            this.ucCalendarNotes1.DataSource = null;
            this.ucCalendarNotes1.Location = new System.Drawing.Point(28, 3);
            this.ucCalendarNotes1.Name = "ucCalendarNotes1";
            this.ucCalendarNotes1.SelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCalendarNotes1.Size = new System.Drawing.Size(722, 422);
            this.ucCalendarNotes1.TabIndex = 2;
            this.ucCalendarNotes1.TipColor = System.Drawing.Color.Green;
            this.ucCalendarNotes1.ClickNote += new HZH_Controls.Controls.UCCalendarNotes.ClickNoteEvent(this.ucCalendarNotes1_ClickNote);
            this.ucCalendarNotes1.AddClick += new HZH_Controls.Controls.UCCalendarNotes_Week.AddNoteEvent(this.ucCalendarNotes1_AddClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(26, 428);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(287, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "*测试模拟一次、每天、每周、每月、每年的计划处理\r\n";
            // 
            // UCTestCalendarNotes
            // 
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucCalendarNotes1);
            this.Name = "UCTestCalendarNotes";
            this.Size = new System.Drawing.Size(1076, 620);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCCalendarNotes ucCalendarNotes1;
        private System.Windows.Forms.Label label1;

    }
}
