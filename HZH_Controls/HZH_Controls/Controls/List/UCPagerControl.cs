using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls
{
    [ToolboxItem(true)]
    public partial class UCPagerControl : UCPagerControlBase
    {
        public UCPagerControl()
        {
            InitializeComponent();           
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            PreviousPage();
        }

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
            NextPage();
        }

        private void panel3_MouseDown(object sender, MouseEventArgs e)
        {
            FirstPage();
        }

        private void panel4_MouseDown(object sender, MouseEventArgs e)
        {
            EndPage();
        }

        protected override void ShowBtn(bool blnLeftBtn, bool blnRightBtn)
        {
            panel1.Visible = panel3.Visible = blnLeftBtn;
            panel2.Visible = panel4.Visible = blnRightBtn;
        }
    }
}
