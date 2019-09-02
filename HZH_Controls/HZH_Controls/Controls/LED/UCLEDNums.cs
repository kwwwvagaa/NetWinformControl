using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace HZH_Controls.Controls.LED
{
    public partial class UCLEDNums : UserControl
    {
        private string m_value;

        [Description("值"), Category("自定义")]
        public string Value
        {
            get { return m_value; }
            set
            {
                m_value = value;
                ReloadValue();
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
                foreach (UCLEDNum c in this.Controls)
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
                foreach (UCLEDNum c in this.Controls)
                {
                    c.ForeColor = value;
                }
            }
        }

        public override RightToLeft RightToLeft
        {
            get
            {
                return base.RightToLeft;
            }
            set
            {
                base.RightToLeft = value;
                ReloadValue();
            }
        }

        private void ReloadValue()
        {
            try
            {
                ControlHelper.FreezeControl(this, true);
                this.Controls.Clear();
                foreach (var item in m_value)
                {
                    UCLEDNum uc = new UCLEDNum();
                    if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                        uc.Dock = DockStyle.Right;
                    else
                        uc.Dock = DockStyle.Left;
                    uc.Value = item;
                    uc.ForeColor = ForeColor;
                    uc.LineWidth = m_lineWidth;
                    this.Controls.Add(uc);
                    if (RightToLeft == System.Windows.Forms.RightToLeft.Yes)
                        uc.SendToBack();
                    else
                        uc.BringToFront();
                }
            }
            finally
            {
                ControlHelper.FreezeControl(this, false);
            }
        }
        public UCLEDNums()
        {
            InitializeComponent();
            Value = "0.00";
        }
    }
}
