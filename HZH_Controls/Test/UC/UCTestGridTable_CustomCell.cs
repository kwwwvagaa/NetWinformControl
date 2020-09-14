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
    public partial class UCTestGridTable_CustomCell : UserControl, HZH_Controls.Controls.IDataGridViewCustomCell
    {
        public event HZH_Controls.Controls.DataGridViewRowCustomEventHandler RowCustomEvent;
        private TestGridModel m_object = null;
        public object DataSource
        {
            get
            {
                return m_object;
            }
        }
        public UCTestGridTable_CustomCell()
        {
            InitializeComponent();
        }

        public void SetBindSource(object obj)
        {
            if (obj is TestGridModel)
                m_object = (TestGridModel)obj;
        }

        private void ucBtnExt1_BtnClick(object sender, EventArgs e)
        {
            if (RowCustomEvent != null)
            {
                RowCustomEvent(this, new HZH_Controls.Controls.DataGridViewRowCustomEventArgs() { EventName = "Modify" });
            }
            //if (m_object != null)
            //{
            //    HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(),"修改："+m_object.Name);
            //}
        }

        private void ucBtnExt2_BtnClick(object sender, EventArgs e)
        {
            if (RowCustomEvent != null)
            {
                RowCustomEvent(this, new HZH_Controls.Controls.DataGridViewRowCustomEventArgs() { EventName = "Delete" });
            }
            //if (m_object != null)
            //{
            //    HZH_Controls.Forms.FrmTips.ShowTipsSuccess(this.FindForm(), "删除：" + m_object.Name);
            //}
        }






    }
}
