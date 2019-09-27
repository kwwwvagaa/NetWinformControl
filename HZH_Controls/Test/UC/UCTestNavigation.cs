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
    public partial class UCTestNavigation : UserControl
    {
        public UCTestNavigation()
        {
            InitializeComponent();
        }

        private void ucCrumbNavigation3_ClickItemed(object sender, HZH_Controls.Controls.CrumbNavigationClickEventArgs e)
        {
            for (int i = 0; i < ucCrumbNavigation3.Items.Length; i++)
            {
                if (i > e.Index)
                    ucCrumbNavigation3.Items[i].ItemColor = Color.Gray;
                else
                    ucCrumbNavigation3.Items[i].ItemColor = null;
            }
            ucCrumbNavigation3.Invalidate();
        }

        private void ucCrumbNavigation4_ClickItemed(object sender, HZH_Controls.Controls.CrumbNavigationClickEventArgs e)
        {
            for (int i = 0; i < ucCrumbNavigation4.Items.Length; i++)
            {
                if (i > e.Index)
                    ucCrumbNavigation4.Items[i].ItemColor = Color.Gray;
                else
                    ucCrumbNavigation4.Items[i].ItemColor = null;
            }
            ucCrumbNavigation4.Invalidate();
        }

        private void ucCrumbNavigation1_ClickItemed(object sender, HZH_Controls.Controls.CrumbNavigationClickEventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), e.Item.Text);
        }

        private void ucCrumbNavigation2_ClickItemed(object sender, HZH_Controls.Controls.CrumbNavigationClickEventArgs e)
        {
            HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), e.Item.Text);
        }
    }
}
