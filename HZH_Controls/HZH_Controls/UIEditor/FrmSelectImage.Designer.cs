namespace HZH_Controls
{
    partial class FrmSelectImage
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.ucTextBoxEx1 = new HZH_Controls.Controls.UCTextBoxEx();
            this.tabControlExt1 = new HZH_Controls.Controls.TabControlExt();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtForeColor = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtBackcolor = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            this.tabControlExt1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.txtBackcolor);
            this.panel1.Controls.Add(this.txtForeColor);
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.ucTextBoxEx1);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(122, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(532, 51);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "图标大小";
            // 
            // ucTextBoxEx1
            // 
            this.ucTextBoxEx1.BackColor = System.Drawing.Color.Transparent;
            this.ucTextBoxEx1.ConerRadius = 5;
            this.ucTextBoxEx1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.ucTextBoxEx1.DecLength = 2;
            this.ucTextBoxEx1.FillColor = System.Drawing.Color.Empty;
            this.ucTextBoxEx1.FocusBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(77)))), ((int)(((byte)(59)))));
            this.ucTextBoxEx1.Font = new System.Drawing.Font("微软雅黑", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxEx1.InputText = "32";
            this.ucTextBoxEx1.InputType = HZH_Controls.TextInputType.Integer;
            this.ucTextBoxEx1.IsFocusColor = true;
            this.ucTextBoxEx1.IsRadius = true;
            this.ucTextBoxEx1.IsShowClearBtn = false;
            this.ucTextBoxEx1.IsShowKeyboard = false;
            this.ucTextBoxEx1.IsShowRect = true;
            this.ucTextBoxEx1.IsShowSearchBtn = false;
            this.ucTextBoxEx1.KeyBoardType = HZH_Controls.Controls.KeyBoardType.UCKeyBorderAll_EN;
            this.ucTextBoxEx1.Location = new System.Drawing.Point(72, 4);
            this.ucTextBoxEx1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.ucTextBoxEx1.MaxValue = new decimal(new int[] {
            100,
            0,
            0,
            0});
            this.ucTextBoxEx1.MinValue = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.ucTextBoxEx1.Name = "ucTextBoxEx1";
            this.ucTextBoxEx1.Padding = new System.Windows.Forms.Padding(5);
            this.ucTextBoxEx1.PromptColor = System.Drawing.Color.Gray;
            this.ucTextBoxEx1.PromptFont = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucTextBoxEx1.PromptText = "";
            this.ucTextBoxEx1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucTextBoxEx1.RectWidth = 1;
            this.ucTextBoxEx1.RegexPattern = "";
            this.ucTextBoxEx1.Size = new System.Drawing.Size(64, 42);
            this.ucTextBoxEx1.TabIndex = 1;
            // 
            // tabControlExt1
            // 
            this.tabControlExt1.Controls.Add(this.tabPage1);
            this.tabControlExt1.Controls.Add(this.tabPage2);
            this.tabControlExt1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControlExt1.IsShowCloseBtn = false;
            this.tabControlExt1.ItemSize = new System.Drawing.Size(0, 50);
            this.tabControlExt1.Location = new System.Drawing.Point(0, 0);
            this.tabControlExt1.Name = "tabControlExt1";
            this.tabControlExt1.SelectedIndex = 0;
            this.tabControlExt1.Size = new System.Drawing.Size(654, 493);
            this.tabControlExt1.TabIndex = 0;
            this.tabControlExt1.SelectedIndexChanged += new System.EventHandler(this.tabControlExt1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.AutoScroll = true;
            this.tabPage1.Controls.Add(this.flowLayoutPanel1);
            this.tabPage1.Location = new System.Drawing.Point(4, 54);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(646, 435);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Awesome";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.AutoScroll = true;
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(640, 429);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.AutoScroll = true;
            this.tabPage2.Controls.Add(this.flowLayoutPanel2);
            this.tabPage2.Location = new System.Drawing.Point(4, 54);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(646, 435);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Elegant";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.AutoScroll = true;
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(640, 429);
            this.flowLayoutPanel2.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(157, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "前景色";
            // 
            // txtForeColor
            // 
            this.txtForeColor.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(85)))), ((int)(((byte)(51)))));
            this.txtForeColor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtForeColor.Font = new System.Drawing.Font("宋体", 12F);
            this.txtForeColor.ForeColor = System.Drawing.Color.White;
            this.txtForeColor.Location = new System.Drawing.Point(204, 16);
            this.txtForeColor.Name = "txtForeColor";
            this.txtForeColor.ReadOnly = true;
            this.txtForeColor.Size = new System.Drawing.Size(111, 19);
            this.txtForeColor.TabIndex = 3;
            this.txtForeColor.Text = "255, 85, 51";
            this.txtForeColor.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(336, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "背景色";
            // 
            // txtBackcolor
            // 
            this.txtBackcolor.BackColor = System.Drawing.Color.White;
            this.txtBackcolor.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBackcolor.Font = new System.Drawing.Font("宋体", 12F);
            this.txtBackcolor.ForeColor = System.Drawing.Color.Black;
            this.txtBackcolor.Location = new System.Drawing.Point(383, 15);
            this.txtBackcolor.Name = "txtBackcolor";
            this.txtBackcolor.ReadOnly = true;
            this.txtBackcolor.Size = new System.Drawing.Size(111, 19);
            this.txtBackcolor.TabIndex = 3;
            this.txtBackcolor.Text = "255,255,255";
            this.txtBackcolor.DoubleClick += new System.EventHandler(this.textBox1_DoubleClick);
            // 
            // FrmSelectImage
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(654, 493);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tabControlExt1);
            this.Name = "FrmSelectImage";
            this.Text = "选择图标";
            this.Load += new System.EventHandler(this.FrmSelectImage_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabControlExt1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private HZH_Controls.Controls.TabControlExt tabControlExt1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private Controls.UCTextBoxEx ucTextBoxEx1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBackcolor;
        private System.Windows.Forms.TextBox txtForeColor;
        private System.Windows.Forms.Label label3;
    }
}