namespace HZH_Controls.Controls
{
    partial class UCTransfer
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UCTransfer));
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.ucControlBase2 = new HZH_Controls.Controls.UCControlBase();
            this.dgvRight = new HZH_Controls.Controls.UCDataGridView();
            this.btnLeft = new HZH_Controls.Controls.UCBtnImg();
            this.btnRight = new HZH_Controls.Controls.UCBtnImg();
            this.ucControlBase1 = new HZH_Controls.Controls.UCControlBase();
            this.dgvLeft = new HZH_Controls.Controls.UCDataGridView();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.ucControlBase2.SuspendLayout();
            this.ucControlBase1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.ucControlBase2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.ucControlBase1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(451, 397);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnLeft);
            this.panel1.Controls.Add(this.btnRight);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(198, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(54, 391);
            this.panel1.TabIndex = 0;
            // 
            // ucControlBase2
            // 
            this.ucControlBase2.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBase2.ConerRadius = 5;
            this.ucControlBase2.Controls.Add(this.dgvRight);
            this.ucControlBase2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucControlBase2.FillColor = System.Drawing.Color.Transparent;
            this.ucControlBase2.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucControlBase2.IsRadius = true;
            this.ucControlBase2.IsShowRect = true;
            this.ucControlBase2.Location = new System.Drawing.Point(255, 0);
            this.ucControlBase2.Margin = new System.Windows.Forms.Padding(0);
            this.ucControlBase2.Name = "ucControlBase2";
            this.ucControlBase2.Padding = new System.Windows.Forms.Padding(1);
            this.ucControlBase2.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucControlBase2.RectWidth = 1;
            this.ucControlBase2.Size = new System.Drawing.Size(196, 397);
            this.ucControlBase2.TabIndex = 4;
            // 
            // dgvRight
            // 
           
            this.dgvRight.BackColor = System.Drawing.Color.White;
            this.dgvRight.Columns = null;
            this.dgvRight.DataSource = null;
            this.dgvRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRight.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dgvRight.HeadHeight = 40;
            this.dgvRight.HeadPadingLeft = 0;
            this.dgvRight.HeadTextColor = System.Drawing.Color.Black;
           
            this.dgvRight.IsShowCheckBox = true;
            this.dgvRight.IsShowHead = true;
            this.dgvRight.Location = new System.Drawing.Point(1, 1);
            this.dgvRight.Name = "dgvRight";           
            this.dgvRight.RowHeight = 40;
            this.dgvRight.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.dgvRight.Size = new System.Drawing.Size(194, 395);
            this.dgvRight.TabIndex = 2;
            // 
            // btnLeft
            // 
            this.btnLeft.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnLeft.BackColor = System.Drawing.Color.White;
            this.btnLeft.BtnBackColor = System.Drawing.Color.White;
            this.btnLeft.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.btnLeft.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLeft.BtnText = "";
            this.btnLeft.ConerRadius = 5;
            this.btnLeft.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLeft.FillColor = System.Drawing.Color.White;
            this.btnLeft.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnLeft.Image = ((System.Drawing.Image)(resources.GetObject("btnLeft.Image")));
            this.btnLeft.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLeft.ImageFontIcons = ((object)(resources.GetObject("btnLeft.ImageFontIcons")));
            this.btnLeft.IsRadius = true;
            this.btnLeft.IsShowRect = true;
            this.btnLeft.IsShowTips = false;
            this.btnLeft.Location = new System.Drawing.Point(5, 203);
            this.btnLeft.Margin = new System.Windows.Forms.Padding(0);
            this.btnLeft.Name = "btnLeft";
            this.btnLeft.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnLeft.RectWidth = 1;
            this.btnLeft.Size = new System.Drawing.Size(44, 31);
            this.btnLeft.TabIndex = 0;
            this.btnLeft.TabStop = false;
            this.btnLeft.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnLeft.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnLeft.TipsText = "";
            this.btnLeft.BtnClick += new System.EventHandler(this.btnLeft_BtnClick);
            // 
            // btnRight
            // 
            this.btnRight.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnRight.BackColor = System.Drawing.Color.White;
            this.btnRight.BtnBackColor = System.Drawing.Color.White;
            this.btnRight.BtnFont = new System.Drawing.Font("微软雅黑", 17F);
            this.btnRight.BtnForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnRight.BtnText = "";
            this.btnRight.ConerRadius = 5;
            this.btnRight.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnRight.FillColor = System.Drawing.Color.White;
            this.btnRight.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.btnRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(102)))), ((int)(((byte)(102)))), ((int)(((byte)(102)))));
            this.btnRight.Image = ((System.Drawing.Image)(resources.GetObject("btnRight.Image")));
            this.btnRight.ImageAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRight.ImageFontIcons = ((object)(resources.GetObject("btnRight.ImageFontIcons")));
            this.btnRight.IsRadius = true;
            this.btnRight.IsShowRect = true;
            this.btnRight.IsShowTips = false;
            this.btnRight.Location = new System.Drawing.Point(5, 157);
            this.btnRight.Margin = new System.Windows.Forms.Padding(0);
            this.btnRight.Name = "btnRight";
            this.btnRight.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.btnRight.RectWidth = 1;
            this.btnRight.Size = new System.Drawing.Size(44, 31);
            this.btnRight.TabIndex = 0;
            this.btnRight.TabStop = false;
            this.btnRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.btnRight.TipsColor = System.Drawing.Color.FromArgb(((int)(((byte)(232)))), ((int)(((byte)(30)))), ((int)(((byte)(99)))));
            this.btnRight.TipsText = "";
            this.btnRight.BtnClick += new System.EventHandler(this.btnRight_BtnClick);
            // 
            // ucControlBase1
            // 
            this.ucControlBase1.BackColor = System.Drawing.Color.Transparent;
            this.ucControlBase1.ConerRadius = 5;
            this.ucControlBase1.Controls.Add(this.dgvLeft);
            this.ucControlBase1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucControlBase1.FillColor = System.Drawing.Color.Transparent;
            this.ucControlBase1.Font = new System.Drawing.Font("微软雅黑", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Pixel);
            this.ucControlBase1.IsRadius = true;
            this.ucControlBase1.IsShowRect = true;
            this.ucControlBase1.Location = new System.Drawing.Point(0, 0);
            this.ucControlBase1.Margin = new System.Windows.Forms.Padding(0);
            this.ucControlBase1.Name = "ucControlBase1";
            this.ucControlBase1.Padding = new System.Windows.Forms.Padding(1);
            this.ucControlBase1.RectColor = System.Drawing.Color.FromArgb(((int)(((byte)(220)))), ((int)(((byte)(220)))), ((int)(((byte)(220)))));
            this.ucControlBase1.RectWidth = 1;
            this.ucControlBase1.Size = new System.Drawing.Size(195, 397);
            this.ucControlBase1.TabIndex = 3;
            // 
            // dgvLeft
            // 
            this.dgvLeft.BackColor = System.Drawing.Color.White;
            this.dgvLeft.Columns = null;
            this.dgvLeft.DataSource = null;
            this.dgvLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvLeft.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
            this.dgvLeft.HeadHeight = 40;
            this.dgvLeft.HeadPadingLeft = 0;
            this.dgvLeft.HeadTextColor = System.Drawing.Color.Black;
            this.dgvLeft.IsShowCheckBox = true;
            this.dgvLeft.IsShowHead = true;
            this.dgvLeft.Location = new System.Drawing.Point(1, 1);
            this.dgvLeft.Name = "dgvLeft";
            this.dgvLeft.RowHeight = 40;
            this.dgvLeft.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.dgvLeft.Size = new System.Drawing.Size(193, 395);
            this.dgvLeft.TabIndex = 2;
            // 
            // UCTransfer
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UCTransfer";
            this.Size = new System.Drawing.Size(451, 397);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ucControlBase2.ResumeLayout(false);
            this.ucControlBase1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel panel1;
        private UCBtnImg btnLeft;
        private UCBtnImg btnRight;
        private UCControlBase ucControlBase1;
        private UCDataGridView dgvLeft;
        private UCControlBase ucControlBase2;
        private UCDataGridView dgvRight;
    }
}
