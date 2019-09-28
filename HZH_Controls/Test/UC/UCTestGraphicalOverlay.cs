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
                //using (Bitmap bit = new Bitmap(button4.Width, button4.Height))
                //{
                //    button4.DrawToBitmap(bit, button4.ClientRectangle);
                //    using (Bitmap bitNew = new Bitmap(bit.Width, bit.Height / 3))
                //    {
                //        using (var g = Graphics.FromImage(bitNew))
                //        {
                //            g.DrawImage(bit, new RectangleF(0, 0, bitNew.Width, bitNew.Height), new RectangleF(0, bit.Height - bit.Height / 3, bit.Width, bit.Height / 3), GraphicsUnit.Pixel);
                //        }
                //        bitNew.RotateFlip(RotateFlipType.Rotate180FlipNone);
                //        float flt = 200.0f / bitNew.Height;

                //        for (int i = 0; i < bitNew.Height; i++)
                //        {
                //            for (int j = 0; j < bitNew.Width; j++)
                //            {
                //                Color c = bitNew.GetPixel(j, i);

                //                int a = 200 - (int)(flt * i);
                //                if (a < 0)
                //                    a = 0;
                //                bitNew.SetPixel(j, i, Color.FromArgb(a, c));
                //            }
                //        }
                //        e.Graphics.DrawImage(bitNew, new Point(button4.Location.X, button4.Location.Y + button4.Height + 1));
                //    }
                //}
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
