// 版权所有  黄正辉  交流群：568015492   QQ：623128629
// 文件名称：UCLEDTime.cs
// 作　　者：HZH
// 创建日期：2019-09-02 16:23:08
// 功能描述：UCLEDTime    English:UCLEDTime
// 项目地址：https://gitee.com/kwwwvagaa/net_winform_custom_control
// 项目地址：https://github.com/kwwwvagaa/NetWinformControl
// 如果你使用了此类，请保留以上说明
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
    public partial class UCLEDTime : UserControl
    {
        private DateTime m_value;

        [Description("值"), Category("自定义")]
        public DateTime Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                string str = value.ToString("HH:mm:ss");
                for (int i = 0; i < str.Length; i++)
                {
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
        public UCLEDTime()
        {
            InitializeComponent();
            Value = DateTime.Now;
        }
    }
}
