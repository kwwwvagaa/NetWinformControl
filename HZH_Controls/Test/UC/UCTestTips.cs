using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using HZH_Controls.Forms;

namespace Test.UC
{
    [ToolboxItem(false)]
    public partial class UCTestTips : UserControl
    {
        public UCTestTips()
        {
            InitializeComponent();
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            ShowTips(sender as HZH_Controls.Controls.UCBtnExt);
        }

        private void ShowTips(HZH_Controls.Controls.UCBtnExt ucBtnExt1)
        {
            HZH_Controls.Forms.FrmAnchorTips.ShowTips(ucBtnExt1, "测试提示信息\nLEFT", AnchorTipsLocation.LEFT, ucBtnExt1.FillColor);
            HZH_Controls.Forms.FrmAnchorTips.ShowTips(ucBtnExt1, "测试提示信息\nRIGHT", AnchorTipsLocation.RIGHT, ucBtnExt1.FillColor);
            HZH_Controls.Forms.FrmAnchorTips.ShowTips(ucBtnExt1, "测试提示信息\nTOP", AnchorTipsLocation.TOP, ucBtnExt1.FillColor);
            HZH_Controls.Forms.FrmAnchorTips.ShowTips(ucBtnExt1, "测试提示信息\nBOTTOM", AnchorTipsLocation.BOTTOM, ucBtnExt1.FillColor);
        }
    }
}
