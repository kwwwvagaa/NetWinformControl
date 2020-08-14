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
            this.ucCalendarNotes_Week1 = new HZH_Controls.Controls.UCCalendarNotes_Week();
            this.ucCalendarNotes1 = new HZH_Controls.Controls.UCCalendarNotes();
            this.SuspendLayout();
            // 
            // ucCalendarNotes_Week1
            // 
            this.ucCalendarNotes_Week1.BackColor = System.Drawing.Color.White;
            this.ucCalendarNotes_Week1.CurrentTime = new System.DateTime(2020, 8, 13, 22, 14, 47, 0);
            this.ucCalendarNotes_Week1.DataSource = null;
            this.ucCalendarNotes_Week1.Location = new System.Drawing.Point(530, 43);
            this.ucCalendarNotes_Week1.Name = "ucCalendarNotes_Week1";
            this.ucCalendarNotes_Week1.ShowCloseButton = true;
            this.ucCalendarNotes_Week1.Size = new System.Drawing.Size(490, 405);
            this.ucCalendarNotes_Week1.SplitLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ucCalendarNotes_Week1.SplitTimeForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(153)))), ((int)(((byte)(153)))));
            this.ucCalendarNotes_Week1.TabIndex = 3;
            // 
            // ucCalendarNotes1
            // 
            this.ucCalendarNotes1.BackColor = System.Drawing.Color.White;
            this.ucCalendarNotes1.CurrentTime = new System.DateTime(2020, 8, 13, 0, 0, 0, 0);
            this.ucCalendarNotes1.DataSource = null;
            this.ucCalendarNotes1.Location = new System.Drawing.Point(28, 43);
            this.ucCalendarNotes1.Name = "ucCalendarNotes1";
            this.ucCalendarNotes1.SelectColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCalendarNotes1.Size = new System.Drawing.Size(441, 346);
            this.ucCalendarNotes1.TabIndex = 2;
            this.ucCalendarNotes1.TipColor = System.Drawing.Color.Green;
            this.ucCalendarNotes1.ClickNote += new HZH_Controls.Controls.UCCalendarNotes.ClickNoteEvent(this.ucCalendarNotes1_ClickNote);
            // 
            // UCTestCalendarNotes
            // 
            this.Controls.Add(this.ucCalendarNotes_Week1);
            this.Controls.Add(this.ucCalendarNotes1);
            this.Name = "UCTestCalendarNotes";
            this.Size = new System.Drawing.Size(1076, 620);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCCalendarNotes ucCalendarNotes1;
        private HZH_Controls.Controls.UCCalendarNotes_Week ucCalendarNotes_Week1;

    }
}
