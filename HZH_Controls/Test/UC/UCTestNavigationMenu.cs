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
    [ToolboxItem(false)]
    public partial class UCTestNavigationMenu : UserControl
    {
        public UCTestNavigationMenu()
        {
            InitializeComponent();
        }

        private void UCTestNavigationMenu_Load(object sender, EventArgs e)
        {

        }

        private void ucNavigationMenu1_ClickItemed(object sender, EventArgs e)
        {
            if (ucNavigationMenu1.SelectItem != null)
            {
                HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), "点击了:" + ucNavigationMenu1.SelectItem.Text);
            }
        }
    }
}
