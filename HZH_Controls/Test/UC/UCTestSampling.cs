using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Controls;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestSampling : UserControl
    {
        public UCTestSampling()
        {
            InitializeComponent();
        }
        bool blnIn = false;
        private void ucSampling10_MouseEnter(object sender, EventArgs e)
        {
            blnIn = true;
            UCSampling uc = (UCSampling)sender;
            uc.Invalidate();
        }

        private void ucSampling10_MouseLeave(object sender, EventArgs e)
        {
            blnIn = false;
            UCSampling uc = (UCSampling)sender;
            uc.Invalidate();
        }

        private void ucSampling10_Paint(object sender, PaintEventArgs e)
        {
            if (blnIn)
            {
                UCSampling uc = (UCSampling)sender;
                e.Graphics.FillPath(new SolidBrush(Color.FromArgb(50, Color.White)), uc.BorderPath);
            }
        }
    }
}
