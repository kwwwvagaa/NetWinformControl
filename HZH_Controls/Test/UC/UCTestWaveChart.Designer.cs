namespace Test.UC
{
    partial class UCTestWaveChart
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
            this.components = new System.ComponentModel.Container();
            this.ucWaveChart1 = new HZH_Controls.Controls.UCWaveChart();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucWaveChart2 = new HZH_Controls.Controls.UCWaveChart();
            this.SuspendLayout();
            // 
            // ucWaveChart1
            // 
            this.ucWaveChart1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWaveChart1.ConerRadius = 10;
            this.ucWaveChart1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWaveChart1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucWaveChart1.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWaveChart1.GridLineTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWaveChart1.IsRadius = true;
            this.ucWaveChart1.IsShowRect = true;
            this.ucWaveChart1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWaveChart1.LineTension = 0.5F;
            this.ucWaveChart1.Location = new System.Drawing.Point(33, 28);
            this.ucWaveChart1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucWaveChart1.Name = "ucWaveChart1";
            this.ucWaveChart1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucWaveChart1.RectWidth = 1;
            this.ucWaveChart1.Size = new System.Drawing.Size(409, 197);
            this.ucWaveChart1.SleepTime = 500;
            this.ucWaveChart1.TabIndex = 23;
            this.ucWaveChart1.WaveWidth = 50;
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 500;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucWaveChart2
            // 
            this.ucWaveChart2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ucWaveChart2.ConerRadius = 10;
            this.ucWaveChart2.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucWaveChart2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucWaveChart2.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucWaveChart2.GridLineTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucWaveChart2.IsRadius = true;
            this.ucWaveChart2.IsShowRect = true;
            this.ucWaveChart2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucWaveChart2.LineTension = 0.5F;
            this.ucWaveChart2.Location = new System.Drawing.Point(33, 256);
            this.ucWaveChart2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucWaveChart2.Name = "ucWaveChart2";
            this.ucWaveChart2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucWaveChart2.RectWidth = 1;
            this.ucWaveChart2.Size = new System.Drawing.Size(409, 197);
            this.ucWaveChart2.SleepTime = 500;
            this.ucWaveChart2.TabIndex = 23;
            this.ucWaveChart2.WaveWidth = 50;
            // 
            // UCTestWaveChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucWaveChart2);
            this.Controls.Add(this.ucWaveChart1);
            this.Name = "UCTestWaveChart";
            this.Size = new System.Drawing.Size(486, 538);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCWaveChart ucWaveChart1;
        private System.Windows.Forms.Timer timer1;
        private HZH_Controls.Controls.UCWaveChart ucWaveChart2;
    }
}
