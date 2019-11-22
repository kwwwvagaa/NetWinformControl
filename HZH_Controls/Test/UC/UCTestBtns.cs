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
    public partial class UCTestBtns : UserControl
    {
        public UCTestBtns()
        {
            InitializeComponent();
        }

        private void UCTestBtns_Load(object sender, EventArgs e)
        {
            ucBtnsGroup1.DataSource = new Dictionary<string, string>() { { "1", "男" }, { "0", "女" } };
            ucBtnsGroup2.IsMultiple = true;
            ucBtnsGroup2.DataSource = new Dictionary<string, string>() { { "1", "河南" }, { "2", "北京" }, { "3", "湖南" }, { "4", "上海" } };
            ucBtnsGroup2.SelectItem = new List<string>() { "2", "3" };
        }
        Color m_cacheColor = Color.Empty;

        private void ucBtnImg1_MouseEffected(object sender, EventArgs e)
        {
            var btn = sender as HZH_Controls.Controls.UCBtnExt;
            if (m_cacheColor != Color.Empty)
            {
                btn.FillColor = m_cacheColor;
                m_cacheColor = Color.Empty;
            }
        }

        private void ucBtnImg1_MouseEffecting(object sender, EventArgs e)
        {
            var btn = sender as HZH_Controls.Controls.UCBtnExt;
            m_cacheColor = btn.FillColor;
            btn.FillColor = Color.Red;
        }
    }
}
