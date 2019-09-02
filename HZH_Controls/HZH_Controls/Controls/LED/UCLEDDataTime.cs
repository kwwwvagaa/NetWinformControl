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
    public partial class UCLEDDataTime : UserControl
    {
        private DateTime m_value;

        [Description("值"), Category("自定义")]
        public DateTime Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                string str = value.ToString("yyyy-MM-dd HH:mm:ss");
                for (int i = 0; i < str.Length; i++)
                {
                    if (i == 10)
                        continue;
                    ((UCLEDNum)this.tableLayoutPanel1.Controls.Find("D" + (i + 1), false)[0]).Value = str[i];
                }
            }
        }

        private int m_lineWidth = 8;

        [Description("线宽度，为了更好的显示效果，请使用偶数"), Category("自定义")]
        public int LineWidth
        {
            get { return m_lineWidth; }
            set
            {
                m_lineWidth = value;
                foreach (UCLEDNum c in this.tableLayoutPanel1.Controls)
                {
                    c.LineWidth = value;
                }
            }
        }

        [Description("颜色"), Category("自定义")]
        public override System.Drawing.Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                foreach (UCLEDNum c in this.tableLayoutPanel1.Controls)
                {
                    c.ForeColor = value;
                }
            }
        }
        public UCLEDDataTime()
        {
            InitializeComponent();
            Value = DateTime.Now;
        }
    }
}
