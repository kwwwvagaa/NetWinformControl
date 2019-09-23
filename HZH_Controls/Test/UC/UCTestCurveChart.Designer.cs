namespace Test.UC
{
    partial class UCTestCurveChart
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
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ucCurve2 = new HZH_Controls.Controls.UCCurve();
            this.ucCurve1 = new HZH_Controls.Controls.UCCurve();
            this.ucCurve3 = new HZH_Controls.Controls.UCCurve();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 200;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ucCurve2
            // 
            this.ucCurve2.ColorDashLines = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucCurve2.CurveNameWidth = 50;
            this.ucCurve2.IntervalAbscissaText = 20;
            this.ucCurve2.IsAbscissaStrech = true;
            this.ucCurve2.IsRenderRightCoordinate = false;
            this.ucCurve2.Location = new System.Drawing.Point(40, 327);
            this.ucCurve2.Name = "ucCurve2";
            this.ucCurve2.Size = new System.Drawing.Size(963, 318);
            this.ucCurve2.StrechDataCountMax = 100;
            this.ucCurve2.TabIndex = 1;
            this.ucCurve2.Title = "动态数据";
            // 
            // ucCurve1
            // 
            this.ucCurve1.ColorDashLines = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucCurve1.IntervalAbscissaText = -1;
            this.ucCurve1.IsAbscissaStrech = true;
            this.ucCurve1.Location = new System.Drawing.Point(40, 22);
            this.ucCurve1.Name = "ucCurve1";
            this.ucCurve1.Size = new System.Drawing.Size(963, 299);
            this.ucCurve1.StrechDataCountMax = 7;
            this.ucCurve1.TabIndex = 0;
            this.ucCurve1.Title = "一周生产";
            // 
            // ucCurve3
            // 
            this.ucCurve3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(243)))), ((int)(((byte)(220)))), ((int)(((byte)(219)))));
            this.ucCurve3.ColorDashLines = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCurve3.ColorLinesAndText = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCurve3.CurveNameWidth = 50;
            this.ucCurve3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucCurve3.IntervalAbscissaText = -1;
            this.ucCurve3.IsAbscissaStrech = true;
            this.ucCurve3.IsRenderRightCoordinate = false;
            this.ucCurve3.Location = new System.Drawing.Point(40, 651);
            this.ucCurve3.Name = "ucCurve3";
            this.ucCurve3.Size = new System.Drawing.Size(963, 534);
            this.ucCurve3.StrechDataCountMax = 6;
            this.ucCurve3.TabIndex = 1;
            this.ucCurve3.Title = "小明模拟考试成绩走势";
            this.ucCurve3.ValueSegment = 10;
            // 
            // UCTestCurveChart
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.ucCurve3);
            this.Controls.Add(this.ucCurve2);
            this.Controls.Add(this.ucCurve1);
            this.Name = "UCTestCurveChart";
            this.Size = new System.Drawing.Size(1041, 1239);
            this.Load += new System.EventHandler(this.UCTestCurveChart_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCCurve ucCurve1;
        private HZH_Controls.Controls.UCCurve ucCurve2;
        private System.Windows.Forms.Timer timer1;
        private HZH_Controls.Controls.UCCurve ucCurve3;
    }
}
