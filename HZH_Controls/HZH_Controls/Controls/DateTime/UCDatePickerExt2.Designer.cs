namespace HZH_Controls.Controls
{
    partial class UCDatePickerExt2
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.txtMinute = new HZH_Controls.Controls.TextBoxEx();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHour = new HZH_Controls.Controls.TextBoxEx();
            this.label3 = new System.Windows.Forms.Label();
            this.txtDay = new HZH_Controls.Controls.TextBoxEx();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMonth = new HZH_Controls.Controls.TextBoxEx();
            this.label1 = new System.Windows.Forms.Label();
            this.txtYear = new HZH_Controls.Controls.TextBoxEx();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txtMinute);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.txtHour);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.txtDay);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtMonth);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtYear);
            this.panel1.Location = new System.Drawing.Point(3, 6);
            this.panel1.MaximumSize = new System.Drawing.Size(0, 27);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 27);
            this.panel1.TabIndex = 10;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Dock = System.Windows.Forms.DockStyle.Left;
            this.label5.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label5.Location = new System.Drawing.Point(301, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 27);
            this.label5.TabIndex = 17;
            this.label5.Text = "分";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMinute
            // 
            this.txtMinute.BackColor = System.Drawing.Color.White;
            this.txtMinute.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMinute.DecLength = 2;
            this.txtMinute.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMinute.Font = new System.Drawing.Font("Arial Unicode MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMinute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtMinute.InputType = HZH_Controls.TextInputType.Integer;
            this.txtMinute.Location = new System.Drawing.Point(272, 0);
            this.txtMinute.MaxValue = new decimal(new int[] {
            59,
            0,
            0,
            0});
            this.txtMinute.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMinute.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtMinute.Name = "txtMinute";
            this.txtMinute.OldText = null;
            this.txtMinute.PromptColor = System.Drawing.Color.Gray;
            this.txtMinute.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMinute.PromptText = "";
            this.txtMinute.RegexPattern = "";
            this.txtMinute.Size = new System.Drawing.Size(29, 27);
            this.txtMinute.TabIndex = 5;
            this.txtMinute.Text = "59";
            this.txtMinute.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMinute.Leave += new System.EventHandler(this.txtMinute_Leave);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label4.Location = new System.Drawing.Point(240, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 27);
            this.label4.TabIndex = 16;
            this.label4.Text = "时";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtHour
            // 
            this.txtHour.BackColor = System.Drawing.Color.White;
            this.txtHour.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtHour.DecLength = 2;
            this.txtHour.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtHour.Font = new System.Drawing.Font("Arial Unicode MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtHour.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtHour.InputType = HZH_Controls.TextInputType.Integer;
            this.txtHour.Location = new System.Drawing.Point(211, 0);
            this.txtHour.MaxValue = new decimal(new int[] {
            23,
            0,
            0,
            0});
            this.txtHour.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtHour.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtHour.Name = "txtHour";
            this.txtHour.OldText = null;
            this.txtHour.PromptColor = System.Drawing.Color.Gray;
            this.txtHour.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtHour.PromptText = "";
            this.txtHour.RegexPattern = "";
            this.txtHour.Size = new System.Drawing.Size(29, 27);
            this.txtHour.TabIndex = 4;
            this.txtHour.Text = "23";
            this.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtHour.TextChanged += new System.EventHandler(this.txtHour_TextChanged);
            this.txtHour.Leave += new System.EventHandler(this.txtHour_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.White;
            this.label3.Dock = System.Windows.Forms.DockStyle.Left;
            this.label3.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label3.Location = new System.Drawing.Point(173, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 27);
            this.label3.TabIndex = 14;
            this.label3.Text = " 日";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDay
            // 
            this.txtDay.BackColor = System.Drawing.Color.White;
            this.txtDay.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtDay.DecLength = 2;
            this.txtDay.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtDay.Font = new System.Drawing.Font("Arial Unicode MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtDay.InputType = HZH_Controls.TextInputType.Integer;
            this.txtDay.Location = new System.Drawing.Point(144, 0);
            this.txtDay.MaxValue = new decimal(new int[] {
            31,
            0,
            0,
            0});
            this.txtDay.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtDay.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtDay.Name = "txtDay";
            this.txtDay.OldText = null;
            this.txtDay.PromptColor = System.Drawing.Color.Gray;
            this.txtDay.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtDay.PromptText = "";
            this.txtDay.RegexPattern = "";
            this.txtDay.Size = new System.Drawing.Size(29, 27);
            this.txtDay.TabIndex = 3;
            this.txtDay.Text = "12";
            this.txtDay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtDay.TextChanged += new System.EventHandler(this.txtDay_TextChanged);
            this.txtDay.Leave += new System.EventHandler(this.txtDay_Leave);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.White;
            this.label2.Dock = System.Windows.Forms.DockStyle.Left;
            this.label2.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label2.Location = new System.Drawing.Point(112, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 27);
            this.label2.TabIndex = 12;
            this.label2.Text = "月";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtMonth
            // 
            this.txtMonth.BackColor = System.Drawing.Color.White;
            this.txtMonth.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMonth.DecLength = 2;
            this.txtMonth.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtMonth.Font = new System.Drawing.Font("Arial Unicode MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMonth.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtMonth.InputType = HZH_Controls.TextInputType.Integer;
            this.txtMonth.Location = new System.Drawing.Point(83, 0);
            this.txtMonth.MaxValue = new decimal(new int[] {
            12,
            0,
            0,
            0});
            this.txtMonth.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtMonth.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtMonth.Name = "txtMonth";
            this.txtMonth.OldText = null;
            this.txtMonth.PromptColor = System.Drawing.Color.Gray;
            this.txtMonth.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtMonth.PromptText = "";
            this.txtMonth.RegexPattern = "";
            this.txtMonth.Size = new System.Drawing.Size(29, 27);
            this.txtMonth.TabIndex = 2;
            this.txtMonth.Text = "12";
            this.txtMonth.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtMonth.TextChanged += new System.EventHandler(this.txtMonth_TextChanged);
            this.txtMonth.Leave += new System.EventHandler(this.txtMonth_Leave);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Dock = System.Windows.Forms.DockStyle.Left;
            this.label1.Font = new System.Drawing.Font("微软雅黑", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.label1.Location = new System.Drawing.Point(51, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 27);
            this.label1.TabIndex = 10;
            this.label1.Text = "年";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtYear
            // 
            this.txtYear.BackColor = System.Drawing.Color.White;
            this.txtYear.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtYear.DecLength = 2;
            this.txtYear.Dock = System.Windows.Forms.DockStyle.Left;
            this.txtYear.Font = new System.Drawing.Font("Arial Unicode MS", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtYear.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.txtYear.InputType = HZH_Controls.TextInputType.Integer;
            this.txtYear.Location = new System.Drawing.Point(0, 0);
            this.txtYear.MaxValue = new decimal(new int[] {
            2099,
            0,
            0,
            0});
            this.txtYear.MinValue = new decimal(new int[] {
            0,
            0,
            0,
            0});
            this.txtYear.MyRectangle = new System.Drawing.Rectangle(0, 0, 0, 0);
            this.txtYear.Name = "txtYear";
            this.txtYear.OldText = null;
            this.txtYear.PromptColor = System.Drawing.Color.Gray;
            this.txtYear.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.txtYear.PromptText = "";
            this.txtYear.RegexPattern = "";
            this.txtYear.Size = new System.Drawing.Size(51, 27);
            this.txtYear.TabIndex = 1;
            this.txtYear.Text = "2019";
            this.txtYear.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtYear.TextChanged += new System.EventHandler(this.txtYear_TextChanged);
            this.txtYear.Leave += new System.EventHandler(this.txtYear_Leave);
            // 
            // UCDatePickerExt2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Transparent;
            this.ConerRadius = 5;
            this.Controls.Add(this.panel1);
            this.FillColor = System.Drawing.Color.White;
            this.IsRadius = true;
            this.IsShowRect = true;
            this.Name = "UCDatePickerExt2";
            this.Size = new System.Drawing.Size(336, 39);
            this.Load += new System.EventHandler(this.UCDatePickerExt2_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
        private TextBoxEx txtMinute;
        private System.Windows.Forms.Label label4;
        private TextBoxEx txtHour;
        private System.Windows.Forms.Label label3;
        private TextBoxEx txtDay;
        private System.Windows.Forms.Label label2;
        private TextBoxEx txtMonth;
        private System.Windows.Forms.Label label1;
        private TextBoxEx txtYear;

    }
}
