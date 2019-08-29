namespace Test
{
    partial class Form2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.trackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.trackBar2 = new System.Windows.Forms.TrackBar();
            this.label2 = new System.Windows.Forms.Label();
            this.trackBar3 = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.ucTrackBar1 = new HZH_Controls.Controls.UCTrackBar();
            this.ucProcessWave2 = new HZH_Controls.Controls.UCProcessWave();
            this.ucProcessWave1 = new HZH_Controls.Controls.UCProcessWave();
            this.ucWaveWithSource1 = new HZH_Controls.Controls.UCWaveWithSource();
            this.ucWave1 = new HZH_Controls.Controls.UCWave();
            this.ucProcessLineExt1 = new HZH_Controls.Controls.UCProcessLineExt();
            this.ucProcessLine1 = new HZH_Controls.Controls.UCProcessLine();
            this.ucSwitch10 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch9 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch6 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch8 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch5 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch7 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch4 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch3 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch2 = new HZH_Controls.Controls.UCSwitch();
            this.ucSwitch1 = new HZH_Controls.Controls.UCSwitch();
            this.ucCrumbNavigation1 = new HZH_Controls.Controls.UCCrumbNavigation();
            this.ucProcessEllipse2 = new HZH_Controls.Controls.UCProcessEllipse();
            this.ucProcessEllipse1 = new HZH_Controls.Controls.UCProcessEllipse();
            this.ucPanelTitle1 = new HZH_Controls.Controls.UCPanelTitle();
            this.ucStep2 = new HZH_Controls.Controls.UCStep();
            this.ucStep1 = new HZH_Controls.Controls.UCStep();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).BeginInit();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // trackBar1
            // 
            this.trackBar1.Location = new System.Drawing.Point(249, 423);
            this.trackBar1.Maximum = 100;
            this.trackBar1.Minimum = 10;
            this.trackBar1.Name = "trackBar1";
            this.trackBar1.Size = new System.Drawing.Size(350, 45);
            this.trackBar1.SmallChange = 10;
            this.trackBar1.TabIndex = 8;
            this.trackBar1.TickFrequency = 10;
            this.trackBar1.Value = 50;
            this.trackBar1.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(390, 456);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 9;
            this.label1.Text = "波速度";
            // 
            // trackBar2
            // 
            this.trackBar2.Location = new System.Drawing.Point(249, 474);
            this.trackBar2.Maximum = 50;
            this.trackBar2.Minimum = 10;
            this.trackBar2.Name = "trackBar2";
            this.trackBar2.Size = new System.Drawing.Size(350, 45);
            this.trackBar2.SmallChange = 10;
            this.trackBar2.TabIndex = 8;
            this.trackBar2.TickFrequency = 10;
            this.trackBar2.Value = 30;
            this.trackBar2.Scroll += new System.EventHandler(this.trackBar2_Scroll);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(390, 510);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "波高";
            // 
            // trackBar3
            // 
            this.trackBar3.Location = new System.Drawing.Point(249, 537);
            this.trackBar3.Maximum = 300;
            this.trackBar3.Minimum = 50;
            this.trackBar3.Name = "trackBar3";
            this.trackBar3.Size = new System.Drawing.Size(350, 45);
            this.trackBar3.SmallChange = 50;
            this.trackBar3.TabIndex = 8;
            this.trackBar3.TickFrequency = 50;
            this.trackBar3.Value = 200;
            this.trackBar3.Scroll += new System.EventHandler(this.trackBar3_Scroll);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(390, 573);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(29, 12);
            this.label3.TabIndex = 9;
            this.label3.Text = "波宽";
            // 
            // ucTrackBar1
            // 
            this.ucTrackBar1.LineWidth = 10;
            this.ucTrackBar1.Location = new System.Drawing.Point(833, 403);
            this.ucTrackBar1.MaxValue = 100;
            this.ucTrackBar1.MinValue = 0;
            this.ucTrackBar1.Name = "ucTrackBar1";
            this.ucTrackBar1.Size = new System.Drawing.Size(212, 32);
            this.ucTrackBar1.TabIndex = 12;
            this.ucTrackBar1.Text = "ucTrackBar1";
            this.ucTrackBar1.Value = 100;
            // 
            // ucProcessWave2
            // 
            this.ucProcessWave2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.ucProcessWave2.ConerRadius = 0;
            this.ucProcessWave2.FillColor = System.Drawing.Color.Empty;
            this.ucProcessWave2.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucProcessWave2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessWave2.IsRadius = false;
            this.ucProcessWave2.IsRectangle = false;
            this.ucProcessWave2.IsShowRect = true;
            this.ucProcessWave2.Location = new System.Drawing.Point(702, 206);
            this.ucProcessWave2.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucProcessWave2.MaxValue = 100;
            this.ucProcessWave2.Name = "ucProcessWave2";
            this.ucProcessWave2.RectColor = System.Drawing.Color.White;
            this.ucProcessWave2.RectWidth = 4;
            this.ucProcessWave2.Size = new System.Drawing.Size(150, 150);
            this.ucProcessWave2.TabIndex = 11;
            this.ucProcessWave2.Value = 40;
            this.ucProcessWave2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucProcessWave1
            // 
            this.ucProcessWave1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.ucProcessWave1.ConerRadius = 0;
            this.ucProcessWave1.FillColor = System.Drawing.Color.Empty;
            this.ucProcessWave1.Font = new System.Drawing.Font("微软雅黑", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucProcessWave1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessWave1.IsRadius = false;
            this.ucProcessWave1.IsRectangle = true;
            this.ucProcessWave1.IsShowRect = true;
            this.ucProcessWave1.Location = new System.Drawing.Point(629, 367);
            this.ucProcessWave1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucProcessWave1.MaxValue = 100;
            this.ucProcessWave1.Name = "ucProcessWave1";
            this.ucProcessWave1.RectColor = System.Drawing.Color.White;
            this.ucProcessWave1.RectWidth = 4;
            this.ucProcessWave1.Size = new System.Drawing.Size(108, 206);
            this.ucProcessWave1.TabIndex = 11;
            this.ucProcessWave1.Value = 40;
            this.ucProcessWave1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucWaveWithSource1
            // 
            this.ucWaveWithSource1.ConerRadius = 10;
            this.ucWaveWithSource1.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(197)))), ((int)(((byte)(229)))), ((int)(((byte)(250)))));
            this.ucWaveWithSource1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucWaveWithSource1.GridLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucWaveWithSource1.GridLineTextColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucWaveWithSource1.IsRadius = true;
            this.ucWaveWithSource1.IsShowRect = true;
            this.ucWaveWithSource1.LineColor = System.Drawing.Color.FromArgb(((int)(((byte)(150)))), ((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucWaveWithSource1.LineTension = 0.5F;
            this.ucWaveWithSource1.Location = new System.Drawing.Point(756, 14);
            this.ucWaveWithSource1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucWaveWithSource1.Name = "ucWaveWithSource1";
            this.ucWaveWithSource1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(232)))), ((int)(((byte)(232)))));
            this.ucWaveWithSource1.RectWidth = 1;
            this.ucWaveWithSource1.Size = new System.Drawing.Size(586, 182);
            this.ucWaveWithSource1.SleepTime = 1000;
            this.ucWaveWithSource1.TabIndex = 10;
            this.ucWaveWithSource1.WaveWidth = 50;
            // 
            // ucWave1
            // 
            this.ucWave1.Location = new System.Drawing.Point(249, 337);
            this.ucWave1.Name = "ucWave1";
            this.ucWave1.Size = new System.Drawing.Size(350, 74);
            this.ucWave1.TabIndex = 7;
            this.ucWave1.Text = "ucWave1";
            this.ucWave1.WaveColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucWave1.WaveHeight = 30;
            this.ucWave1.WaveSleep = 50;
            this.ucWave1.WaveWidth = 200;
            // 
            // ucProcessLineExt1
            // 
            this.ucProcessLineExt1.BackColor = System.Drawing.Color.Transparent;
            this.ucProcessLineExt1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucProcessLineExt1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessLineExt1.Location = new System.Drawing.Point(406, 253);
            this.ucProcessLineExt1.MaxValue = 100;
            this.ucProcessLineExt1.Name = "ucProcessLineExt1";
            this.ucProcessLineExt1.Size = new System.Drawing.Size(269, 50);
            this.ucProcessLineExt1.TabIndex = 6;
            this.ucProcessLineExt1.Value = 20;
            this.ucProcessLineExt1.ValueBGColor = System.Drawing.Color.White;
            this.ucProcessLineExt1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucProcessLine1
            // 
            this.ucProcessLine1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.ucProcessLine1.Font = new System.Drawing.Font("Arial Unicode MS", 10F);
            this.ucProcessLine1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessLine1.Location = new System.Drawing.Point(406, 204);
            this.ucProcessLine1.MaxValue = 150;
            this.ucProcessLine1.Name = "ucProcessLine1";
            this.ucProcessLine1.Size = new System.Drawing.Size(269, 32);
            this.ucProcessLine1.TabIndex = 5;
            this.ucProcessLine1.Text = "ucProcessLine1";
            this.ucProcessLine1.Value = 150;
            this.ucProcessLine1.ValueBGColor = System.Drawing.Color.White;
            this.ucProcessLine1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucProcessLine1.ValueTextType = HZH_Controls.Controls.ValueTextType.Percent;
            // 
            // ucSwitch10
            // 
            this.ucSwitch10.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch10.Checked = false;
            this.ucSwitch10.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch10.Location = new System.Drawing.Point(126, 463);
            this.ucSwitch10.Name = "ucSwitch10";
            this.ucSwitch10.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch10.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch10.TabIndex = 4;
            this.ucSwitch10.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch10.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch9
            // 
            this.ucSwitch9.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch9.Checked = true;
            this.ucSwitch9.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch9.Location = new System.Drawing.Point(126, 423);
            this.ucSwitch9.Name = "ucSwitch9";
            this.ucSwitch9.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch9.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch9.TabIndex = 4;
            this.ucSwitch9.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch9.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch6
            // 
            this.ucSwitch6.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch6.Checked = false;
            this.ucSwitch6.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch6.Location = new System.Drawing.Point(126, 377);
            this.ucSwitch6.Name = "ucSwitch6";
            this.ucSwitch6.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch6.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch6.TabIndex = 4;
            this.ucSwitch6.Texts = new string[0];
            this.ucSwitch6.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch8
            // 
            this.ucSwitch8.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch8.Checked = false;
            this.ucSwitch8.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch8.Location = new System.Drawing.Point(12, 463);
            this.ucSwitch8.Name = "ucSwitch8";
            this.ucSwitch8.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch8.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch8.TabIndex = 4;
            this.ucSwitch8.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch8.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch5
            // 
            this.ucSwitch5.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch5.Checked = true;
            this.ucSwitch5.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch5.Location = new System.Drawing.Point(126, 337);
            this.ucSwitch5.Name = "ucSwitch5";
            this.ucSwitch5.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch5.SwitchType = HZH_Controls.Controls.SwitchType.Quadrilateral;
            this.ucSwitch5.TabIndex = 4;
            this.ucSwitch5.Texts = new string[0];
            this.ucSwitch5.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch7
            // 
            this.ucSwitch7.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch7.Checked = true;
            this.ucSwitch7.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch7.Location = new System.Drawing.Point(12, 423);
            this.ucSwitch7.Name = "ucSwitch7";
            this.ucSwitch7.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch7.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch7.TabIndex = 4;
            this.ucSwitch7.Texts = new string[] {
        "确定",
        "取消"};
            this.ucSwitch7.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch4
            // 
            this.ucSwitch4.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch4.Checked = false;
            this.ucSwitch4.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch4.Location = new System.Drawing.Point(12, 377);
            this.ucSwitch4.Name = "ucSwitch4";
            this.ucSwitch4.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch4.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch4.TabIndex = 4;
            this.ucSwitch4.Texts = new string[0];
            this.ucSwitch4.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch3
            // 
            this.ucSwitch3.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch3.Checked = true;
            this.ucSwitch3.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch3.Location = new System.Drawing.Point(12, 337);
            this.ucSwitch3.Name = "ucSwitch3";
            this.ucSwitch3.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch3.SwitchType = HZH_Controls.Controls.SwitchType.Ellipse;
            this.ucSwitch3.TabIndex = 4;
            this.ucSwitch3.Texts = new string[0];
            this.ucSwitch3.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch2
            // 
            this.ucSwitch2.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch2.Checked = false;
            this.ucSwitch2.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch2.Location = new System.Drawing.Point(126, 503);
            this.ucSwitch2.Name = "ucSwitch2";
            this.ucSwitch2.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch2.SwitchType = HZH_Controls.Controls.SwitchType.Line;
            this.ucSwitch2.TabIndex = 4;
            this.ucSwitch2.Texts = new string[0];
            this.ucSwitch2.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucSwitch1
            // 
            this.ucSwitch1.BackColor = System.Drawing.Color.Transparent;
            this.ucSwitch1.Checked = true;
            this.ucSwitch1.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucSwitch1.Location = new System.Drawing.Point(12, 503);
            this.ucSwitch1.Name = "ucSwitch1";
            this.ucSwitch1.Size = new System.Drawing.Size(86, 34);
            this.ucSwitch1.SwitchType = HZH_Controls.Controls.SwitchType.Line;
            this.ucSwitch1.TabIndex = 4;
            this.ucSwitch1.Texts = new string[0];
            this.ucSwitch1.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            // 
            // ucCrumbNavigation1
            // 
            this.ucCrumbNavigation1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ucCrumbNavigation1.ForeColor = System.Drawing.Color.White;
            this.ucCrumbNavigation1.Location = new System.Drawing.Point(12, 557);
            this.ucCrumbNavigation1.MinimumSize = new System.Drawing.Size(0, 25);
            this.ucCrumbNavigation1.Name = "ucCrumbNavigation1";
            this.ucCrumbNavigation1.NavColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.ucCrumbNavigation1.Navigations = new string[] {
        "目录1",
        "目录2",
        "目录3",
        "目录4"};
            this.ucCrumbNavigation1.Size = new System.Drawing.Size(222, 25);
            this.ucCrumbNavigation1.TabIndex = 3;
            // 
            // ucProcessEllipse2
            // 
            this.ucProcessEllipse2.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucProcessEllipse2.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucProcessEllipse2.IsShowCoreEllipseBorder = true;
            this.ucProcessEllipse2.Location = new System.Drawing.Point(202, 173);
            this.ucProcessEllipse2.MaxValue = 100;
            this.ucProcessEllipse2.Name = "ucProcessEllipse2";
            this.ucProcessEllipse2.ShowType = HZH_Controls.Controls.ShowType.Sector;
            this.ucProcessEllipse2.Size = new System.Drawing.Size(150, 150);
            this.ucProcessEllipse2.TabIndex = 2;
            this.ucProcessEllipse2.Value = 0;
            this.ucProcessEllipse2.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessEllipse2.ValueMargin = 5;
            this.ucProcessEllipse2.ValueType = HZH_Controls.Controls.ValueType.Percent;
            this.ucProcessEllipse2.ValueWidth = 30;
            // 
            // ucProcessEllipse1
            // 
            this.ucProcessEllipse1.BackEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucProcessEllipse1.CoreEllipseColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucProcessEllipse1.IsShowCoreEllipseBorder = true;
            this.ucProcessEllipse1.Location = new System.Drawing.Point(12, 173);
            this.ucProcessEllipse1.MaxValue = 100;
            this.ucProcessEllipse1.Name = "ucProcessEllipse1";
            this.ucProcessEllipse1.ShowType = HZH_Controls.Controls.ShowType.Ring;
            this.ucProcessEllipse1.Size = new System.Drawing.Size(150, 150);
            this.ucProcessEllipse1.TabIndex = 2;
            this.ucProcessEllipse1.Value = 0;
            this.ucProcessEllipse1.ValueColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucProcessEllipse1.ValueMargin = 0;
            this.ucProcessEllipse1.ValueType = HZH_Controls.Controls.ValueType.Percent;
            this.ucProcessEllipse1.ValueWidth = 30;
            // 
            // ucPanelTitle1
            // 
            this.ucPanelTitle1.BackColor = System.Drawing.Color.Transparent;
            this.ucPanelTitle1.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucPanelTitle1.ConerRadius = 10;
            this.ucPanelTitle1.FillColor = System.Drawing.Color.White;
            this.ucPanelTitle1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucPanelTitle1.IsCanExpand = true;
            this.ucPanelTitle1.IsExpand = false;
            this.ucPanelTitle1.IsRadius = true;
            this.ucPanelTitle1.IsShowRect = true;
            this.ucPanelTitle1.Location = new System.Drawing.Point(406, 14);
            this.ucPanelTitle1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucPanelTitle1.Name = "ucPanelTitle1";
            this.ucPanelTitle1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucPanelTitle1.RectWidth = 1;
            this.ucPanelTitle1.Size = new System.Drawing.Size(316, 182);
            this.ucPanelTitle1.TabIndex = 1;
            this.ucPanelTitle1.Title = "面板标题";
            // 
            // ucStep2
            // 
            this.ucStep2.BackColor = System.Drawing.Color.Transparent;
            this.ucStep2.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucStep2.ImgCompleted = null;
            this.ucStep2.LineWidth = 10;
            this.ucStep2.Location = new System.Drawing.Point(12, 81);
            this.ucStep2.Name = "ucStep2";
            this.ucStep2.Size = new System.Drawing.Size(362, 86);
            this.ucStep2.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucStep2.StepFontColor = System.Drawing.Color.White;
            this.ucStep2.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucStep2.StepIndex = 2;
            this.ucStep2.Steps = new string[] {
        "step1",
        "step2",
        "step3",
        "step4",
        "step5"};
            this.ucStep2.StepWidth = 35;
            this.ucStep2.TabIndex = 0;
            // 
            // ucStep1
            // 
            this.ucStep1.BackColor = System.Drawing.Color.Transparent;
            this.ucStep1.Font = new System.Drawing.Font("微软雅黑", 12F);
            this.ucStep1.ImgCompleted = ((System.Drawing.Image)(resources.GetObject("ucStep1.ImgCompleted")));
            this.ucStep1.LineWidth = 10;
            this.ucStep1.Location = new System.Drawing.Point(12, -2);
            this.ucStep1.Name = "ucStep1";
            this.ucStep1.Size = new System.Drawing.Size(362, 77);
            this.ucStep1.StepBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(180)))), ((int)(((byte)(180)))), ((int)(((byte)(180)))));
            this.ucStep1.StepFontColor = System.Drawing.Color.White;
            this.ucStep1.StepForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(73)))), ((int)(((byte)(119)))), ((int)(((byte)(232)))));
            this.ucStep1.StepIndex = 2;
            this.ucStep1.Steps = new string[] {
        "step1",
        "step2",
        "step3",
        "step4",
        "step5"};
            this.ucStep1.StepWidth = 35;
            this.ucStep1.TabIndex = 0;
            // 
            // Form2
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1438, 594);
            this.Controls.Add(this.ucTrackBar1);
            this.Controls.Add(this.ucProcessWave2);
            this.Controls.Add(this.ucProcessWave1);
            this.Controls.Add(this.ucWaveWithSource1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.trackBar3);
            this.Controls.Add(this.trackBar2);
            this.Controls.Add(this.trackBar1);
            this.Controls.Add(this.ucWave1);
            this.Controls.Add(this.ucProcessLineExt1);
            this.Controls.Add(this.ucProcessLine1);
            this.Controls.Add(this.ucSwitch10);
            this.Controls.Add(this.ucSwitch9);
            this.Controls.Add(this.ucSwitch6);
            this.Controls.Add(this.ucSwitch8);
            this.Controls.Add(this.ucSwitch5);
            this.Controls.Add(this.ucSwitch7);
            this.Controls.Add(this.ucSwitch4);
            this.Controls.Add(this.ucSwitch3);
            this.Controls.Add(this.ucSwitch2);
            this.Controls.Add(this.ucSwitch1);
            this.Controls.Add(this.ucCrumbNavigation1);
            this.Controls.Add(this.ucProcessEllipse2);
            this.Controls.Add(this.ucProcessEllipse1);
            this.Controls.Add(this.ucPanelTitle1);
            this.Controls.Add(this.ucStep2);
            this.Controls.Add(this.ucStep1);
            this.Name = "Form2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form2";
            ((System.ComponentModel.ISupportInitialize)(this.trackBar1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private HZH_Controls.Controls.UCStep ucStep1;
        private HZH_Controls.Controls.UCPanelTitle ucPanelTitle1;
        private HZH_Controls.Controls.UCProcessEllipse ucProcessEllipse1;
        private System.Windows.Forms.Timer timer1;
        private HZH_Controls.Controls.UCCrumbNavigation ucCrumbNavigation1;
        private HZH_Controls.Controls.UCSwitch ucSwitch1;
        private HZH_Controls.Controls.UCSwitch ucSwitch2;
        private HZH_Controls.Controls.UCSwitch ucSwitch3;
        private HZH_Controls.Controls.UCSwitch ucSwitch4;
        private HZH_Controls.Controls.UCSwitch ucSwitch5;
        private HZH_Controls.Controls.UCSwitch ucSwitch6;
        private HZH_Controls.Controls.UCSwitch ucSwitch7;
        private HZH_Controls.Controls.UCSwitch ucSwitch8;
        private HZH_Controls.Controls.UCSwitch ucSwitch9;
        private HZH_Controls.Controls.UCSwitch ucSwitch10;
        private HZH_Controls.Controls.UCProcessEllipse ucProcessEllipse2;
        private HZH_Controls.Controls.UCStep ucStep2;
        private HZH_Controls.Controls.UCProcessLine ucProcessLine1;
        private HZH_Controls.Controls.UCProcessLineExt ucProcessLineExt1;
        private HZH_Controls.Controls.UCWave ucWave1;
        private System.Windows.Forms.TrackBar trackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar trackBar2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TrackBar trackBar3;
        private System.Windows.Forms.Label label3;
        private HZH_Controls.Controls.UCWaveWithSource ucWaveWithSource1;
        private HZH_Controls.Controls.UCProcessWave ucProcessWave1;
        private HZH_Controls.Controls.UCProcessWave ucProcessWave2;
        private HZH_Controls.Controls.UCTrackBar ucTrackBar1;
     
    }
}