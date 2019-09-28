using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestGraphicalOverlay : UserControl
    {
        Random r = new Random();
        bool blnColor = true;
        public UCTestGraphicalOverlay()
        {
            InitializeComponent();
            this.Paint += UCTestGraphicalOverlay_Paint;
        }

        void UCTestGraphicalOverlay_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void graphicalOverlay1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.SetGDIHigh();
            if (blnColor)
            {
                foreach (Control item in this.Controls)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, r.Next(0, 255), r.Next(0, 255), r.Next(0, 255))), item.Bounds);
                }
               
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = new Button();
            btn.Text = "随机按钮";
            btn.Location = new Point(r.Next(0, this.Width - btn.Width), r.Next(0, this.Height - btn.Height));
            this.Controls.Add(btn);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            blnColor = !blnColor;
            this.Invalidate(true);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Label lbl = new Label();
            lbl.Text = "随机标签";
            lbl.Location = new Point(r.Next(0, this.Width - lbl.Width), r.Next(0, this.Height - lbl.Height));
            this.Controls.Add(lbl);
        }
    }
}
