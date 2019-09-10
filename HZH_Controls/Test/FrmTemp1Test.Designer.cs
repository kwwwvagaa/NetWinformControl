namespace Test
{
    partial class FrmTemp1Test
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
            this.ucDataGridView1 = new HZH_Controls.Controls.UCDataGridView();
            this.SuspendLayout();
            // 
            // ucDataGridView1
            // 
            this.ucDataGridView1.BackColor = System.Drawing.Color.White;
            this.ucDataGridView1.Columns = null;
            this.ucDataGridView1.DataSource = null;
            this.ucDataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ucDataGridView1.HeadFont = new System.Drawing.Font("微软雅黑", 12F);
            this.ucDataGridView1.HeadHeight = 40;
            this.ucDataGridView1.HeadPadingLeft = 24;
            this.ucDataGridView1.HeadTextColor = System.Drawing.Color.Black;
            this.ucDataGridView1.IsCloseAutoHeight = false;
            this.ucDataGridView1.IsShowCheckBox = false;
            this.ucDataGridView1.IsShowHead = true;
            this.ucDataGridView1.Location = new System.Drawing.Point(0, 61);
            this.ucDataGridView1.Name = "ucDataGridView1";
            this.ucDataGridView1.Page = null;
            this.ucDataGridView1.RowHeight = 41;
            this.ucDataGridView1.RowType = typeof(HZH_Controls.Controls.UCDataGridViewRow);
            this.ucDataGridView1.Size = new System.Drawing.Size(679, 416);
            this.ucDataGridView1.TabIndex = 3;
            // 
            // FrmTemp1Test
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 477);
            this.Controls.Add(this.ucDataGridView1);
            this.FrmTitle = "表格测试";
            this.IsFullSize = false;
            this.Name = "FrmTemp1Test";
            this.Text = "FrmTemp1Test";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FrmTemp1Test_FormClosing);
            this.Load += new System.EventHandler(this.FrmTemp1Test_Load);
            this.Controls.SetChildIndex(this.ucDataGridView1, 0);
            this.ResumeLayout(false);

        }

        #endregion

        private HZH_Controls.Controls.UCDataGridView ucDataGridView1;
    }
}