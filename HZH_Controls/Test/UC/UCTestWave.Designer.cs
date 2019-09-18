namespace Test.UC
{
    partial class UCTestWave
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ucTrackBar3 = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBar2 = new HZH_Controls.Controls.UCTrackBar();
            this.ucTrackBar1 = new HZH_Controls.Controls.UCTrackBar();
            this.ucWave2 = new HZH_Controls.Controls.UCWave();
            this.ucWave1 = new HZH_Controls.Controls.UCWave();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(171, 296);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 11;
            this.label1.Text = "波速度";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 371);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 12;
            this.label2.Text = "波高";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(175, 433);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 13;
            this.label3.Text = "波宽";
            // 
            // ucTrackBar3
            // 
            this.ucTrackBar3.DcimalDigits = 0;
            this.ucTrackBar3.IsShowTips = true;
            this.ucTrackBar3.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBar3.LineWidth = 10F;
            this.ucTrackBar3.Location = new System.Drawing.Point(15, 389);
            this.ucTrackBar3.MaxValue = 300F;
            this.ucTrackBar3.MinValue = 50F;
            this.ucTrackBar3.Name = "ucTrackBar3";
            this.ucTrackBar3.Size = new System.Drawing.Size(350, 30);
            this.ucTrackBar3.TabIndex = 10;
            this.ucTrackBar3.Text = "ucTrackBar1";
            this.ucTrackBar3.TipsFormat = null;
            this.ucTrackBar3.Value = 200F;
            this.ucTrackBar3.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrackBar3.ValueChanged += new System.EventHandler(this.ucTrackBar3_ValueChanged);
            // 
            // ucTrackBar2
            // 
            this.ucTrackBar2.DcimalDigits = 0;
            this.ucTrackBar2.IsShowTips = true;
            this.ucTrackBar2.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBar2.LineWidth = 10F;
            this.ucTrackBar2.Location = new System.Drawing.Point(15, 327);
            this.ucTrackBar2.MaxValue = 50F;
            this.ucTrackBar2.MinValue = 10F;
            this.ucTrackBar2.Name = "ucTrackBar2";
            this.ucTrackBar2.Size = new System.Drawing.Size(350, 30);
            this.ucTrackBar2.TabIndex = 10;
            this.ucTrackBar2.Text = "ucTrackBar1";
            this.ucTrackBar2.TipsFormat = null;
            this.ucTrackBar2.Value = 30F;
            this.ucTrackBar2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrackBar2.ValueChanged += new System.EventHandler(this.ucTrackBar2_ValueChanged);
            // 
            // ucTrackBar1
            // 
            this.ucTrackBar1.DcimalDigits = 0;
            this.ucTrackBar1.IsShowTips = true;
            this.ucTrackBar1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(231)))), ((int)(((byte)(237)))));
            this.ucTrackBar1.LineWidth = 10F;
            this.ucTrackBar1.Location = new System.Drawing.Point(15, 261);
            this.ucTrackBar1.MaxValue = 100F;
            this.ucTrackBar1.MinValue = 10F;
            this.ucTrackBar1.Name = "ucTrackBar1";
            this.ucTrackBar1.Size = new System.Drawing.Size(350, 30);
            this.ucTrackBar1.TabIndex = 10;
            this.ucTrackBar1.Text = "ucTrackBar1";
            this.ucTrackBar1.TipsFormat = null;
            this.ucTrackBar1.Value = 50F;
            this.ucTrackBar1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTrackBar1.ValueChanged += new System.EventHandler(this.ucTrackBar1_ValueChanged);
            // 
            // ucWave2
            // 
            this.ucWave2.Location = new System.Drawing.Point(15, 122);
            this.ucWave2.Name = "ucWave2";
            this.ucWave2.Size = new System.Drawing.Size(350, 84);
            this.ucWave2.TabIndex = 9;
            this.ucWave2.Text = "ucWave1";
            this.ucWave2.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(150)))), ((int)(((byte)(136)))));
            this.ucWave2.WaveHeight = 30;
            this.ucWave2.WaveSleep = 50;
            this.ucWave2.WaveWidth = 200;
            // 
            // ucWave1
            // 
            this.ucWave1.Location = new System.Drawing.Point(15, 21);
            this.ucWave1.Name = "ucWave1";
            this.ucWave1.Size = new System.Drawing.Size(350, 84);
            this.ucWave1.TabIndex = 9;
            this.ucWave1.Text = "ucWave1";
            this.ucWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucWave1.WaveHeight = 30;
            this.ucWave1.WaveSleep = 50;
            this.ucWave1.WaveWidth = 200;
            // 
            // UCTestWave
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ucTrackBar3);
            this.Controls.Add(this.ucTrackBar2);
            this.Controls.Add(this.ucTrackBar1);
            this.Controls.Add(this.ucWave2);
            this.Controls.Add(this.ucWave1);
            this.Name = "UCTestWave";
            this.Size = new System.Drawing.Size(695, 577);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCWave ucWave1;
        private HZH_Controls.Controls.UCWave ucWave2;
        private HZH_Controls.Controls.UCTrackBar ucTrackBar1;
        private HZH_Controls.Controls.UCTrackBar ucTrackBar2;
        private HZH_Controls.Controls.UCTrackBar ucTrackBar3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}
