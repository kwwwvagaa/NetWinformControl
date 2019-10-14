using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestColors : UserControl
    {
        public UCTestColors()
        {
            InitializeComponent();
        }

        private void UCTestColors_Load(object sender, EventArgs e)
        {
            for (int i = 0; i < groupBox1.Controls.Count; i++)
            {
                groupBox1.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.StatusColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox2.Controls.Count; i++)
            {
                groupBox2.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.TextColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox3.Controls.Count; i++)
            {
                groupBox3.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.LineColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox4.Controls.Count; i++)
            {
                groupBox4.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.BasisColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox5.Controls.Count; i++)
            {
                groupBox5.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.TableColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox6.Controls.Count; i++)
            {
                groupBox6.Controls[i].BackColor = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.BorderColorsTypes)(i+1)))[0];
            }

            for (int i = 0; i < groupBox7.Controls.Count; i++)
            {
                groupBox7.Controls[i].Paint += UCTestColors_Paint;
            }
        }

        void UCTestColors_Paint(object sender, PaintEventArgs e)
        {
            Control c = sender as Control;
            int i = groupBox7.Controls.IndexOf(c);
            Color[] cs = HZH_Controls.ColorExt.GetInternalColor(((HZH_Controls.GradientColorsTypes)(i+1)));
            HZH_Controls.ControlHelper.SetGDIHigh(e.Graphics);
            LinearGradientBrush lgb = new LinearGradientBrush(c.ClientRectangle, cs[0], cs[1], 20f);
            e.Graphics.FillRectangle(lgb, c.ClientRectangle);
        }
    }
}
