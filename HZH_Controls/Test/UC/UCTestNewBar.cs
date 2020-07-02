using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Test.UC
{
    public partial class UCTestNewBar : UserControl
    {
        public UCTestNewBar()
        {
            InitializeComponent();
        }

        private void label20_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)sender;
        }

        private void label2_Click(object sender, EventArgs e)
        {
            this.ActiveControl = (Control)sender;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
