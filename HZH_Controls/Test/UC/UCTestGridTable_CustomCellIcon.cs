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
    public partial class UCTestGridTable_CustomCellIcon : UserControl, HZH_Controls.Controls.IDataGridViewCustomCell
    {
        public UCTestGridTable_CustomCellIcon()
        {
            InitializeComponent();
        }
        private TestGridModel m_object = null;
        public object DataSource
        {
            get
            {
                return m_object;
            }
        }
        public void SetBindSource(object obj)
        {
            if (obj is TestGridModel)
            {
                m_object = (TestGridModel)obj;
                this.BackgroundImage = Properties.Resources.rowicon;
            }
        }


        public event HZH_Controls.Controls.DataGridViewRowCustomEventHandler RowCustomEvent;
    }
}
